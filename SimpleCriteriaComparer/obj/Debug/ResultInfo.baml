   M S B A M L   `   `   `  ����Z  VWPFToolkit.Extended, Version=1.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4R<clr-namespace:Xceed.Wpf.Toolkit;assembly=WPFToolkit.ExtendedXceed.Wpf.Toolkit  5   	   F BPieControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:PieControls;assembly=PieControlsPieControls 5   	   Q MSimpleCriteriaComparer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SimpleCriteriaComparerSimpleCriteriaComparer 5	   	   '   !SimpleCriteriaComparer.ResultInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Mxctk<clr-namespace:Xceed.Wpf.Toolkit;assembly=WPFToolkit.Extended     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >pie.clr-namespace:PieControls;assembly=PieControls     5   	   6local$clr-namespace:SimpleCriteriaComparer     5	   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Icon$0 */SimpleCriteriaComparer;component/Icon.ico��5   	    � Title$- 'Додаткова інформація��5   	   $��625.223��6&   $��1457.752��67   ���	#FF7C7C7C � 
ResizeMode$ NoResize=�6_   $��3q�6u   ���	#FF45B45E.��5      � -   5        $
��body��5      .+�5   
   �� -   5         ��Name$ startInstructions��5      $:��4Спектри переваг альтернатив��6+   $
��Left=�6Q   $	��Top=�6l   $��31��6�   $	��941��6�   
�������$��Arial Black)�6�   $��18(�6�   $
��Bold"�6�   $��	10,14,0,0q�6�   �� 5   
   -   5         ��Name$ about��5       K� ZIndex$ 2��6    $��Про програму��61   $
��Left=�6H   $��
989,36,0,0q�6c   $	��Top=�6w   $��90��6�   ���	#FF3E3C3C���	#FF3E3C3C
�������$��0q�6�   $��Arial)�6�   $��13(�6  $��21��6  6  �� 5   
   $��Disabled=�6   $��Visible=�6>   $
��1079��6f   $
��Left=�6s   .��5      �� -   5        $��Charts��5      $	��900��6#   $	��522��6/   $��
10,0,393,0q�6<   .+�5      �� 	 �� X1$ 0��6   	 �� Y1$	 480��6   		 �� X2$
	 1900��6'   	
 �� Y2$	
 480��61   $��8��6:   ���	#FF43A02E���	#FF5DBF386_   5      5      �� 5   
   -   5        $ continueWork��5   �   $	��200��6   $��50��6   $��241,52,1005,488q�6)   $��Arial Black)�6B   $/��)Продовжити ранжування��6[   $��Center=�6{   ���	#FF3E3C3C���	#FF3E3C3C
�������$��0q�6�   $
��Bold"�6  6M  �� 5   
   -   5        $ 	openTable��5   �   $	��200��6   $��50��6   $��5,45,1225,480q�6)   $��Arial Black)�6@   $%��Відкрити таблицю��6Y   $��Center=�6t   ���	#FF3E3C3C���	#FF3E3C3C
�������$��0q�6�   $
��Bold"�6�   6  �� 5   
   $��1084,36,10,55q�6   $	��500��6,   .+�5      �� $��Hidden=�6   $��77��6@   .��5      �� -   5        $��infoBox��5      $
��Wrap=�6+   
�������$��Arial)�6S   $��13(�6f   $��
37,0,20,20q�6t   $��70��6�   6�   5      �� 5      -	   5        $��allListsBox��5   #   $	��260��6   $��5q�66   
����������	#FF3E3C3C���	#FF3E3C3C$��3q�6�   $��Arial Black)�6�   $��14(�6�   6�   �� 5      -
   5        $��alternativeShow��5   �   $	��200��6   $��50��6!   $��10,20,10,10q�6-   $��Arial Black)�6B   $-��'Переглянути переваги��6[   ���	#FF3E3C3C���	#FF3E3C3C
�������$��0q�6�   $
��Bold"�6�   $��Center=�6�   6U  �� 5*      -   5        $��button1��5*   �   $	��200��6   $��50��6!   $��10,40,10,10q�6-   $��Arial Black)�6B   $+��%Зберегти результати��6[   $��Center=�6y   ���	#FF3E3C3C���	#FF3E3C3C
�������$��0q�6�   $
��Bold"�6  6?  �� 5+      $	��130��6   �� 5,      -   5        $��returnToMain��5,   �   $	��200��6   $��50��6!   $��10,20,10,10q�6-   $��Arial Black)�6B   $��Нова задача��6[   $��Center=�6q   ���	#FF3E3C3C���	#FF3E3C3C
�������$��0q�6�   $
��Bold"�6�   6A  5-      &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ dataGrid��5.      $
��Left=�6%   $��530,107,0,0q�6@   $	��Top=�6U   
���   �
�������
���   �$��2q�6�   $��Arial)�6�   $��16(�6�    J� Opacity$ 0Q�6�   5/      50      