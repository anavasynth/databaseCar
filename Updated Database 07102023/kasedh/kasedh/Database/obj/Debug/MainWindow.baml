   M S B A M L   `   `   `  ����C  ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DatabaseDatabase  5   	       Database.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Database     5   	     � Title$-  'Довідник автомобілів��5   	   $	��850��6&   $
��1237��63   .��5
      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ 	AddButton��5      $��Додати��6$   $
��Left=�65   $��64��6P   $��
930,40,0,0q�6\   $	��Top=�6p   $	��222��6�   $��20(�6�   $��Arial Black)�6�   ���	#7FB5A9A96�   �� 5   
   -   5        $ ShowButton_��5      $��Переглянути��6&   $
��Left=�6<   $��64��6W   $��930,120,0,0q�6c   $	��Top=�6x   $	��222��6�   $��20(�6�   $��Arial Black)�6�   ���	#7FB5A9A96�   �� 5   
   -   5        $ 
EditButton��5      $��Редагувати��6%   $
��Left=�6:   $��64��6U   $��930,202,0,0q�6a   $	��Top=�6v   $	��222��6�   $��20(�6�   $��Arial Black)�6�   ���	#83B5A9A96�   �� 5   
   -   5        $ DeleteButton��5      $��Видалити��6'   $
��Left=�6:   $��64��6U   $��930,284,0,0q�6a   $	��Top=�6v   $	��222��6�   $��20(�6�   $��Arial Black)�6�   ���	#7FB5A9A96�   �� 5   
   -   5        $ GuideButton��5      $-��'Посібник користувача��6&   $
��Left=�6E   $��64��6`   $��818,729,0,0q�6l   $	��Top=�6�   $	��366��6�   $��20(�6�   $��Arial Black)�6�   ���	#7FB5A9A96�   �� 5   
   -   5         ��Name$ CarListView��5      $
��Left=�6'   $	��385��6B   $��	52,32,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��516��6�   ���	#BFFFFFFF6�   �� 5   
   $
��Left=�6   $	��328��60   $��
52,454,0,0q�6=   $	��Top=�6Q   $	��516��6i   ���	#BFAFAFAF6u   �� 5   
   $��
Марка��6   $
��Left=�6    $��
58,462,0,0q�6;   $	��Top=�6O   $��36��6g   ���	#00802A2A$��16(�6�   �� 5   
   -   5        $ brandTextBox��5      $
��Left=�6(   $��
58,495,0,0q�6C   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��156��6�   $��23��6�   �� 5   
   -   5        $ FindCar��5      $��Знайти��6"   $
��Left=�63   $��23��6N   $��228,495,0,0q�6Z   $	��Top=�6o   $��82��6�   6�   �� 5   
   -	   5         ��Name$ searchResultListView��5      $��70,72,669,468q�6\    �� View 5      �� 5      .P�5      �� 5      5      �� 5   
   -
   5        $ FindElectroCar��5      $3��-Відобразити електрокари��6)   $
��Left=�6K   $��32��6f   $��
58,676,0,0q�6r   $	��Top=�6�   $	��169��6�   6�   �� 5    
   -   5        $ FindCarByYearRange��5       $��Знайти��6-   $
��Left=�6>   $��23��6Y   $��
58,624,0,0q�6e   $	��Top=�6y   $	��145��6�   6�   �� 5!   
   -   5        $ 
startYearT��5!      $
��Left=�6&   $��
58,596,0,0q�6A   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $��67��6�   $��23��6�   �� 5"   
   -   5        $ endYearT��5"      $
��Left=�6$   $��136,596,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $��67��6�   $��23��6�   �� 5#   
   $��
Марка��6   $
��Left=�6    $��
58,462,0,0q�6;   $	��Top=�6O   $��36��6g   ���	#00802A2A$��16(�6�   �� 5$   
   $��Від��6   $
��Left=�6   $��
58,571,0,0q�69   $	��Top=�6M   $��36��6e   ���	#00802A2A$��12(�6�   �� 5%   
   $
��До��6   $
��Left=�6   $��137,571,0,0q�68   $	��Top=�6M   $��25��6e   ���	#00802A2A$��12(�6�   �� 5&   
   $��Рік випуску��6   $
��Left=�6&   $��
58,541,0,0q�6A   $	��Top=�6U   $��34��6m   ���	#00802A2A$��16(�6�   �� 5'   
   -   5        $ FindCarByMileageRange��5'      $��Знайти��60   $
��Left=�6A   $��23��6\   $��249,624,0,0q�6h   $	��Top=�6}   $	��145��6�   6�   �� 5(   
   -   5        $ startMileageT��5(      $
��Left=�6)   $��249,596,0,0q�6D   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $��67��6�   $��23��6�   �� 5)   
   -   5        $ endMileageT��5)      $
��Left=�6'   $��327,596,0,0q�6B   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $��67��6�   $��23��6�   �� 5*   
   $��Від��6   $
��Left=�6   $��249,571,0,0q�69   $	��Top=�6N   $��36��6f   ���	#00802A2A$��12(�6�   �� 5+   
   $
��До��6   $
��Left=�6   $��328,571,0,0q�68   $	��Top=�6M   $��25��6e   ���	#00802A2A$��12(�6�   �� 5,   
   $��Пробіг��6   $
��Left=�6!   $��249,541,0,0q�6<   $	��Top=�6Q   $��34��6i   ���	#00802A2A$��16(�6�   �� 5-   
   -   5        $ SearchSportsCarsByPower��5-      $/��)Відобразити спорткари��62   $
��Left=�6R   $��32��6m   $��
58,717,0,0q�6y   $	��Top=�6�   $	��169��6�   6�   5.      5/      