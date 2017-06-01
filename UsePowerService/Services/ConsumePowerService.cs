//using AdminPowerStations.APIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using UsePowerService.Model;
using UsePowerService.PowerService;

namespace UsePowerService.Services
{
	/// <summary>
	/// This class is used to retrieve power station information via a WCF service.
	/// </summary>
    public class ConsumePowerService : IDisposable
    {
        private readonly PowerServiceClient _proxy;
        private decimal[] _powerReadings;
		private readonly static List<OneStationData> _cache = new List<OneStationData>();
		private readonly static object _cacheLock = new object();

        #region Constructor
        public ConsumePowerService()
        {
            _proxy = new PowerServiceClient();

			// '13' for 10 power stations plus hour, minute, second.
            _powerReadings = new decimal[13];
		}
        #endregion

        #region Read All Stations for 1 second of information
        /// <summary>
        /// Use a WCF service to obtain power station readings for the requested time.
        /// </summary>
        /// <param name="inHour">Requested hour</param>
        /// <param name="inMinute">Requested minute</param>
        /// <param name="inSecond">Requested second</param>
        /// <returns>An array of information</returns>
        public decimal[] ReadAllStations(int inHour, int inMinute, int inSecond)
        {
            PowerUsage_AllStations_OneSecond _results;

            Tuple<string, string, string> _Request = ValidateReadAll(inHour, inMinute, inSecond);

            _results = _proxy.ReportStationsAll(_Request.Item1, _Request.Item2, _Request.Item3);

            //private string _baseUrl = @"http://localhost:65094/APIs/PowerService.svc/Stations/All/";
            //        private string _serviceUrl = @"http://localhost:65094/APIs/PowerService.svc/Stations/All/12/45/0";
            //string _url = _baseUrl + _Request.Item1 + "/" + _Request.Item2 + "/" + _Request.Item3;
            //    WebClient client = new WebClient();
            //byte[] data = client.DownloadData(_url);

            //Stream stream = new MemoryStream(data);
            //DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(PowerUsage_AllStations_OneSecond));

            //PowerUsage_AllStations_OneSecond _results = obj.ReadObject(stream) as PowerUsage_AllStations_OneSecond;

            _powerReadings[0] = _results.Station01PowerUsage;
            _powerReadings[1] = _results.Station02PowerUsage;
            _powerReadings[2] = _results.Station03PowerUsage;
            _powerReadings[3] = _results.Station04PowerUsage;
            _powerReadings[4] = _results.Station05PowerUsage;
            _powerReadings[5] = _results.Station06PowerUsage;
            _powerReadings[6] = _results.Station07PowerUsage;
            _powerReadings[7] = _results.Station08PowerUsage;
            _powerReadings[8] = _results.Station09PowerUsage;
            _powerReadings[9] = _results.Station10PowerUsage;
            _powerReadings[10] = _results.ReadingHour;
            _powerReadings[11] = _results.ReadingMinute;
            _powerReadings[12] = _results.ReadingSecond;

            return _powerReadings;
        }

        private Tuple<string, string, string> ValidateReadAll(int inHour, int inMinute, int inSecond)
        {
            if (inHour < 0 || inHour > 23)
                throw new InvalidOperationException("Invalid hour");
            if (inMinute < 0 || inMinute > 59)
                throw new InvalidOperationException("Invalid minute");
            if (inSecond < 0 || inSecond > 59)
                throw new InvalidOperationException("Invalid second");

            string reqHour = inHour.ToString();
            string reqMinute = inMinute.ToString();
            string reqSecond = inSecond.ToString();

            Tuple<string, string, string> _results = Tuple.Create(reqHour, reqMinute, reqSecond);

            return _results;
        }
		#endregion

