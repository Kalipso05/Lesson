   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DesktopDesktop  5   	       Desktop.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Desktop     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��333* �6   �� 5      $
��101* �6    � ColumnDefinitions 5   
   �� 5      $
��397* �6   �� 5      $
��403* �6   .+�5   
   � $��1��6   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $'��!Обновить страницу��5         RoundedButtonStyle#��[  65   $��10q�6|   $	��185��6�   $��30��6�   �� 5      -   5        $)��#Добавить работника��5      #��[  66   $��10q�6|   $	��177��6�   $��30��6�   5      5      � 5   
   $��1��6   $��1��6   .+�5      �� -   5         ��Name$ listView��5      ��5      �� 5      .R�5       �� 
�������$��1q�64    �� Padding$ 5q�6H   $��5q�6T   ._�5!      �� $ 
Horizontal=�6)   .+�5"   "   �� $��50��6D   $��50��6O   $��0, 0, 10, 0q�6[   ��6(   �� *
FilePath+6[   �� 5#   "   $ Vertical=�6-   .+�5$   &   �� $
��Bold"�60   �� 5%   *   �6.   �� *	Surname+ �� 5&   *   $� ��6.    �� 5'   *   �6.   �� *Name+ �� 5(   *   $� ��6.    �� 5)   *   �6.   �� *
Patronymic+5*   '   �� 5+   &   $��
0, 0, 0, 0q�60   �� 5,   *   $�Должность: ��6.    �� 5-   *   �6.   �� *
Position+5.   '   5/   #   50      51      52       � ContextMenu 54      �� 55      .@�56      m� -   5        $ ��Редактировать��56   #   6:   m� 57      -   5        $��Удалить��57   #   64   58      5:      5;      5=      5>      