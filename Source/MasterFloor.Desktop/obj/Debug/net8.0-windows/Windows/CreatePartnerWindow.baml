   M S B A M L   `   `   `  ����N  JMasterFloor.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MasterFloor.Desktop.WindowsMasterFloor.Desktop.Windows  5      5    /MasterFloor.Desktop.Windows.CreatePartnerWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:MasterFloor.Desktop.Windows     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$9  3Создать партнера Мастер Пол��5      $	��700��5	      $	��600��5
      $	��700��5      $	��600��5      ���#F4E8D3 � Icon$ ../Images/app_icon.ico��5       � WindowStartupLocation$ CenterScreen=�5      .��5      � $��10,15q�6    � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $
��7.5* �6   �� 5      $��1* �6   .+�5   
   �� $��Center=�5      $��Center=�5      $��24(�5      $
��Bold"�5      ���#67BA80$'��!Создание партнера��5      �� 5    
   $��1��6   $
��Auto=�6$   .��5!      �� $��10,15q�6   .+�5"      �� $��Тип партнера��6   �� 5#      -   5         ��Name$ PartnerTypeCB��5$       �� DisplayMemberPath$ Title��5%       �� 
IsEditable$
 True��5&       �� 
IsReadOnly$
 True��5'       �� Text$. (Выберите тип партнера��5(      �� 5*      $'��!Название партнера��6   �� 5+      -   5        	 ��Name$	 TitleTB��5+      �� 5-      $'��!Фамилия директора��6   �� 5.      -   5        $	 DirectorLastnameTB��5.      �� 50      $��Имя директора��6   �� 51      -   5        $	 DirectorFirstnameTB��51      �� 53      $A��;Отчество директора (при наличии)��6   �� 54      -   5        $	 DirectorMiddlenameTB��54      �� 56      $��Эл. почта��6   �� 57      -   5        $	 EmailTB��57      �� 59      $B��<Номер телефона (без первой цифры)��6   �� 5:      -   5        $	 PhoneTB��5:      �� 5<      $��Адресс��6   �� 5=      -   5        $	 	AddressTB��5=      �� 5?      $��ИНН��6   �� 5@      -	   5        $	 InnTB��5@      �� 5B      $��Рейтинг��6   �� 5C      -
   5        $	 RateTB��5C      5D      5E      �� 5G   
   -   5        $��2��5H      ���#67BA80$
��Bold"�5K      ���#FFFFFF.��5M      �� 
 �� Padding$
 10,15q�6   $%��Создать партнера��6(   5N      5O      5P      