   M S B A M L   `   `   `  ����   StudentGradeManagementSystem5    /StudentGradeManagementSystem.StudentControlPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  StudentControlPage��5   	   $	��512��6$   $	��804��61   .��5      � .+�5   
   �� $��1-121230094953.jpg��6   $
��Fill=�6,   &   System.Windows.Controls.DataGrid  5	   
   -   5          Name$ 	dataGrid2��5	         AutoGenerateColumns .     CanUserAddRows .  $��60,80,466,157q�6Z    J� RenderTransformOrigin$ 	0.5,1.122&�6q      
IsReadOnly . ��5
      �� 5       �� Color$ 	#FFF0F0F0��6"    �� Opacity$	 0.2Q�64      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	SubjectID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 70 68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *	subjectID+ �� UpdateSourceTrigger$ PropertyChanged=�  5      $	 SubjectName��6%   $
 90 6:    6E   �� *subjectName+$ PropertyChanged=�  5      $	 Grade��6%   $
 50 64    6?   �� *score+$ PropertyChanged=�  5      $	 Credit��6%   $
 50 65    6@   �� *credit+$ PropertyChanged=�  5      $	 SubjectType��6&   $
 50 6;    6F   �� *subjectType+$ PropertyChanged=�5      �� 5   
   -   5         ��Name$ discription��5      $
��Left=�6'   $	��229��6B   $��
375,95,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��310��6�   
���   �.��6�   ��5      �� 5      $ White��6"   $ 0Q�60   .��5   "   5      �� 5   
   $
��Left=�6   $��
375,15,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $	��340��6o   $��80��6{   �� 6�    � Language$ zh-cn�6�   $���If you have any questions about your grade ,you can write the problems on the follwing textbox and press the button "CreateReport" to make a document(.doc).Then send it by email.(The email adress is 1078018710@qq.com)��6�   6�  �� 5   
   -   5        $��CreateReport��5      $
��Left=�6(   $��600,340,0,0q�6C   $	��Top=�6X   $��85��6p   ��5      �� 5      $ 	#FFDDDDDD��6"   $ 0Q�64   5      �� 5    
   -   5        $��OK��5       $
��Left=�6   $��
235,46,0,0q�69   $	��Top=�6M   $��85��6e   $��24��6�   ��5!      �� 5"      $ 	#FFDDDDDD��6"   $ 0Q�64   5$      �� 5%   
   -   5        $ InputStudentID��5%      $
��Left=�6*   $��23��6E   $��	60,46,0,0q�6Q   $
 Wrap=�6d   $	��Top=�6x   $	��155��6�   .��6�   ��5&      �� 5'      $ White��6"   $ 0Q�60   .��5(   "   5)      �� 5*   
   -   5         ��Name$ ad��5*      $�� ��6   $
��Left=�6'   $��305,390,0,0q�6B   $	��Top=�6W   $��65��6o   5,      5-      