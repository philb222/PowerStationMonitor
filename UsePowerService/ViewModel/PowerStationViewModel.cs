using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UsePowerService.Model;
using UsePowerService.Services;

namespace UsePowerService.ViewModel
{
	/// <summary>
	/// This view model class is used when displaying information for one power station to the UI.
	/// Power station data is retrieved via ConsumePowerService which talks to a WCF service.
	/// </summary>
	public class PowerStationViewModel : DependencyObject, INotifyPropertyChanged, IDisposable
	{
		private int _stationNumber;
		private bool _firstTime = true;
		private ConsumePowerService _modelPowerService = new ConsumePowerService();
		private const string NoServiceError = "Need to run project 'PowerStationService' in another instance of Visual Studio.";

		#region Constructor
		public PowerStationViewModel(int inStationNumber)
		{
			_stationNumber = inStationNumber;

			// Create object to hold information for the station in progress
			StationData = new OneStationData()
			{
				DayOfData = DateTime.Now,           // Always today's data for now
				StationNumber = inStationNumber.ToString()
			};

			// Create list of hours of the day the user can select from to display data for that hour.
			CreateHourList();
		}
		#endregion

		#region Implement INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		#region Public Properties

		public OneStationData StationData { get; private set; }
		public List<string> HourList { get; private set; }

		private string _StatusMessage;
		public string StatusMessage
		{
			get { return _StatusMessage; }
			set
			{
				if (_StatusMessage != value)
				{
					_StatusMessage = value;
					NotifyPropertyChanged();
				}
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// The user selected an 'hour' from the list of hours of the day.
		/// So retrieve power station readings for that hour to display to the UI.
		/// </summary>
		/// <param name="inSelectedHour">Time interval to display</param>
		/// <param name="inHour">Hour to display</param>
		/// <returns>True if successful, else property 'StatusMessage' shows an error message to a UI bound control.</returns>
		public bool HandleSelectedHour(string inSelectedHour, int inHour)
		{
			string errorMessage = null;

			try
			{
				OneStationData newData = _modelPowerService.ReadOneStationOneHour(_stationNumber, inHour, out errorMessage);

				// If error...
				if (!string.IsNullOrEmpty(errorMessage))
				{
					StatusMessage = errorMessage;
					return false;
				}

				// If first time, setup info in viewmodel's OneStationData instance once.
				if (_firstTime)
				{
					_firstTime = false;
					StationData.HourXaxisValues = CreateHourXaxisValues();
					StationData.YaxisValues = CreateYaxisValues();
				}

				StationData.StationName = newData.StationName;
				StationData.StationNumber = newData.StationNumber;
				StationData.StationLocation = newData.StationLocation;
				StationData.StationPhone = newData.StationPhone;
				StationData.DataHourNumber = newData.DataHourNumber;
				StationData.HourOfData = newData.HourOfData;

				StationData.HourChartTitle = "Readings from: " + StationData.DayOfData.ToShortDateString() + "   Time: " + inSelectedHour;

				newData = null;
				// Collect garbage because each hour of station data has a lot of data.
				GC.Collect();
			}
			catch (Exception ex)
			{
				if (ex.InnerException != null && ex.InnerException.Message.StartsWith("Unable to connect"))
				{
					StatusMessage = NoServiceError;
				}
				else
				{
					StatusMessage = ex.Message;
				}
				return false;
			}

			return true;
		}
		#endregion

		#region Private helper methods

		/// <summary>
		/// Create a list of MM:SS values for populating a line chart's bottom X-axis area.
		/// Power station readings will populate the chart across 'time'.
		/// </summary>
		/// <returns>String of MM:SS values.</returns>
		private string CreateHourXaxisValues()
		{
			StringBuilder sb = new StringBuilder();

			// Show 'MM:SS' every 5 seconds. 
			int countSeconds = 5;

			for (int minute = 0; minute < 60; ++minute)
			{
				for (int second = 0; second < 60; ++second)
				{
					// If interval done, add a 'MM:SS' to the output.
					if (countSeconds == 5)
					{
						countSeconds = 0;

						// If last time, send 'true' parameter.
						if (minute == 59 && second == 55)
						{
							sb.Append(FormatMinutesAndSeconds(minute, second, true));
						}
						else
						{
							sb.Append(FormatMinutesAndSeconds(minute, second, false));
						}
					}
					++countSeconds;
				}
			}
			return sb.ToString();
		}

		/// <summary>
		/// Format the given minutes and seconds values.
		/// </summary>
		/// <param name="inMinute">Minute to format</param>
		/// <param name="inSecond">Second to format</param>
		/// <param name="inLast">If true, don't append a space</param>
		/// <returns>String in the form "MM:SS "</returns>
		private string FormatMinutesAndSeconds(int inMinute, int inSecond, bool inLast)
		{
			string minute = inMinute.ToString();

			// Include a leading zero if necessary.
			if (minute.Length == 1)
			{
				minute = "0" + minute;
			}

			string second = inSecond.ToString();

			// Include a leading zero if necessary.
			if (second.Length == 1)
			{
				second = "0" + second;
			}

			// If last time, don't append a space. Causes a problem if we do.
			if (inLast)
				return minute + ":" + second;
			else
				return minute + ":" + second + " ";
		}

		/// <summary>
		/// Create a list of values for populating a line chart's vertical Y-axis area.
		/// Power station readings will use these values as 'Megawatts'.
		/// </summary>
		/// <returns>Array of values to be used as 'Megawatts'</returns>
		private double[] CreateYaxisValues()
		{
			double[] yAxis = new double[13];
			double yValue = 0d;

			for (int x = 0; x < yAxis.Length; ++x)
			{
				yAxis[x] = yValue;
				yValue += 10d;
			}
			return yAxis;
		}

		private void CreateHourList()
		{
			HourList = new List<string>();
			HourList.Add("00:00 to 00:59 AM");
			HourList.Add("01:00 to 01:59 AM");
			HourList.Add("02:00 to 02:59 AM");
			HourList.Add("03:00 to 03:59 AM");
			HourList.Add("04:00 to 04:59 AM");
			HourList.Add("05:00 to 05:59 AM");
			HourList.Add("06:00 to 06:59 AM");
			HourList.Add("07:00 to 07:59 AM");
			HourList.Add("08:00 to 08:59 AM");
			HourList.Add("09:00 to 09:59 AM");
			HourList.Add("10:00 to 10:59 AM");
			HourList.Add("11:00 to 11:59 AM");
			HourList.Add("12:00 to 12:59 PM");
			HourList.Add("01:00 to 01:59 PM");
			HourList.Add("02:00 to 02:59 PM");
			HourList.Add("03:00 to 03:59 PM");
			HourList.Add("04:00 to 04:59 PM");
			HourList.Add("05:00 to 05:59 PM");
			HourList.Add("06:00 to 06:59 PM");
			HourList.Add("07:00 to 07:59 PM");
			HourList.Add("08:00 to 08:59 PM");
			HourList.Add("09:00 to 09:59 PM");
			HourList.Add("10:00 to 10:59 PM");
			HourList.Add("11:00 to 11:59 PM");
		}
		#endregion

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_modelPowerService.Dispose();
					_modelPowerService = null;
					StationData.HourOfData = null;
					StationData.YaxisValues = null;
					StationData = null;
					HourList = null;
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~PowerStationViewModel() {
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
