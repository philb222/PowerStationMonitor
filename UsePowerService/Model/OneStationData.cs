using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UsePowerService.Model
{
	/// <summary>
	/// This class defines information for displaying an hour of data of a power station.
	/// It implements INotifyPropertyChanged so the UI can display data from here.
	/// </summary>
	public class OneStationData : DependencyObject, INotifyPropertyChanged
	{
		#region Constructor
		public OneStationData()
		{
			_HourOfData = new decimal[3600];      // Room for 1 hour of data (60 mins X 60 secs)
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

		#region Internal Properties
		public int DataHourNumber { get; set; }
		public DateTime DayOfData { get; set; }
		public int CacheRequests { get; set; }

		#endregion

		#region Public Properties

		// Next is the station's name.
		private string _StationName;
		public string StationName
		{
			get { return _StationName; }
			set
			{
				if (_StationName != value)
				{
					_StationName = value;
					NotifyPropertyChanged();
				}
			}
		}

		// Next is the station's number
		private string _StationNumber;
		public string StationNumber
		{
			get { return _StationNumber; }
			set
			{
				if (_StationNumber != value)
				{
					_StationNumber = value;
					NotifyPropertyChanged();
				}
			}
		}

		// Next is the station's address.
		private string _StationLocation;
		public string StationLocation
		{
			get { return _StationLocation; }
			set
			{
				if (_StationLocation != value)
				{
					_StationLocation = value;
					NotifyPropertyChanged();
				}
			}
		}

		// Next is the station's phone number.
		private string _StationPhone;
		public string StationPhone
		{
			get { return _StationPhone; }
			set
			{
				if (_StationPhone != value)
				{
					_StationPhone = value;
					NotifyPropertyChanged();
				}
			}
		}

		// Next is the actual data, plotted on a custom line chart.
		private decimal[] _HourOfData;
		public decimal[] HourOfData
		{
			get { return _HourOfData; }
			set
			{
				if (_HourOfData != value)
				{
					_HourOfData = value;
					NotifyPropertyChanged();
				}
			}
		}

		// Next is the title for the custom line chart.
		private string _HourChartTitle;
		public string HourChartTitle
		{
			get { return _HourChartTitle; }
			set
			{
				if (_HourChartTitle != value)
				{
					_HourChartTitle = value;
					NotifyPropertyChanged();
				}
			}
		}

		// Next is used for showing MM:SS values across the X-axis of a custom line chart.
		private string _HourXaxisValues;
		public string HourXaxisValues
		{
			get { return _HourXaxisValues; }
			set
			{
				if (_HourXaxisValues != value)
				{
					_HourXaxisValues = value;
					NotifyPropertyChanged();
				}
			}
		}

		// Next is used for showing megawatt values vertically on the Y-axis of a custom line chart.
		private double[] _YaxisValues;
		public double[] YaxisValues
		{
			get { return _YaxisValues; }
			set
			{
				if (_YaxisValues != value)
				{
					_YaxisValues = value;
					NotifyPropertyChanged();
				}
			}
		}

		#endregion

	}
}
