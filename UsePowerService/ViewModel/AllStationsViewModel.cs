using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using UsePowerService.Model;
using UsePowerService.Services;

namespace UsePowerService.ViewModel
{
	/// <summary>
	/// Provide access to/from the UI and model 'ConsumePowerService'.
	/// 
	/// A background timer routine is used here to poll the 'ConsumePowerService' object
	/// every 1 second. Here the results of the polling are made available to the UI via
	/// updating bound dependency properties on the UI thread by using '_uiContext' below.
	/// </summary>
	public class AllStationsViewModel : DependencyObject, IDisposable
    {
        private readonly ConsumePowerService _modelPowerService;
		private Timer _timer;
        private decimal[] _powerReadings;
        private System.Threading.SynchronizationContext _uiContext = System.Threading.SynchronizationContext.Current;
		private const string NoServiceError = "To see simulated live power station readings, run project 'PowerStationService' in another instance of Visual Studio.";

		#region Constructor
		public AllStationsViewModel()
        {
            _modelPowerService = new ConsumePowerService();
			AllStations = new AllStationsData();

			_timer = new Timer();
            _timer.Elapsed += GetPowerStationReadings;
            _timer.Interval = 1000;			// Get power station data every second.
            _timer.Start();
        }
		#endregion

		#region Status Message Property

		private static readonly DependencyProperty StatusMessageProperty =
			DependencyProperty.Register("StatusMessage", typeof(string), typeof(AllStationsViewModel),
			new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public string StatusMessage
		{
			get { return (string)GetValue(StatusMessageProperty); }

			set { SetValue(StatusMessageProperty, value); }
		}

		#endregion

		#region AllStations Property

		public AllStationsData AllStations { get; private set; }

		#endregion

		#region Get Power Readings via Model Power Service every second.
		/// <summary>
		/// Get power station readings every second. Update UI bound
		/// dependency properties with the results so the UI gets updated.
		/// </summary>
		private void GetPowerStationReadings(object sender, ElapsedEventArgs e)
		{
			try
			{
				DateTime now = DateTime.Now;

				_powerReadings = _modelPowerService.ReadAllStations(now.Hour, now.Minute, now.Second);

				_uiContext.Send(UpdateUiProperties, _powerReadings);
			}
			catch (Exception ex)
			{
				_timer.Stop();

				string errorMessage = "Error: " + ex.Message;

				if (ex.InnerException != null && ex.InnerException.Message.StartsWith("Unable to connect"))
				{
					errorMessage = NoServiceError;
				}
				_uiContext.Send(UpdateUiStatusMessage, errorMessage);
			}
		}

		/// <summary>
		/// Update the UI's 10 power station meters with data.
		/// </summary>
		/// <param name="state"></param>
		private void UpdateUiProperties(object state)
		{
			decimal[] _readings = (decimal[])state;
			AllStations.Station1Source = _readings[0];
			AllStations.Station2Source = _readings[1];
			AllStations.Station3Source = _readings[2];
			AllStations.Station4Source = _readings[3];
			AllStations.Station5Source = _readings[4];
			AllStations.Station6Source = _readings[5];
			AllStations.Station7Source = _readings[6];
			AllStations.Station8Source = _readings[7];
			AllStations.Station9Source = _readings[8];
			AllStations.Station10Source = _readings[9];

			// Set hour of data source 
			AllStations.CurrentHour = _readings[10].ToString();
			if (_readings[10] < 10)
			{
				// Include leading '0' when hour < 10
				AllStations.CurrentHour = "0" + _readings[10].ToString();
			}
			AllStations.CurrentHour += ":";

			// Set minutes of data source 
			AllStations.CurrentMinute = _readings[11].ToString();
			if (_readings[11] < 10)
			{
				// Include leading '0' when minute < 10
				AllStations.CurrentMinute = "0" + _readings[11].ToString();
			}
			AllStations.CurrentMinute += ":";

			// Set seconds of data source 
			AllStations.CurrentSecond = _readings[12].ToString();
			if (_readings[12] < 10)
			{
				// Include leading '0' when second < 10
				AllStations.CurrentSecond = "0" + _readings[12].ToString();
			}
		}

		private void UpdateUiStatusMessage(object state)
		{
			string _message = (string)state;
			StatusMessage = _message;
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
					_timer.Dispose();
					_modelPowerService.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~AllStationsViewModel() {
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
