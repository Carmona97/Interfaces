   M S B A M L   `   `   `  ����M  IcalculadoraSalario, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:calculadoraSalariocalculadoraSalario  5   	   #    calculadoraSalario.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:calculadoraSalario     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   $	��500��65   $	��550��6E    � 	Resources 5	       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius J� Effect3  -System.Windows.Media.Effects.DropShadowEffect	   ShadowDepth
   	Direction   Opacity A�Name �� Stretch   
BlurRadius �� Triggers :� RoutedEvent �� 
TargetName �� TargetProperty	 �� To g� Duration	 t� To��%�  'd�       �� 5,   
   " d�6   .�5-      ��  � �� 5.      �� 5/      " d�6&   .R�50      (� .��51      �� $ Border��6%   $ 10��65   ���	#FFFFFFFF$��40��53      $��20��6(    54   "     55   &   $		 0.5Q�67   $
 0Q�6I   $	 0.3Q�6W   ._�57   "   A� $ Ellipse��6*   ���	#FFFFFFFF$ Uniform=�6L   $��2 1 2 1q�58   "   
�������$	��0.2��59   0   $��Stretch=�5:   "    5;   &     5<   *   $ 10Q�6;   $	 1Q�6K   $	 0.3Q�6[   $	
 260Q�6i   5>   #   5?      5@       5A      :� 5B      $ Checked��6+   .[�5C   "   �� .��5D   &   �� .��5E   *   �� $ Border��69   $1 +(Border.Background).(SolidColorBrush.Color)�5F   5    	#FF00008B5G   5   $ 0:0:0.1D�5H   5   t� 5I   *   $ Ellipse��6=   $ Margin�5J   9    20 1 2 15K   9   $ 0:0:0.1D�5L   9   5M   '   5N   #   5O      :� 5P      $ 	Unchecked��6+   .[�5Q   "   �� .��5R   &   �� .��5S   *   �� $ Border��69   $1 +(Border.Background).(SolidColorBrush.Color)�5T   5   	 White5U   5   $ 0:0:0.1D�5V   5   t� 5W   *   $ Ellipse��6=   $ Margin�5X   9    2 1 2 15Y   9   $ 0:0:0.1D�5Z   9   5[   '   5\   #   5]      5_      5a      5b      5f      .��5g      � ���	#FF676AE2$	��490��6"   $	��Top=�6/   $
��Left=�6G   $	��800��6b   .+�5h   
   �� $��Center=�6   $��39��61   $��	0,397,0,0q�6=   
����  �$	��Top=�6b   $	��157��6z   
�������$��3��6�   �� 5j   
   $��Center=�6   $	��312��61   $��0,10,0,0q�6>   
����  �$	��Top=�6b   $	��478��6z   ���	#FF9092EC$��3��6�    �� RadiusX$ 20��6�    �� RadiusY$ 20��6�    �� StrokeDashCap$ Round=�6�    �� StrokeEndLineCap$ Round=�6�   �� 5k   
   -   5         ��Name$ brutoTxt��5k      $
��Left=�6$   $��
408,39,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��153��6   $��18��6�   �� 5l   
   $��Salario bruto��6   $
��Left=�6(   $��
267,35,0,0q�6C   $	��Top=�6W   $��26��6o   $
��Bold"�6{   �� 5m   
   -   5        $ edadTxt��5m      $
��Left=�6#   $��
408,84,0,0q�6>   $
 Wrap=�6R   $	��Top=�6f   $	��153��6~   $��18��6�   �� 5n   
   $
��Edad��6   $
��Left=�6   $��
267,80,0,0q�6:   $	��Top=�6N   $��26��6f   $
��Bold"�6r   �� 5o   
   $��Número de pagas��6   $
��Left=�6*   $��267,130,0,0q�6E   $	��Top=�6Z   $��26��6r   $
��Bold"�6~   	� 5p   
   -   5         	�Name$ _12Radio��5p      $��12 pagas��6(   $
��Left=�6;   $��408,136,0,0q�6V   $	��Top=�6k   $��15��6�   	� 5q   
   -   5        $ _14Radio��5q      $��14 pagas��6(   $
��Left=�6;   $��494,136,0,0q�6V   $	��Top=�6k   $��15��6�   �� 5r   
   $��Situación familiar��6   $
��Left=�6-   $��267,177,0,0q�6H   $	��Top=�6]   $��26��6u   $
��Bold"�6�   �� 5s   
   -   5         ��Name$ familiaCombo��5s      $
��Left=�6)   $��408,177,0,0q�6D   $	��Top=�6Y   $	��153��6q   $��22��6}   6�   �� 5t   
   -   5         ��Name$ disponibleChk��5t      $��
Disponible��6*   $
��Left=�6?   $��441,230,0,0q�6Z   $	��Top=�6o   $��15��6�   �� 5u   
   $��Discapacidad��6   $
��Left=�6'   $��267,267,0,0q�6B   $	��Top=�6W   $��26��6o   $
��Bold"�6{   d� 5v   
   -   5         d�Name$ discapacidadBtn��5v      $��	Toggle Me��60   $��430,270,283,204q�6D   6]   �� 5w   
   $��Movilidad geográfica��6   $
��Left=�6/   $��267,224,0,0q�6J   $	��Top=�6_   $	��133��6w   $��27��6�   $
��Bold"�6�   �� 5x   
   -   5          ��Name$  calcularBtn��5x      $��CALCULAR��6&   $��Center=�69   $��	0,342,0,0q�6V   $	��Top=�6i   $��42��6�   $	��157��6�   ���	#FF9092EC$��3,3,3,3q�6�   ! J� RenderTransformOrigin$	! 5,5&�6�   �� 5y   
   -	   5        " ��Name$" SalarioNetoTxt��5y      $��Center=�6,   $��	0,409,0,0q�6I   $
��Wrap=�6\   $��Salario neto:��6p   $	��Top=�6�   $��15��6�   $	��112��6�   5{      5|      