   M S B A M L   `   `   `  ????R  NDataAnalysisApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:DataAnalysisApplicationDataAnalysisApplication  5   	   a5clr-namespace:DataAnalysisApplication.MVVM.ViewModels'DataAnalysisApplication.MVVM.ViewModels  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   0    *DataAnalysisApplication.DataAnalysisWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:DataAnalysisApplication     5   	   Dvm5clr-namespace:DataAnalysisApplication.MVVM.ViewModels     5   	   Glchart4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -   5          ? Title$  DataAnalysis??5
   	   $	??710??6   $
??1200??6+   $
??1200??6O   $	??710??6_    ? DataContext 5      I  CDataAnalysisApplication.MVVM.ViewModels.DataAnalysisWindowViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??2* ?6   ?? 5      $??3* ?6    ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      $??1* ?6   .+?5   
   ?? $-??'Список пользователей??6   $??0??5      $??0??5      $
??auto??5      $
??auto??5       ?? TextAlignment$ Center=?5      $??Center=?5      $??Arial)?5      $??16(?5      $??Medium"?5       ?? 5!   
   $E???График по выбранному пользователю??6   $??1??5"      $??0??5#      $
??auto??5$      $
??auto??5%      $ Center=?5&      $??Center=?5'      $??Arial)?5(      $??16(?5)      $??Medium"?5*      ?? 5+   
   $??1??6   $??0??5,      .+?5-      &   System.Windows.Controls.DataGrid  $	??559??6      AutoGenerateColumns .  $??Center=?51      $	??457??52      $??10q?53       ?? SelectedItem 5.      ?? *SelectedItem+ ?? Mode$ Twoway=? ?? UpdateSourceTrigger$ PropertyChanged=???5/      ?? *Users+$ TwoWay=?$ PropertyChanged=?	   RowStyle	 54      ?? 55      
 ?? 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .?56      ??  ?? Property ? ?? ?? Value
 ?????67    ?? Triggers 57      ?? 58       ?? Binding 6*   ?? *
IsDiffer+$ TwoWay=?$ PropertyChanged=? ?? Value true6w   .a?59   "   ??  ? ??
 ? ???6?   5:      5<         Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   ??  ?? Path$
 User?$ TwoWay=?$ PropertyChanged=?  5@      $ Средние шаги??6)   $ 90 6?    6J   ?? $ AverageSteps?$ TwoWay=?$ PropertyChanged=?  5A      $ Лучший??6)   $ 80 69    6D   ?? $ 
BestResult?$ TwoWay=?$ PropertyChanged=?  5B      $ Худший??6)   $ 1* 69    6D   ?? $ WorseResult?$ TwoWay=?$ PropertyChanged=?  5C      $ IsDiffer??6)      
Visibility$ Hidden=?6?    6;   ?? $ IsDiffer?$ TwoWay=?$ PropertyChanged=?6?   5E      ?? 5F      $
??auto??6   $??40??5G      $
??10,0q?5H      $T??NЭкспорт данных по выбранному пользователю??5I      $??18(?5J      ??5K      ?? *SelectedUserExportCommand+5L      ? 5M   
   $??1??6   $??1??6   $??10q?6,   .+?5N      #  LiveCharts.Wpf.CartesianChart  &	   LiveCharts.Wpf.Charts.Base.Chart 	  ZoomingSpeed$ -1Q?6$    	  DisableAnimations .  	  DataTooltip 5O      #
  LiveCharts.Wpf.DefaultTooltip
  5P      ???#233055
???????6A    	  AxisX 5S        LiveCharts.Wpf.Axis     MinValue$ 1Q?6"      
ShowLabels .     MaxValue 60   ?? *Days+$ TwoWay=?$ PropertyChanged=?   	Separator 5T        LiveCharts.Wpf.Separator  5U         StrokeThickness$ 0Q?6/   5W       	  AxisY 5Z        $ 0Q?6"    6/   ?? *
MaxSteps+$ TwoWay=?$ PropertyChanged=? 5[        5\      $ 1Q?6/   5^        	  Series  5a        LiveCharts.Wpf.LineSeries    LiveCharts.Wpf.Series!   Stroke
! ??  ?"   StrokeThickness$" 2Q?6:   #   
DataLabels# .  $   PointGeometrySize$$ 15Q?6  %   Values% 6N   ?? *SineGraphValues+$ OneWay=?$ PropertyChanged=?&   Configuration& 6?   ?? *Mapper+$ TwoWay=?$ PropertyChanged=?6  5c      5e      5g      5h      