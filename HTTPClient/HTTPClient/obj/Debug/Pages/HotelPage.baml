   M S B A M L   `   `   `  ����E  AHTTPClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HTTPClient.PagesHTTPClient.Pages  5           HTTPClient.Pages.HotelPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      *localclr-namespace:HTTPClient.Pages  5        N� Title$  	HotelPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   ]� ��.  .+�5      �� -   5        $��
buttonBack��5      $	��100��5      $��
Назад��5      $y�	Collapsed=�5      $
��Left=�5      5      � 5   
   -   5         �Name$ gridCheckRequest��5      
�������$y�Visible=�5       $��1��5!       5"      �� 5#      $��* �6    �� 5$      $
��auto �6    �� 5%      $��* �6     � ColumnDefinitions 5'      �� 5(      $��* �6#   �� 5)      $
��auto �6#   �� 5*      $��* �6#   .+�5,      ��  �� Orientation$ Vertical=�5-      $��1��5.      $��1��5/      $	��200��50      .+�51      �� -   5        $ ��buttonGetCheckRequestHotel��52      $0��*Поличить список отелей��53      $��0,0,0,10q�54      55      �� 56      -   5        $!��buttonPostCheckRequestHotel��57      $,��&Добавить новый отель��58      59      5:      5;      � 5>   
   -   5        $ gridGetRequest��5A      
�������$y�	Collapsed=�5@      $��1��5B      .+�5C      �� -   5         ��Name$ listViewResponse��5D       �� View 5F      �� 5G      .P�5H      ��  �� DisplayMemberBinding 6)   ��  �� Path$ id�.��6R   Id6V   �� 5I       6)   �� $
 Name�.��6T   Name6Z   �� 5J      	 �� CellTemplate	 5K      �� 5L   "   .R�5M   &   �� 
 ��Name$
 buttonInformationItem��5N   )   -   5        $��Информация��5O   )   5P   )   5Q   #   5S      �� 5T      	 5U      �� 5V   "   .R�5W   &   �� $
 buttonEditItem��5X   )   -   5        $��Изменить��5Y   )   5Z   )   5[   #   5]      �� 5^      	 5_      �� 5`   "   .R�5a   &   �� $
 buttonDeleteItem��5b   )   -	   5        $��Удалить��5c   )   5d   )   5e   #   5g      5h      5j      5k      � 5m   
   -
   5        $ gridPostRequest��5n      
�������$y�	Collapsed=�5p      $��1��5q       5r      �� 5s      $��* �6    �� 5t      $
��auto �6    �� 5u      $��* �6     5w      �� 5x      $��* �6#   �� 5y      $
��auto �6#   �� 5z      $��* �6#   .+�5|      �� $ Vertical=�5}      $��1��5~      $��1��5      $	��100��5�      .+�5�      �� -   5        $��textBoxPostRequestHotel��5�      $��0,0,0,10q�5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��5�      �� 5�      -   5        $��buttonPostRequestHotel��5�      $��Добавить��5�      5�      5�      5�      5�      5�      