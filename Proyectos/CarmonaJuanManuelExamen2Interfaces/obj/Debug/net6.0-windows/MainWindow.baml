   M S B A M L   `   `   `  ����]  YCarmonaJuanManuelExamen2Interfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CarmonaJuanManuelExamen2Interfaces"CarmonaJuanManuelExamen2Interfaces  5   	   3    -CarmonaJuanManuelExamen2Interfaces.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:CarmonaJuanManuelExamen2Interfaces     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��900��6)   $	��900��65   $	��500��6D   .��5	      � $��0,5,0,-5q�6    � RowDefinitions 5
   
   �� 5      $
��150* �6   �� 5      $
��300* �6    � ColumnDefinitions 5   
   �� 5      $
��300* �6   �� 5      $
��300* �6   .+�5   
   �� -   5         ��Name$ divisaOrigen��5      $��
225,23,8,8q�6+   .+�5      �� $��Seleccione su moneda:��6   $��35��64   $��Center=�6@   	� 5      -   5         	�Name$ 	radioEuro��5      $
��Euro��6-   $��31��6<   $��Center=�6H   	� 5      -   5        $ 
radioDolar��5      $��Dólar��6.   $��28��6>   $��Center=�6J   5      � 5   
   -   5         �Name$ monedas��5      $��
42,10,42,0q�6    $��1��64    5      �� 5      $	��10* �6#   �� 5      $	��10* �6#   �� 5      $	��10* �6#   .+�5      �� -   5         ��Name$ chRusia��5      $��
Rublo ruso��6(   $
��Left=�6=   $��	22,45,0,0q�6X   $	��Top=�6k   �� 5       -   5        $ 
chLituania��5       $��Litas lituano��6+   $
��Left=�6C   $��	22,75,0,0q�6^   $	��Top=�6q   �� 5!      $/��)Seleccione las divisas de la conversión:��6   $
��Left=�6G   $��
101,10,0,0q�6b   $	��Top=�6v   $��3��6�   �� 5"      -   5        $ chEuro��5"      $
��Euro��6'   $
��Left=�66   $��
22,101,0,0q�6Q   $	��Top=�6e   �� 5#      -   5        $ chCheca��5#      $��1��6(   $��Corona checa��68   $
��Left=�6O   $��	10,45,0,0q�6j   $	��Top=�6}   �� 5$      -	   5        $ chDanesa��5$      $��1��6)   $��Corona danesa��69   $
��Left=�6Q   $��	10,72,0,0q�6l   $	��Top=�6   �� 5%      -
   5        $ 	chNoruega��5%      $��1��6*   $��Corona noruega��6:   $
��Left=�6S   $��
10,105,0,0q�6n   $	��Top=�6�   �� 5&      -   5        $ chSuiza��5&      $��2��6(   $��Franco suizo��68   $
��Left=�6O   $��	14,45,0,0q�6j   $	��Top=�6}   �� 5'      -   5        $ chLibra��5'      $��2��6(   $��Libra��68   $
��Left=�6H   $��	14,72,0,0q�6c   $	��Top=�6v   �� 5(      -   5        $ chLira��5(      $��2��6'   $��
Lira turca��67   $
��Left=�6L   $��
14,105,0,0q�6g   $	��Top=�6{   5)      �� 5+   
   -   5        $
 pago��5+      $��30,142,0,167q�6#   $��2��69   .+�5,      �� $��Elija su método de pago:��6   $��Center=�67   $��37��6T   	� 5-      -   5        $ radioEfectivo��5-      $��Efectivo��61   $��32��6D   $��Center=�6P   	� 5.      -   5        $ radioTransferencia��5.      $��Transferencia��66   $��37��6N   $��Center=�6Z   	� 5/      -   5        $ radioTarjeta��5/      $��Tarjeta��60   $��38��6B   $��Center=�6N   50      �� 51   
   $��1��6   $��30,156,10,26q�6"   .+�52      �� -   5        $ chkDescuento��52      $��	Descuento��6-   $��Center=�6A   $��0,0,0,20q�6^   �� 53      -   5        $��CALCULAR��53      $	��154��6(   $��33��64   6@   �� 54      -   5        $��RESET��54      $	��155��6%   $��0,10,0,0q�61   $��34��6C   6O   55      �� 56   
   $��55,27,230,8q�6   .+�57      �� $��Seleccione cantidad:��6   $��Center=�63   $��48��6P   �� 58      -   5         ��Name$ txtCantidad��58       �� TextWrapping$
 Wrap=�6+   $	��120��6?   $��23��6K   
���   �6W   59      �� 5:   
   -   5        	 ��Name$	 listaDivisas��5:      $��1��6*   $
��Left=�6:   $��	10,10,0,0q�6U   $��1��6h   $
��Wrap=�6u   $	��Top=�6�   $	��287��6�   $	��408��6�   �� 5;   
   
���   �$��1q�6%   $��1��69   $��0,161,42,60q�6I   $��2��6^   5>      5?      