   M S B A M L   `   `   `  ����H  DStudentManage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:StudentManage.VimeStudentManage.Vime  5      +    %StudentManage.Vime.FrmAddStudentInfor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:StudentManage.Vime     5      .��5	      � ��5
   
   �� 5        �� ImageSource$  /img/bg/stuBg.jpg��6    j� Stretch$
 Fill=�69   6K    � ColumnDefinitions 5   
   �� 5      $��8 �6   6+   �� 5      $��* �6   6+   �� 5      $��8 �6   6+    � RowDefinitions 5   
   �� 5      $��8 �6   6)   �� 5      $��* �6   6)   �� 5      $��8 �6   6)   .+�5   
   � $��1��6   $��1��6   
������� J� Opacity$
 0.85Q�6?    5      �� 5      $��40 �6#   60   �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   �� 5       6%   �� 5!      6%   �� 5"      6%   �� 5#      6%   �� 5$      $��40 �6#   60    5&      �� 5'      $��40 �6    6.   �� 5(      6"   �� 5)      6"   �� 5*      6"   �� 5+      6"   �� 5,      6"   �� 5-      6"   �� 5.      6"   �� 5/      6"   �� 50      $��40 �6    6.   .+�52      �� $��1��6   $��1��6"   $��3��62   $��3��6C   $	��160��6W   $	��190��6c   
������$��3q�6�   $��0,0,0,0q�6�   ._�53      �� -   5         ��Name$ stuImg��53      $��UniformToFill=�6(   6B   54      � 55      $��4��6   $��1��6    $��2��60   $��3��6A   .+�56      �� -   5        $��
btnTakePic��56      $	��100��6E   $��35��6Q   $��	0,-50,0,0q�6]   .��57      ]� .+�58      �� $��/img/ico/pai.ico��6    $��25��6:   $��25��6E   6S   �� 59      $��拍照图片��6    61   5:      5;      �� 5<      -   5        $��btnLocalPic��5<      $	��100��6F   $��35��6R   $��0,40,0,0q�6^   .��5=      ]� .+�5>      �� $��/img/ico/ben.ico��6    $��25��6:   $��25��6E   6S   �� 5?      $��本地照片��6    61   5@      5A      5B      �� 5C      $��1��6   $��4��6!   $��2��61   $�� 姓  名：��6E   $��20(�6V   $��楷体)�6d   $��Center=�6t   $��Center=�6�   6�   �� 5D      -   5         ��Name$ textName��5D      $��1��6H   $��6��6U   $��4��6e   
����� �$��2q�6�   $	��180��6�   $�� ��6�   $��20(�6�   $��Center=�6�   $
��Left=�6�   6�   �� 5E      $��2��6   $��4��6!   $��2��61   $��性  别：��6E   $��Center=�6U   $��Center=�6p   $��楷体)�6�   $��20(�6�   6�   	� 5F      -   5         	�Name$ radBoy��5F      $��2��6*   $��6��67   $��Center=�6G   $
��Left=�6b    d� 	IsChecked$
 TrueY�6}   $	��男��6�   $��20(�6�   6�   	� 5G      -   5        $ radGirl��5G      $��2��6+   $��7��68   $��Center=�6H   $
��Left=�6c   $	��女��6   $��20(�6�   6�   �� 5H      $��3��6   $��4��6!   $��2��61   $��   身份证号：��6E   $��20(�6X   $��楷体)�6f   $��Center=�6w   $��Center=�6�   6�   �� 5I      -   5        $ textStuNubIDcard��5I      $��3��6X   $��6��6e   $��4��6u   $	��230��6�   $�� ��6�   $��Center=�6�   $
��Left=�6�   
����� �$��2q�6�   $��20(�6�   6  �� 5J      $��4��6   $��4��6!   $��
生 日：��62   $��20(�6A   $��楷体)�6P   $��Center=�6`   $��Center=�6{   6�   �� 5K      -   5        	 ��Name$	 labBirthday��5K      $��4��6)   $��5��66   $��3��6F   $��20(�6Z   
�������$��2q�6{   $	��160��6�   $�� ��6�   $��Center=�6�   $
��Left=�6�   6�   �� 5L      $��4��6   $��8��6!   $��
年 龄：��62   $��20(�6A   $��楷体)�6P   $��Center=�6`   $��Center=�6{   6�   �� 5M      -	   5        $	 labAge��5M      $��4��6$   $��9��61   $��2��6A   $�� ��6U   $	��100��6`   
�������$��2q�6�   $��20(�6�   $��Center=�6�   $
��Left=�6�   6�   �� 5N      $��5��6   $��4��6!   $��2��61   $��
班 级：��6E   $��20(�6T   $��楷体)�6c   $��Center=�6s   $��Center=�6�   $��11.6,13.2,47.6,15.2q�6�   6�   �� 5O      -
   5        
 ��Name$
 combstuClass��5O      $��5��6-   $��5��6:   $��3��6K   $	��185��6`   $��20(�6m   
������$��Center=�6�   $
��Left=�6�   $��22,12.2,0,18.2q�6�   6�   �� 5P      $��5��6   $��8��6!   $��2��61   $��	卡号：��6E   $��20(�6S   $��楷体)�6b   $��Center=�6r   $
��Left=�6�   6�   �� 5Q      -   5        $ textClockNo��5Q      $��5��6O   $��9��6\   $��2��6l   $	��120��6�   $�� ��6�   
����� �$��2q�6�   $��20(�6�   $��Center=�6�   $
��Left=�6�   6  �� 5R      $��6��6   $��4��6!   $��2��61   $��   手机号：��6E   $��20(�6W   $��Center=�6e   $��Center=�6�   6�   �� 5S      -   5        $ textPhonNumb��5S      $��6��6O   $��6��6\   $��4��6l   
����� �$��2q�6�   $	��230��6�   $�� ��6�   $��Center=�6�   $
��Left=�6�   $��20(�6�   6  �� 5U      $��7��6   $��4��6!   $��2��61   $��   地     址：��6E   $��20(�6[   $��Center=�6i   $��Center=�6�   6�   �� 5V      -   5        $ textAdderss��5V      $��7��6M   $��6��6Z   $��4��6j   
����� �$��2q�6�   $	��230��6�   $�� ��6�   $��Center=�6�   $
��Left=�6�   $��20(�6�   .��6  6  �� 5W      -   5         ��Name$ 	btnAffirm��5W      $��8��6@   $��3��6M   $��3��6]   $��50��6q   $	��150��6}   .��5X      ]� .+�5Y      �� $��/img/ico/sure.ico��6   $��20��67   6E   �� 5Z      $��确定添加��6   $��23(�6+   $��楷体)�69   6K   5[      5\      �� 5]      -   5        $ 	btnCancle��5]      $��8��6@   $��6��6M   $��3��6]   $��50��6q   $	��150��6}   .��5^      ]� .+�5_      �� $��/img/ico/cacle.ico��6   $��20��68   6F   �� 5`      $��取消添加��6   $��23(�6+   $��楷体)�69   6K   5a      5b      5c      5d      5e      