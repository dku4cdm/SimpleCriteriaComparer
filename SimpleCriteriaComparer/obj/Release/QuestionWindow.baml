   M S B A M L   `   `   `  ���� Q  MSimpleCriteriaComparer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SimpleCriteriaComparerSimpleCriteriaComparer  +    %SimpleCriteriaComparer.QuestionWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:SimpleCriteriaComparer     -     � WindowStartupLocation$  CenterScreen=� � Icon$0 */SimpleCriteriaComparer;component/Icon.ico�� � Title$ Ранжування ��$	��690��$	��790�����	#FF3E3C3C � 
ResizeMode$ NoResize=�$��3q����	#FF45B45E.��� -   $
��body��.+��� -    ��Name$ about�� K� ZIndex$ 2��$��Про програму��$��Right=�$��
10,10,10,0q�$	��Top=�$��90�����	#FF3E3C3C���	#FF3E3C3C���	#FF45B45E$��0q�$��Arial)�$��13(�$��21���� -    ��Name$ 	startInfo��$�� ��$
��Left=�$	��Top=�$	��590��$	��778�����	#FF45B45E$��Arial Black)�$��18(����	#FF05914B$��3q�� .+�A� -   $��
mainCircle��
�������$��246,59,-439,-371q�$ -2�� J� Clip ��  �� Rect$ -70, -70, 550, 550���
� .��� 	 � Color$	 	#FFB20000��
 � Offset$
 0Q�� $	 	#FFFBABAB��$
 1Q�� $	 	#FFE20A0A��$
 0.233Q�� $	 	#FFDC2121��$

 0.44Q�� $	 	#FFD85353��$

 0.61Q�� $	 	#FFD10707��$
 0.117Q�� $	 	#FFDA1919��$
 0.363Q�� $	 	#FFF07676��$

 0.76Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$	 100Q�   Color$ 
WhiteSmoke���� -   $ nextBtn��$+��%Наступне ранжування��$
��Left=�$��530,600,0,0q�$	��Top=�$	��220�����	#FF3E3C3C���	#FF3E3C3C���	#FF45B45E$��0q�$��Arial Black)�$��14(�$��36�� J� RenderTransformOrigin$ 
1.07,4.337&��� -   $ previousStepBtn��$-��'Попереднє ранжування��$
��Left=�$��260,600,0,0q�$	��Top=�$	��237�����	#FF3E3C3C���	#FF3E3C3C���	#FF45B45E$��0q�$��Arial Black)�$��14(�$��36���� -   $ stopBtn��$+��%Проміжні результати��$
��Left=�$��
35,600,0,0q�$	��Top=�$	��200�����	#FF3E3C3C���	#FF3E3C3C���	#FF45B45E$��0q�$��Arial Black)�$��14(�$��36���� -	   $��alternativesPanel��$
��Left=�$	��135��$��	10,61,0,0q�$	��Top=�$	��232���� -
   $��drawingArea��$
��Left=�$	��480��$��247,61,13,64q�$	��Top=�$	��480��A� $
��Left=�$	��888��$	��Top=�$	��896��
���   �$��1��$��
274,83,0,0q�
 � Tag$ 20�� �� $ 0, 0, 452, 456�A� $
��Left=�$	��864��$	��Top=�$	��864��
���   �$��1��$��294,107,0,0q�$ 10�� �� $ 0, 0, 432, 432�A� $
��Left=�$	��816��$	��Top=�$	��816��
���   �$��1��$��318,132,0,0q�$ 20�� �� $ 0, 0, 408, 407�A� $
��Left=�$	��768��$	��Top=�$	��768��
���   �$��1��$��342,155,0,0q�$ 5�� �� $ 0, 0, 384, 384�A� $
��Left=�$	��720��$	��Top=�$	��720��
���   �$��1��$��366,177,0,0q�$ 20�� �� $ 0, 0, 360, 362�A� $
��Left=�$	��672��$	��Top=�$	��672��
���   �$��1��$��390,203,0,0q�$ 10�� �� $ 0, 0, 336, 336�A� $
��Left=�$	��628��$	��Top=�$	��628��
���   �$��1��$��413,228,0,0q�$ 20�� �� $ 0, 0, 313, 311�A� $
��Left=�$	��576��$	��Top=�$	��576��
���   �$��1��$��438,251,0,0q�$ 5�� �� $ 0, 0, 288, 288�A� $
��Left=�$	��528��$	��Top=�$	��528��
���   �$��1��$��462,275,0,0q�$ 20�� �� $ 0, 0, 264, 264�A� $
��Left=�$	��480��$	��Top=�$	��480��
���   �$��1��$��485,299,0,0q�$ 10�� �� $ 0, 0, 240, 240�A� $
��Left=�$	��432��$	��Top=�$	��432��
���   �$��1��$��510,322,0,0q�$ 20�� �� $ 0, 0, 216, 216�A� $
��Left=�$	��384��$	��Top=�$	��384��
���   �$��1��$��534,346,0,0q�$ 5�� �� $ 0, 0, 192, 192�A� $
��Left=�$	��336��$	��Top=�$	��366��
���   �$��1��$��558,370,0,0q�$ 20�� �� $ 0, 0, 168, 168�A� $
��Left=�$	��288��$	��Top=�$	��288��
���   �$��1��$��582,395,0,0q�$ 10�� �� $ 0, 0, 144, 144�A� $
��Left=�$	��240��$	��Top=�$	��240��
���   �$��1��$��606,418,0,0q�$ 20�� �� $ 0, 0, 120, 120�A� $
��Left=�$	��192��$	��Top=�$	��192��
���   �$��1��$��630,444,0,0q�$ 5�� �� $ 0, 0, 96, 96�A� $
��Left=�$	��144��$	��Top=�$	��144��
���   �$��1��$��654,467,-20,0q�$ 20�� �� $ 0, 0, 72, 72�A� $
��Left=�$��96��$	��Top=�$��96��
���   �$��1��$��678,491,0,0q�$ 10�� �� $ 0, 0, 48, 48�A� $
��Left=�$��48��$	��Top=�$��48��
���   �$��1��$��702,515,0,0q�$ 20�� �� $ 0, 0, 24, 24��� -   $��tooltip�����	#FF45B45E$��3q�$��10,196,522,228q� J� Opacity$ 1Q�._��� $��Hidden=�.���� -   $��infoBox��$
��Wrap=�
�������$��Arial)�$��13(�$	��225���� -   $��AdditionalInfo��$��10,444,536,93q�$ 1Q�._�� $��10,351,489,121q�.+��� $��25��$'��!Значення переваги��$��Arial)�$��15(�
�������$��5,-317,-150,292q��� -   $��curCoord��$��40��$��25��$�� ��$��Arial)�$��15(�
�������$��170,-317,-210,292q��� $	��120��$
��Wrap=�$N��HКількість градацій якості альтернатив:��$��Arial)�$��13(�
�������$��5,-267,-125,233q��� -    ��Name$ gradationCombobox��$��130,-267,-194,233q����	#FF45B45E���	#FF3E3C3C���	#FF3E3C3C$��3q� �� IsDropDownOpen .   �� 
IsReadOnly . $��64��$��Arial Black)�$��13(�$
��Bold"��� $��25��$&�� Є суперечливість?��$��Arial)�$��15(�
�������$��5,-292,-150,267q��� -   $��
isConflict��$��40��$��25��$�� ��$��Arial Black)�$��15(�
�������$��170,-292,-210,267q��� -   $��progressInfo��$��40��$��25��$�� ��$��Arial)�$��15(�
�������$��170,-342,-210,317q��� -   $��stepInfo��$��25��$%��Номер ранжування��$��Arial)�$��15(�
�������$��5,-342,-150,317q