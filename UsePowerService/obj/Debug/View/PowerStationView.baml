   M S B A M L   `   `   `  ����J  FDllCoiledButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:DllCoiledButton;assembly=DllCoiledButtonDllCoiledButton  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5      G CDllLineChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:DllLineChart;assembly=DllLineChartDllLineChart 5      J FUsePowerService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:UsePowerService.ViewUsePowerService.View 5      T PMemoryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=1e58ca7299ba3c32D2clr-namespace:MemoryControl;assembly=MemoryControlMemoryControl 5      +   %UsePowerService.View.PowerStationView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      Ccb6clr-namespace:DllCoiledButton;assembly=DllCoiledButton    5      Ddiag5clr-namespace:System.Diagnostics;assembly=WindowsBase    5      =lc0clr-namespace:DllLineChart;assembly=DllLineChart    5      2local"clr-namespace:UsePowerService.View    5      Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    5      @mem2clr-namespace:MemoryControl;assembly=MemoryControl    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	      %  UsePowerService.View.WindowBase    Loaded$  Window_Loaded��5         Closing$ Window_Closing��5       � Title$ Power Station View��5
      $	��810��6    $
��1020��6-    � WindowStartupLocation$ CenterScreen=�5      
���   �.��5      �� 
����  �$��10q�6    �� CornerRadius$ 0��62   ._�5      �  � RowDefinitions 5      �� 5      $��50 �6   �� 5      $	��180 �6   �� 5      $	��410 �6   �� 5      $��20 �6   �� 5      $	��150 �6    � ColumnDefinitions 5      �� 5      $	��500 �6   �� 5      $	��500 �6   .+�5      �� $��0��6   $��0��6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	10 10 0 0q�6*   .+�5      ��  
  Label2#��[  6   $��Station Name:��5    
   �� 5!       
 Label3#��[ 6   ��5"   
   ��  �� Path$ StationData.StationName�5#      �� 5$      $ 
Horizontal=�6   $��10 0 0 0q�6*   .+�5%      �� #��[  6   $��Station Number:��5&   
   �� 5'      #��[ 6   ��5(   
   �� $ StationData.StationNumber�5)      5*      �� 5-      $��1��6   $��0��6    .+�5.      �� $ 
Horizontal=�6   $��	10 10 0 0q�6*   .+�5/      �� #��[  6   $��Address:��50   
   �� 51      #��[ 6   ��52   
   �� $! StationData.StationLocation�53      �� 54      $ 
Horizontal=�6   $��10 0 0 0q�6*   .+�55      �� #��[  6   $��Phone:��56   
   �� 57      #��[ 6   ��58   
   �� $ StationData.StationPhone�59      5:      �� 5=      $��0��6   $��1��6    .+�5>      �� $ 
Horizontal=�6   $��	10 10 0 0q�6*   .+�5?      �� #��[  6   $��Select date:��6-   &   System.Windows.Controls.Calendar  5@      -   5        	  Name$	 Calendar��5@      
����ح�6"   5A      5B      �� 5E      $��1��6   $��1��6    .+�5F      �� $ 
Horizontal=�6   $��0 10 0 0q�6*   .+�5G      �� #��[  6   $��Select hour:��6-   �� 5H      -   5        
 ��Name$
 HourList��5H      $	��160��6!   $	��140��6.   ��5I   	   �� $ HourList�5J   	   5K      5L        DllLineChart.LineChart  5P      -   5          Name$ 	HourChart��5P      $��0��6%   $��2��65   $��2��6B      CcWidth$	 900Q�5Q   	      CcHeight$	 410Q�6      CcThresholdHigh$	 100Q�5S   	      CcChartName 5R   	   �� $  StationData.HourChartTitle�   CcXaxisValues 5T   	   �� $! StationData.HourXaxisValues��� 5W      $��10��6   $	��940��6   $��0��6'   $��3��67   $��5��6D   
����  � �� RadiusX$ 10��6d    �� RadiusY$ 10��6q   �� 5[      -   5         ��Name$ Scroller��5[      $��0��6%   $��4��65   $	��380��6B   $
��Auto=�5\      $��Hidden=�6?   |�.  $��0 0 0 10q�5]   .   .��5^      �� -   5         ��Name$ 
txtMessage��5^      $
��Wrap=�6$   
��� �����5_      ��  �� ElementName$ Scroller��$ ViewportWidth���5`   1   �� $ StatusMessage�5a      �� 5d      $��1��6   $��4��6    $ 
Horizontal=�5e      $��Right=�6    .+�5g      �� -   5         ��Name$ btnClose��5h        NormalButton#��[ 5g       �� IsCancel . $	��140��5i      $��40��6   $��	0 0 30 30q�5j       � ToolTip$ Close this window��6   ��5k      �� 5l      $��Close��6     	linBrush1#��[ 5m      5o      5p      5r      5s      5t      