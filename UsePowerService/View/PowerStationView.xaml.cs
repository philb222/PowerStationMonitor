using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UsePowerService.ViewModel;

namespace UsePowerService.View
{
	/// <summary>
	/// Interaction logic for StationDetails.xaml
	/// </summary>
	public partial class PowerStationView : WindowBase, IDisposable
	{
		private PowerStationViewModel _viewModel;

		#region Constructor
		public PowerStationView(int inStationNumber) : base()
		{
			InitializeComponent();

			_viewModel = new PowerStationViewModel(inStationNumber);
			base.DataContext = _viewModel;
		}
		#endregion

		#region Closing

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Dispose();

			HourList.SelectionChanged -= HourList_SelectionChanged;
			this.Loaded -= Window_Loaded;
			this.Closing -= Window_Closing;
			this.btnClose.Click -= btnClose_Click;

			HourChart = null;
			_viewModel = null;
			base.DataContext = null;

			GC.Collect();
		}

		#endregion

		#region Loaded Event

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			HourChart.CcXaxisDescription = @"<==========  Time (MM:SS)  ==========>";
			HourChart.CcYaxisDescription = @"<==========  Megawatts  ==========>";

			// Default the calendar to allowing only 'today', the only day we have power station readings.
			Calendar.DisplayDate = DateTime.Now;
			Calendar.DisplayDateStart = DateTime.Now;
			Calendar.DisplayDateEnd = DateTime.Now;

			// Default the list of hours to select the current hour.
			HourList.SelectedIndex = DateTime.Now.Hour;
			HourList.ScrollIntoView(HourList.SelectedItem);
		}
		#endregion

		#region Hour List Selection Changed Event
		/// <summary>
		/// The user selected a time interval from the list of hours of the day.
		/// So display the requested hour of power station readings.
		/// </summary>
		private void HourList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// If successful getting power station readings for the selected hour...
			if (_viewModel.HandleSelectedHour((string)HourList.SelectedItem, HourList.SelectedIndex))
			{
				HourChart.CcYaxisValues = _viewModel.StationData.YaxisValues;
				HourChart.CcDataValues = _viewModel.StationData.HourOfData;
			}
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
					_viewModel.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~PowerStationView() {
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
