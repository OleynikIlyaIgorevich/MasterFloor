   M S B A M L   `   `   `  ����N  JMasterFloor.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:MasterFloor.Desktop.ConvertersMasterFloor.Desktop.Converters  5      K*clr-namespace:MasterFloor.Desktop.EntitiesMasterFloor.Desktop.Entities  5      9!clr-namespace:MasterFloor.DesktopMasterFloor.Desktop  5      ,    &MasterFloor.Desktop.Windows.MainWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      C
converters,clr-namespace:MasterFloor.Desktop.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?entities*clr-namespace:MasterFloor.Desktop.Entities     5      3local!clr-namespace:MasterFloor.Desktop     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	        � Title$*  $Партнеры Мастер Пол��5
      $	��700��5      $	��600��5      $	��700��5      $	��600��5      ���#F4E8D3 � Icon$ ../Images/app_icon.ico��5       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5      C   =MasterFloor.Desktop.Converters.SaleByPartnerProductsConverter 	  SBPPC��%   &	          5   
   64   5      .��5      � $��10,15q�6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $
��6.5* �6   �� 5      $
��1.5* �6   .+�5   
   �� $��Center=�6   .+�5       �� $��50��5!      $��50��5"      $��../Images/app_icon.ico��5#      �� 5$      $��Center=�5%      $��24(�5&      $
��Bold"�5'      ���#67BA80$��Мастер пол��5)      5*      �� 5,   
   -   5         ��Name$ 
PartnersLV��5-      $��1��5.      $��10,15q�5/      ��50      �� 51       �� DataType*   $MasterFloor.Desktop.Entities.Partner"  6   .R�52      ��  �� Padding$ 25,20q�53      
���   �$��1q�55      ._�56      �  � ColumnDefinitions 57      �� 58   "   $��7* �63   �� 59   "   $��3* �63   .+�5;      �� .+�5<   "   �� 	 �� Orientation$	 
Horizontal=�6-   .+�5=   &   �� $��16(�5>   )   $��SemiBold"�5?   )   ��5@   )   �� *PartnerType.Title+�� 5A   &   $��4��60   $y�Hidden=�6:   �� 5B   &   $��16(�5C   )   $��SemiBold"�5D   )   $��|��5E   )   �� 5F   &   $��4��60   $y�Hidden=�6:   �� 5G   &   $��16(�5H   )   $��SemiBold"�5I   )   ��5J   )   �� *Title+5K   #   �� 5M   "   $	 
Horizontal=�6-   .+�5N   &   �� ��60   �� *DirectorLastname+�� 5O   &   $��4��60   $y�Hidden=�6:   �� 5P   &   ��60   �� *DirectorFirstname+�� 5Q   &   $��4��60   $y�Hidden=�6:   �� 5R   &   ��60   �� *DirectorMiddlename+5S   #   �� 5U   "   ��6,   �� *Phone+
 �� StringFormat$
 +7 {0}���� 5V   "   ��6,   �� *Rate+$
 Рейтинг: {0}��5X      �� 5[      $��1��5\   !   $��Center=�5]   !   $��16(�5^   !   ��5_   !   �� *PartnerProducts+ �� 	Converter# [  5`      5a      5b      ��5d      �� 5e       �� 
TargetType" ��6   .�5f      ��  �� Property � �� �� Value$ Stretch=�6C   5g      5i      � 5k   
   $��2��6    5m      �� 5n      �� 5o      .+�5r      �� $��Center=�6   $	 
Horizontal=�64   .+�5s      �� -   5        $��5q�5t      ���#67BA80$
��Bold"�5w      ���#FFFFFF.��5y      ��  �� Padding$ 10,15q�6    $W��QПосмотреть историю реализованной продукции��60   5z      5{      �� 5}      $��1��5~      $��Right=�5      $��Center=�5�      $	 
Horizontal=�5�      .+�5�      �� -   5        $��5q�5�      ���#67BA80$
��Bold"�5�      ���#FFFFFF.��5�      �� $ 10,15q�6    $1��+Редактировать партнера��60   5�      �� 5�      -   5        $��5q�5�      ���#67BA80$
��Bold"�5�      ���#FFFFFF.��5�      �� $ 10,15q�6    $%��Создать партнера��60   5�      5�      5�      5�      5�      