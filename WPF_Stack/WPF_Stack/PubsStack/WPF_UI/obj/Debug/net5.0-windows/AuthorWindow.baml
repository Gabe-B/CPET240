   M S B A M L   `   `   `  ����A  =WPF_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPF_UIWPF_UI  5   	       WPF_UI.AuthorWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WPF_UI     5   	     � Title$  Author Info��5   	   $	��725��6   $	��980��6*   .��5	      � .+�5      �� $
��auto��6   .��5      �� -   5         ��Name$ StackPanelOuter��5       �� Orientation$ Vertical=�5      .+�5   	   �� -   5        $ StackPanelInnerInfo1��5      $ 
Horizontal=�5      .+�5   
   �� -   5         ��Name$ LabelUserName��5      $��
First Name��5      $
��Left=�6)   $��0 10 0 0q�5      �� 5   
   -   5         ��Name$ TextBoxUserName��5      $��20��5      $	��150��5      $��0 10 0 0q�5      ��5      �� *
au_fname+5      �� 5   
   -   5        $ LabelLastName��5      $��	Last Name��5      $
��Left=�6)   $��0 10 0 0q�5      �� 5   
   -   5        $ TextBoxLastName��5      $��20��5!      $	��150��5"      $��0 10 0 0q�5#      ��5       �� *
au_lname+5#      �� 5%   
   -   5        $ LabelPhoneNum��5%      $��Phone Number��5&      $
��Left=�6,   $��0 10 0 0q�5'      �� 5(   
   -   5        $ TextBoxPhoneNum��5(      $��20��5*      $	��110��5+      $��0 10 0 0q�5,      ��5)      �� *
au_phone+5,      5-   
   �� 50   	   -	   5        $ StackPanelInnerInfo2��50      $ 
Horizontal=�51      .+�52   
   �� -
   5        $ LabelAddress��52      $��Address��53      $
��Left=�6'   $��0 10 0 0q�54      �� 55   
   -   5        $ TextBoxAddress��55      $��20��57      $	��140��58      $��0 10 0 0q�59      ��56      �� *
au_address+59      �� 5;   
   -   5        $ 	LabelCity��5;      $
��City��5<      $
��Left=�6$   $��0 10 0 0q�5=      �� 5>   
   -   5        $ TextBoxCity��5>      $��20��5@      $	��140��5A      $��0 10 0 0q�5B      ��5?      �� *	au_city+5B      �� 5D   
   -   5        $ 
LabelState��5D      $��State��5E      $
��Left=�6%   $��0 10 0 0q�5F      �� 5G      -   5        $��StateComboBox��5G      $��60��6   $��20��60   $��0 10 0 0q�6<   5H      �� 5O   
   -   5        $ LabelZIP��5O      $	��ZIP��5P      $
��Left=�6#   $��0 10 0 0q�5Q      �� 5R   
   -   5        $ 
TextBoxZIP��5R      $��20��5T      $��60��5U      $��0 10 0 0q�5V      ��5S      �� *au_zip+5V      �� 5X   
   -   5        $ LabelContract��5X      $��Contract��5Y      $
��Left=�6(   $��0 10 0 0q�5Z      �� 5[   
   -   5        $ TextBoxContract��5[      $��20��5]      $��35��5^      $��0 10 0 0q�5_      ��5\      �� *au_contract+5_      5`   
   �� 5c   	   -   5        $ StackPanelInnerPassword��5c      $ 
Horizontal=�5d      5f      �� 5h      -   5        $$ StackPanelInnerConfirmPassword��5h      $ 
Horizontal=�5i      5k      �� 5m      $ 
Horizontal=�6   $
��Left=�66   .+�5t      �� -   5         ��Name$ btnOk��5t      $��Bottom=�6,   $��5q�6G   $��75��6S   $��23��6^   .��6   Ok6�   �� 5u      -   5        $ 	btnCancel��5u      $��Bottom=�60   $��5q�6K   $��75��6V   $��23��6a   .��6�   Cancel6�   5v      �� 5y   	   -   5        $ StackPanelBooks��5y      $ 
Horizontal=�5z      .+�5{   
   &   System.Windows.Controls.DataGrid  -   5          Name$ AUBooksGrid��5{         AutoGenerateColumns$ False��5|   )      HeadersVisibility$ Column=�6E   	 J� RenderTransformOrigin$	 0.502,0.683&�5}   )   $
��Left=�6M   
   Columns
 5~      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Title ID #��6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *
title_id+ �� Mode$ OneWay=�  5�      $ Title��6    6.   �� *title+$ OneWay=�  5�      $
 Type��6    6-   �� *type+$ OneWay=�  5�      $ Publisher ID��6    65   �� *publisher.pub_id+$ OneWay=�  5�      $ Publisher Name��6    67   �� *publisher.pub_name+$ OneWay=�  5�      $ Price��6    6.   �� *price+$ OneWay=�  5�      $ 	YTD Sales��6    62   �� *	ytd_sales+$ OneWay=�  5�      $ Publish Date��6    65   �� *	pubdate+$ OneWay=�5�      5�   
   �� 5�   	   $ 
Horizontal=�6   $
��Left=�6-   .+�5�   
   �� -   5        $ 	btnRemove��5�      $��25��6$   $
��auto��60   $��5q�6=   .��6`   Remove Book From Author6y   5�   
   �� 5�   	   -   5        $ StackPanelAllBooks��5�      $ 
Horizontal=�5�      .+�5�   
     -   5        $ AllBooksGrid��5�      $ False��5�   )   $ Column=�6E   $	 0.502,0.683&�5�   )   $
��Left=�6M   
 5�        5�      $ 
Title ID #��6    63   �� *
title_id+$ OneWay=�  5�      $ Title��6    6.   �� *title+$ OneWay=�  5�      $
 Type��6    6-   �� *type+$ OneWay=�  5�      $ Publisher ID��6    65   �� *publisher.pub_id+$ OneWay=�  5�      $ Publisher Name��6    67   �� *publisher.pub_name+$ OneWay=�  5�      $ Price��6    6.   �� *price+$ OneWay=�  5�      $ 	YTD Sales��6    62   �� *	ytd_sales+$ OneWay=�  5�      $ Publish Date��6    65   �� *	pubdate+$ OneWay=�5�      5�   
   �� 5�   	   $ 
Horizontal=�6   $
��Left=�6-   .+�5�   
   �� -   5        $ btnAdd��5�      $��25��6!   $
��auto��6-   $��5q�6:   .��6Z   Add Book to Author6n   5�   
   5�   	   5�      5�      5�      