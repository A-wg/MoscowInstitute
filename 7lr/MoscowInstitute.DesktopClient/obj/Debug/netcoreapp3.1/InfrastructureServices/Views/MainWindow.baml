   M S B A M L   `   `   `  ����X  TMoscowInstitute.DesktopClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MoscowInstitute.DesktopClientMoscowInstitute.DesktopClient  5   	   .    (MoscowInstitute.DesktopClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:MoscowInstitute.DesktopClient     5   	     � Title$  MoscowInstitute��5   	   $	��450��6!   $	��800��6.   .��5	      � $��Century Gothic)�6   $��14(�61    � ColumnDefinitions 5
   
   �� 5      $
��0.5* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��5q�6"   
���2͚�
���������6Z   �� *
Institutes+ �� SelectedItem 6}   �� *CurrentInstitute+��5      �� 5      .R�5      �� $��5q�6!   .+�5      �� $��14(�6$   $
��Wrap=�62   ��6F   ��  �� Path$ 	ShortName�5      5      5      �� 5   
   $��1��6    � DataContext 6%   �� *CurrentInstitute+.+�5      �� $��24(�6    �� Padding$ 2q�6&   $-��'Подробная информация��62   6P   �� 5      $ 2q�6   $
��Wrap=�6$   ��68   �� *	ShortName+6U   �� 5      $ 2q�6   $
��Wrap=�6$   ��68   �� *LegalAddress+6X   �� 5      $ 2q�6   $
��Wrap=�6$   ��68   �� *	WebSite+6S   �� 5      $ 2q�6   $
��Wrap=�6$   ��68   �� *	ChiefName+6U   5      5       5"      