		#region Get an hour of data for one station
		/// <summary>
		/// Use a WCF service to obtain power station readings for the requested station and hour.
		/// </summary>
		/// <param name="inStation">Requested station</param>
		/// <param name="inHour">Requested hour</param>
		/// <returns>An array of information</returns>
		public OneStationData ReadOneStationOneHour(int inStation, int inHour, out string ErrorMessage)
		{
			// Init the mandatory return error message
			ErrorMessage = String.Empty;                                            

			// Validate the request
			Tuple<string, string> _Request = ValidateReadOneHour(inStation, inHour);

			// Pass station # and hour to check the cache.
			OneStationData _results = CheckCache(_Request.Item1, inHour);

			// If found the data in the cache, return now.
			if (_results != null)
				return _results;

			_results = new OneStationData()
			{
				StationNumber = inStation.ToString(),
				DataHourNumber = inHour
			};
			PowerUsage_OneStation_15Minutes _15MinData;					// Call service for 1 of these
			int _recsPer15min = 900;									// Receive 900 rec's per service call (15 mins X 60 seconds = 900)
			int _15minInterval = 0;

			// Loop 4 times to get 4 15-minute intervals for the requested hour. 
			// The service can only provide 900 readings per request.
			for (int startMinute = 0; startMinute < 60; startMinute += 15, ++_15minInterval)
			{
				// Get 15 minutes of data.
				_15MinData = _proxy.ReportOneStation(_Request.Item1, _Request.Item2, startMinute.ToString());
				ErrorMessage = _15MinData.ErrorMessage;

				// If error get out
				if (!string.IsNullOrEmpty(ErrorMessage))
					break;

				// If we don't have the basic station info yet, get it once.
				if (String.IsNullOrEmpty(_results.StationName))
				{
					_results.StationName = _15MinData.StationName;
					_results.StationLocation = _15MinData.StationLocation;
					_results.StationPhone = _15MinData.StationPhone;
				}

				// Copy 15 mins of data to the final array which holds 1 hour of data.
				_15MinData.PowerUsage.CopyTo(_results.HourOfData, _15minInterval * _recsPer15min);
			}

			// If no error, add data the the cache.
			if (string.IsNullOrEmpty(ErrorMessage))
			{
				AddToCache(_results);
			}
				return _results;
		}

		private void AddToCache(OneStationData newData)
		{
			lock (_cacheLock)
			{
				// If cache at max, remove the least requested instance of OneStationData.
				if (_cache.Count > Properties.Settings.Default.StationCacheMax)
				{
					var leastRequested = (_cache
						.OrderBy(c => c.CacheRequests))
						.First();

					_cache.Remove(leastRequested);
				}

				newData.CacheRequests = 1;
				_cache.Add(newData);
			}
		}

		/// <summary>
		/// Validate the request for reading a station for 1 hour of data.
		/// </summary>
		/// <param name="inStation">Station number</param>
		/// <param name="inHour">Hour of day number</param>
		/// <returns></returns>
		private Tuple<string, string> ValidateReadOneHour(int inStation, int inHour)
		{
			if (inStation < 1 || inStation > 10)
				throw new InvalidOperationException("Invalid station");

			if (inHour < 0 || inHour > 23)
				throw new InvalidOperationException("Invalid hour");

			string reqStation = inStation.ToString();
			string reqHour = inHour.ToString();

			Tuple<string, string> _results = Tuple.Create(reqStation, reqHour);

			return _results;
		}

		/// <summary>
		/// See if the requested data is already cached.
		/// </summary>
		/// <param name="inStation">Station # of interest</param>
		/// <param name="inHour">Hour of day of interest</param>
		/// <returns>Null if not in cache, else OneStationData instance</returns>
		private OneStationData CheckCache(string inStation, int inHour)
		{
			lock (_cacheLock)
			{
				foreach (var data in _cache)
				{
					if (data.StationNumber == inStation && data.DataHourNumber == inHour)
					{
						// Show this data has been requested again.
						data.CacheRequests += 1;
						return data;
					}
				}
			}
			return null;
		}

		#endregion

		#region Implement IDisposable
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (_proxy.State == System.ServiceModel.CommunicationState.Opened)
					{
						_proxy.Close();
					}
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~ConsumePowerService() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion

	}
}
