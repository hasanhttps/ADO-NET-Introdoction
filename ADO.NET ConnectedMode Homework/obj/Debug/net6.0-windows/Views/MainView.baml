   M S B A M L   `   `   `  ����Y  UADO.NET ConnectedMode Homework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:ADO.NET_ConnectedMode_Homework.Views$ADO.NET_ConnectedMode_Homework.Views  5   	   3    -ADO.NET_ConnectedMode_Homework.Views.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:ADO.NET_ConnectedMode_Homework.Views     5   	     � Title$  Library��5   	   $	��601��6   $
��1000��6&    � 
ResizeMode$ NoResize=�63   $	��601��6I   $
��1000��6Y    � WindowStartupLocation$ CenterScreen=�6i   .��5	      � .+�5
   
   ��    Background Image#��[  6   �� 5   
   .+�5      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $��200 45 0 120q�6J   .+�5      �� .+�5      �� $��
Categories��6    
�������$��20(�6E   $
��Bold"�6S   �� 5      -   5        $��CategoriesCB��5      $��25��63   $	��250��6?    �� SelectedItem 6K   �� *categoryname+ �� Mode$ TwoWay=�5      �� 5      $
��80 0q�6   .+�5      �� $��Authors��6    
�������$��20(�6B   $
��Bold"�6P   �� 5      -   5        $��	AuthorsCB��5      $��25��60   $	��250��6<   5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��textBox��5      $��25��6)   $	��860��65   $	��5 0q�6A   $��Center=�6N   .��6p    � 	Resources 5       �� 
TargetType �� Property	 �� Value��%�   '��       �� 5      " ��6    .�5      ��  �@��CornerRadius$	 3��6=   �� 5       � ��
	 �   �6<   �� 5       � ��$	 1q�6@   5       5!      .��6)   5"      �� 5$      $��25��6   $	��100��6%   $	��5 0q�61   $��Search��6>   
����������#C8AE7D���#765827��6�   �� *searchButtonCommand+��6�   �� 
 �� ElementName$
 textBox�� �� Path$
 Text� 5%      ��%�   '��       �� 5&      " ��6    .�5'      ��  �@��CornerRadius$	 3��6=   �� 5(       � ��	 �#7658276<   �� 5)       � ��$	 1q�6@   5*      5+      5,      5-      &   System.Windows.Controls.DataGrid  5/      -   5        $��	BooksGrid��5/         AutoGenerateColumns$
 True��6(   $
��0 10q�6C   $	��265��6�    6Q   �� *DataRowView+$ TwoWay=�6�   �� 51      $ 
Horizontal=�6   .+�52      �� $��25��6   $	��100��6%   $
��15 0q�61   $��Delete��6?   
����������#C8AE7D���#765827��6�   �� *deleteButtonCommand+ 53      ��%�   '��       �� 54      " ��6    .�55      ��  �@��CornerRadius$	 3��6=   �� 56       � ��	 �#7658276<   �� 57       � ��$	 1q�6@   58      59      5:      �� 5<      $��25��6   $	��100��6%   $
��15 0q�61   $��Insert��6?   
����������#C8AE7D���#765827��6�   �� *insertButtonCommand+ 5=      ��%�   '��       �� 5>      " ��6    .�5?      ��  �@��CornerRadius$	 3��6=   �� 5@       � ��	 �#7658276<   �� 5A       � ��$	 1q�6@   5B      5C      5D      5E      5F      5H      5I      