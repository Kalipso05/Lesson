   M S B A M L   `   `   `  ����B  >Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Desktop.ViewDesktop.View  5   	   %    Desktop.View.EmployeeEditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Desktop.View     5   	     � Title$  EmployeeEditWindow��5   	   $	��450��6$   $	��800��61   .��5	      �� $��2q�6   
�������$	��400��64   $	��400��6@    �� CornerRadius$ 10��6M   ._�5
   
   �� $��15q�6   .+�5      �� $��Фотография��6   $
��Bold"�6*   
���   �6<   �� 5      -   5        $+��%Выберите фотографию��5      $	��348��63      RoundedButtonStyle#��[  6?   6k   �� 5      $��Имя��6   $
��Bold"�6#   
���   �65   �� 5      -   5         ��Name$ txbName��5      $	��347��6'   {�.  63   �� 5      $��Фамилия��6   $
��Bold"�6'   
���   �69   �� 5      -   5        $ 
txbSurname��5      $	��347��6*   {�.  66   �� 5      $��Отчество��6   $
��Bold"�6(   
���   �6:   �� 5      -   5        $ txbPatronymic��5      $	��347��6-   {�.  69   �� 5      $ ��Подразделение��6   $
��Bold"�6-   
���   �6?   �� 5      -   5         ��Name$ cmbSelectDivision��5      $	��347��62   �� 5      $��Должность��6   $
��Bold"�6)   
���   �6;   �� 5      -   5        $ cmbSelectPosition��5      $	��347��62    �� SelectedIndex$ 1��6>   �� 5      -   5        $��Сохранить��5      $��25q�6)   #��[  65   6a   5      5      5       