   M S B A M L   `   `   `  ����J  FDllCoiledButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:DllCoiledButton;assembly=DllCoiledButtonDllCoiledButton  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35L5clr-namespace:System.Diagnostics;assembly=WindowsBaseSystem.Diagnostics 5      T PMemoryControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=1e58ca7299ba3c32D2clr-namespace:MemoryControl;assembly=MemoryControlMemoryControl 5      C ?DllMeter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:DllMeter;assembly=DllMeterDllMeter 5	      J FUsePowerService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:UsePowerServiceUsePowerService 5
      ;"clr-namespace:UsePowerService.ViewUsePowerService.View 5      *   $UsePowerService.View.AllStationsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Ecb6clr-namespace:DllCoiledButton;assembly=DllCoiledButton     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Fdiag5clr-namespace:System.Diagnostics;assembly=WindowsBase     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Bmem2clr-namespace:MemoryControl;assembly=MemoryControl     5      :meter(clr-namespace:DllMeter;assembly=DllMeter     5	      /localclr-namespace:UsePowerService     5
      1vb"clr-namespace:UsePowerService.View     5      %  UsePowerService.View.WindowBase    Loaded$  Window_Loaded��5         Closing$ WindowBase_Closing��5       � Title$ Monitor All Stations��5      $	��620��6!   $
��1100��6.    � WindowStartupLocation$ CenterScreen=�5      
���   �.��5      �� 
����  �$��10q�6     �� CornerRadius$ 0��65   ._�5   
   � $��Center=�6   $	��Top=�6,    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $	��200 �6#   �� 5      $	��200 �6#   �� 5      $	��200 �6#   �� 5      $	��200 �6#    � RowDefinitions 5      �� 5      $	��150 �6    �� 5      $	��150 �6    �� 5      $	��150 �6    �� 5      $��20 �6    �� 5       $	��100 �6    .+�5$        DllMeter.SmartMeter  $��0��6   $��0��6/    
  Meter1#��[  6<      SM_Description$ Stn1 Surrey (MW)��5%      $!��meter:SmartMeter.SM_Command��5'   
   $��1��60      SM_MeterValue 5&      �� 	 �� Path$ 	 AllStations.Station1Source�5'   0     5)      $��1��6   $��0��6/   #��[  6<   $ Stn2 West Vancouver (MW)��5*      $!��meter:SmartMeter.SM_Command��5,   
   $��2��60    5+      �� $ 	 AllStations.Station2Source�5,   0     5.      $��2��6   $��0��6&   #��[  63   $ Stn3 North Vancouver (MW)��5/      $!��meter:SmartMeter.SM_Command��51   
   $��3��60    50      �� $ 	 AllStations.Station3Source�51   0     53      $��3��6   $��0��6/   #��[  6<   $! Stn4 Central Vancouver (MW)��54      $!��meter:SmartMeter.SM_Command��56   
   $��4��60    55      �� $ 	 AllStations.Station4Source�56   0     58      $��4��6   $��0��6/   #��[  6<   $ Stn5 South Burnaby (MW)��59      $!��meter:SmartMeter.SM_Command��5;   
   $��5��60    5:      �� $ 	 AllStations.Station5Source�5;   0     5>      $��0��6   $��1��6/   #��[  6<   $ Stn6 North Burnaby (MW)��5?      $!��meter:SmartMeter.SM_Command��5A   
   $��6��60    5@      �� $ 	 AllStations.Station6Source�5A   0     5C      $��1��6   $��1��6/   #��[  6<   $ Stn7 Port Moody (MW)��5D      $!��meter:SmartMeter.SM_Command��5F   
   $��7��60    5E      �� $ 	 AllStations.Station7Source�5F   0     5H      $��2��6   $��1��6/   #��[  6<   $ Stn8 Coquitlam (MW)��5I      $!��meter:SmartMeter.SM_Command��5K   
   $��8��60    5J      �� $ 	 AllStations.Station8Source�5K   0     5M      $��3��6   $��1��6/   #��[  6<   $ Stn9 Port Coquitlam (MW)��5N      $!��meter:SmartMeter.SM_Command��5P   
   $��9��60    5O      �� $ 	 AllStations.Station9Source�5P   0     5R      $��4��6   $��1��6/   #��[  6<   $ Stn10 Maple Ridge (MW)��5S      $!��meter:SmartMeter.SM_Command��5U   
   $��10��60    5T      �� $!	 AllStations.Station10Source�5U   0     5X      $��0��6   $��2��6/    
 Meter2#��[ 6<   $ Fuel Level (Gal)��5Y      
   
SM_Minimum$
 0Q�6A      
SM_Maximum$ 16Q�6P   $
 11.4Q�5Z        5\      $��1��6   $��2��6/   #��[ 6<   $ Oil Pressure (PSI)��5]      $
 0Q�6C   $ 40Q�6R      SM_Threshold$ 35Q�6b   $
 28.7Q�5^        5`      $��2��6   $��2��6/   #��[ 6<   $ Burgers in Mouth��5a      $
 0Q�6A   $ 10Q�6P   $	 7.5Q�6`   $ 2Q�5b        5d      $��3��6   $��2��6/   #��[ 6<   $ Miles per Gallon (MPG)��5e      $
 0Q�6G   $ 80Q�6V   $
 32.5Q�5f        5h      $��4��6   $��2��6/   #��[ 6<   $ Speed (MPH)��5i      $
 0Q�6<   $	 120Q�6K   $ 90Q�6\   $
 55.6Q�5j      �� 5m      $��10��6   $	��940��6$   $��0��60   $��3��6@   $��5��6M   
����  � �� RadiusX$ 10��6m    �� RadiusY$ 10��6z   �� 5q      -   5         ��Name$ Scroller��5q      $��0��6.   $��4��6>   $��2��6K   $	��380��6_   $
��Auto=�5r      $��Hidden=�6?   |�.  $��0 0 0 10q�5s   .   .��5t      �� -   5         ��Name$ 
txtMessage��5t      $
��Wrap=�60   
��� �����5u      ��  �� ElementName$ Scroller��$	 ViewportWidth���5v   1   �� $	 StatusMessage�5w      �� 5z       �� Orientation$ 
Horizontal=�6   $��2��62   $��4��6B   $��Center=�6O   $��Center=�6j   $��	11 0 0 15q�5{      ���#002200.+�5|      �� .+�5}      �� $	��140��6   $��Data Source Time��6(   $��15��6C   �� 5~      -   5         ��Name$ labTimeZone��5~      $	��140��61   $��16��6=   5      �� 5�      $��16��6=   ��6   �� $	 AllStations.CurrentHour�6=   �� 5�      $��16��6?   ��6   �� $	 AllStations.CurrentMinute�6?   �� 5�      $��17��6?   ��6   �� $	 AllStations.CurrentSecond�6?   5�      "   DllCoiledButton.CoiledButton  5�      -   5          Name$ 
QuitButton��5�      $��4��5�      $��4��6.    � ToolTip$ Exit the application��5�   	   $��Right=�5�      $��Bottom=�6:   $��0 0 0 20q�5�   	      CB_Width$	 140Q�6      	CB_Height$ 40Q�6*      CB_CoilColor$ Yellow��5�         CB_Foreground$ Yellow��5�   	      CB_Background$ #002200��6       CB_Text$
 Quit��5�   	   5�      5�      5�      