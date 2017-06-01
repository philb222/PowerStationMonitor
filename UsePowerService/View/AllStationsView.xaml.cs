using DllMeter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsePowerService.View;
using UsePowerService.ViewModel;

namespace UsePowerService.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class AllStationsView : WindowBase, IDisposable
	{
		private readonly AllStationsViewModel _viewModel;

		#region Constructor
		public AllStationsView() : base()
		{
			InitializeComponent();

			_viewModel = new AllStationsViewModel();
			base.DataContext = _viewModel;

			// Set command for SmartMeter 'click' to open a power station detail window.
			CommandBinding aBinding = new CommandBinding();
			aBinding.Command = SmartMeter.SM_Command;
			aBinding.Executed += ExecuteStationDetailsCommand;
			this.CommandBindings.Add(aBinding);
		}
		#endregion

		#region UI Command for station details
		/// <summary>
		/// Handle a 'ui command'...
		/// A 'meter' was clicked in the UI, so open a new window to show the details
		/// of the power station corresponding to the meter just clicked.
		/// </summary>
		private void ExecuteStationDetailsCommand(object sender, ExecutedRoutedEventArgs e)
		{
			int station = Convert.ToInt32(e.Parameter);
			PowerStationView detailWindow = new PowerStationView(station);
			detailWindow.Show();
		}
		#endregion

		#region Loaded Event
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			string _timeZoneName = TimeZoneInfo.Local.StandardName;

			if (TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.Now))
			{
				_timeZoneName = TimeZoneInfo.Local.DaylightName;
			}
			labTimeZone.Content = "(" + _timeZoneName + ")";
		}
		#endregion

		#region Close
		private void QuitButton_CB_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void WindowBase_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Dispose();
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
		// ~AllStationsView() {
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
