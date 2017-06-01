using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UsePowerService.Model
{
	/// <summary>
	/// This class defines:
	/// 1. Properties for the current time (hour, minute, and second) for a set of power station readings.
	/// 2. Properties for power station readings for 10 power stations.
	/// </summary>
	public class AllStationsData : DependencyObject
	{
		#region Current time 'hour' Property

		private static readonly DependencyProperty CurrentHourProperty =
			DependencyProperty.Register("CurrentHour", typeof(string), typeof(AllStationsData),
			new FrameworkPropertyMetadata("00", FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public string CurrentHour
		{
			get { return (string)GetValue(CurrentHourProperty); }

			set { SetValue(CurrentHourProperty, value); }
		}
		#endregion

		#region Current time 'minute' Property

		private static readonly DependencyProperty CurrentMinuteProperty =
			DependencyProperty.Register("CurrentMinute", typeof(string), typeof(AllStationsData),
			new FrameworkPropertyMetadata("00", FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public string CurrentMinute
		{
			get { return (string)GetValue(CurrentMinuteProperty); }

			set { SetValue(CurrentMinuteProperty, value); }
		}
		#endregion

		#region Current time 'second' Property

		private static readonly DependencyProperty CurrentSecondProperty =
			DependencyProperty.Register("CurrentSecond", typeof(string), typeof(AllStationsData),
			new FrameworkPropertyMetadata("00", FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public string CurrentSecond
		{
			get { return (string)GetValue(CurrentSecondProperty); }

			set { SetValue(CurrentSecondProperty, value); }
		}
		#endregion

		#region Station 1 Meter Source Property

		private static readonly DependencyProperty Station1SourceProperty =
			DependencyProperty.Register("Station1Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station1Source
		{
			get { return (decimal)GetValue(Station1SourceProperty); }

			set { SetValue(Station1SourceProperty, value); }
		}
		#endregion

		#region Station 2 Meter Source

		private static readonly DependencyProperty Station2SourceProperty =
			DependencyProperty.Register("Station2Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station2Source
		{
			get { return (decimal)GetValue(Station2SourceProperty); }

			set { SetValue(Station2SourceProperty, value); }
		}
		#endregion

		#region Station 3 Meter Source

		private static readonly DependencyProperty Station3SourceProperty =
			DependencyProperty.Register("Station3Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station3Source
		{
			get { return (decimal)GetValue(Station3SourceProperty); }

			set { SetValue(Station3SourceProperty, value); }
		}
		#endregion

		#region Station 4 Meter Source

		private static readonly DependencyProperty Station4SourceProperty =
			DependencyProperty.Register("Station4Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station4Source
		{
			get { return (decimal)GetValue(Station4SourceProperty); }

			set { SetValue(Station4SourceProperty, value); }
		}
		#endregion

		#region Station 5 Meter Source

		private static readonly DependencyProperty Station5SourceProperty =
			DependencyProperty.Register("Station5Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station5Source
		{
			get { return (decimal)GetValue(Station5SourceProperty); }

			set { SetValue(Station5SourceProperty, value); }
		}
		#endregion

		#region Station 6 Meter Source

		private static readonly DependencyProperty Station6SourceProperty =
			DependencyProperty.Register("Station6Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station6Source
		{
			get { return (decimal)GetValue(Station6SourceProperty); }

			set { SetValue(Station6SourceProperty, value); }
		}
		#endregion

		#region Station 7 Meter Source

		private static readonly DependencyProperty Station7SourceProperty =
			DependencyProperty.Register("Station7Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station7Source
		{
			get { return (decimal)GetValue(Station7SourceProperty); }

			set { SetValue(Station7SourceProperty, value); }
		}
		#endregion

		#region Station 8 Meter Source

		private static readonly DependencyProperty Station8SourceProperty =
			DependencyProperty.Register("Station8Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station8Source
		{
			get { return (decimal)GetValue(Station8SourceProperty); }

			set { SetValue(Station8SourceProperty, value); }
		}
		#endregion

		#region Station 9 Meter Source

		private static readonly DependencyProperty Station9SourceProperty =
			DependencyProperty.Register("Station9Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station9Source
		{
			get { return (decimal)GetValue(Station9SourceProperty); }

			set { SetValue(Station9SourceProperty, value); }
		}
		#endregion

		#region Station 10 Meter Source

		private static readonly DependencyProperty Station10SourceProperty =
			DependencyProperty.Register("Station10Source", typeof(decimal), typeof(AllStationsData),
			new FrameworkPropertyMetadata(0m, FrameworkPropertyMetadataOptions.AffectsRender));

		// Allow access via XAML.
		public decimal Station10Source
		{
			get { return (decimal)GetValue(Station10SourceProperty); }

			set { SetValue(Station10SourceProperty, value); }
		}
		#endregion


	}
}
