   M S B A M L   `   `   `  ����Q  MSimpleCriteriaComparer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SimpleCriteriaComparerSimpleCriteriaComparer  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   '    !SimpleCriteriaComparer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:SimpleCriteriaComparer     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � Icon$0 */SimpleCriteriaComparer;component/Icon.ico��5
   	    � Title$ ТеГР��5   	   $��451.98��6   $��924.433��6&   ���	#FF3E3C3C � 
ResizeMode$ NoResize=�6M   $��3q�6c   ���	#FF45B45E.��5      � .+�5   
   �� -   5        $��toolTipInfo��5      $
��Wrap=�6'   
�������$��Arial)�6O   $��16(�6b   $��10,285,402,10q�6p   6�   �� 5   
   -   5         ��Name$ 	startInfo��5      $7��1Введіть назви альтернатив:��6#    J� Opacity$	 0.3Q�6H   $
��Left=�6V   $��	527,0,0,0q�6q   $	��Top=�6�   $	��418��6�   $	��385��6�   ���	#FF45B45E$��Arial Black)�6�   $��16(�6�   ���	#FF05914B$��3q�6  �� 5   
   -   5        $ toolTipLabel��5      $.��(Додаткова інформація:��6&   $
��Left=�6F   $��	0,246,0,0q�6a   $	��Top=�6t   $	��172��6�   $	��527��6�   ���	#FF45B45E$��Arial Black)�6�   $��18(�6�   ���	#FF05914B$��3q�6�   $
��Bold"�6  �� 5   
   -   5        $ startInstructions��5      $b��\Оберіть кількість альтернатив та градацій якості:��6+   $
��Left=�6g   $	��Top=�6�   $	��126��6�   $	��527��6�   ���	#FF45B45E$��Arial Black)�6�   $��18(�6�   ���	#FF05914B$��3q�6	  $
��Bold"�6  �� 5   
   -   5         ��Name$ startBtn��5      $	 0.3Q�6#   $'��!Почати ранжування��61   $
��Left=�6M   $��138,143,0,0q�6h   $	��Top=�6}   $	��228��6�   ���	#FF3E3C3C���	#FF3E3C3C���	#FF45B45E$��0q�6�   $��Arial Black)�6�   $��18(�6  $��86��6"  6c  �� 5   
   -   5         ��Name$ numberCombobox��5      ���	#FF45B45E���	#FF3E3C3C���	#FF3E3C3C$��3q�6q   $��0,51,667,332q�6�    �� IsDropDownOpen .  	 �� 
IsReadOnly	 . $��Right=�6�   $��60��6�   $��Arial Black)�6�   $��16(�6  $
��Bold"�6  �� 5   
   -   5        $ gradationCombobox��5      ���	#FF45B45E���	#FF3E3C3C���	#FF3E3C3C$��3q�6u   $��0,51,390,332q�6�    .  	 . $��Right=�6�   $��60��6�   $��Arial Black)�6�   $��16(�6	  $
��Bold"�6  �� 5   
   -	   5        $ alternatives��5      $&�� К-сть альтернатив��6&   $
��Left=�6B   $��	10,51,0,0q�6]   $	��Top=�6p   $��35��6�   $	��161��6�   ���	#FF45B45E$��Arial Black)�6�   $��14(�6�   ���	#FF05914B$��3q�6�   6&  �� 5   
   -
   5        $ 	gradation��5      $-��'К-сть градацій якості��6#   $
��Left=�6C   $��
267,51,0,0q�6^   $	��Top=�6r   $��35��6�   $	��181��6�   ���	#FF45B45E$��Arial Black)�6�   $��14(�6�   ���	#FF05914B$��3q�6�   6(  �� 5   
   -   5        $��alternativesOnStackPanel��5      $
��Left=�65   $	��372��6P   $	��Top=�6]   $	��370��6u   $��
532,36,0,0q�6�   5      5      