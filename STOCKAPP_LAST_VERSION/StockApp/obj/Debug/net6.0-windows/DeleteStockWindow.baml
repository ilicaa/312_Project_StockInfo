   M S B A M L   `   `   `  ����  StockApp     StockApp.DeleteStockWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Delete Stock��5   	   $	��300��6   $	��400��6+   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $	��15* �6   �� 5      $	��53* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Stock Name:��6   $��0��6&   $��0��63   $��Center=�6C   �� 5   
   -   5         ��Name$ StockNameTextBox��5      $��0��6,   $��1��69   $	��200��6I   $��5q�6U   6`   �� 5   
   -   5         ��Name$ DeleteButton��5      $��Delete��6'   $��1��68   $��0��6E   $��	43,5,0,10q�6U   $	��100��6h   $
��Left=�6t   $��2��6�   �� 5   
   -   5        $ CancelButton��5      $��Cancel��6'   $��1��68   $��1��6E   $��
148,5,0,10q�6U   $	��100��6i   $
��Left=�6u   6�   �� 5   
   -   5        $ BackToDashboardButton��5      $��Back to Dashboard��60   $��2��6L   $��2��6Y   $��
22,52,0,92q�6m   $	��336��6�   $
��Left=�6�   6�   5      5!      