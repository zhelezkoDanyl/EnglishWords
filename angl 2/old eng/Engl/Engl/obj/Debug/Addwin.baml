   M S B A M L   `   `   `  ����?  ;Engl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Engl.ENUMS
Engl.ENUMS  5   
   /clr-namespace:Engl.OperationEngl.Operation  5   	       Engl.Addwin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'enclr-namespace:Engl.ENUMS     5   
   2	converterclr-namespace:Engl.Operation     5   	   -   5          �Name$	  add��5   	    � Title$ Addwin��5	   	   $	��650��6   $	��400��6%   $	��650��65   $	��650��6A    � 	Resources 5
         Engl.ENUMS.AzzA   pos   Engl.Operation.ViewModel  VMod��%>   &	        &	        5   
   6      5   
   5   1   5      .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF99520C��6    � Offset$ 0Q�61   � 5      $ 	#FFDEAD56��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      -   5         ��Name$ Table��5      $��* �6+   	 � ContextMenu	 5      �� 5      5       �� 5!      -   5        $ infoitem��5!      $	��250 �6.   .+�5%   
   #  Engl.Operation.MyFirstControl  -   5        
  Name$
 myFirstControl1��5&         Data 5'      ��  �� ElementName$ PartOfSpeechCOM�� �� Path$ SelectedIndex�5*      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$
 data��5-      $��0��6!   $��0��6.      
IsReadOnly .    AutoGenerateColumns . $��10,10,10,10q�6k   ���	#FFDAC6A2��6�   ��  �� Source# [ $ DatagridList�5/      �� 51   
   -   5         ��Name$ PartOfSpeechCOM��51      $
��Left=�6-   $��	24,38,0,0q�6H   $��1��6\   $	��Top=�6i   $	��120��6�    �� SelectedIndex$ 0��6�   ��6�   �� # [  $ parOfsp�6�   �� 52   
   -   5        $ PodPunk��52      $
��Left=�6$   $��
183,38,0,0q�6?   $��1��6S   $	��Top=�6`   $	��120��6x   {�6�   �� $ PartOfSpeechCOM��$ SelectedIndex�6�   �� 53   
   -   5        $ topic��53      $
��Left=�6"   $��
353,38,0,0q�6=   $��1��6Q   $	��Top=�6^   $	��120��6v   $ 0��6�   ��6�   �� # [  $
 Tema�6�   �� 54   
   -	   5         ��Name$ id��54      {�.  $
��Left=�60   $��23��6K   $��	85,89,0,0q�6W   $��1��6j    �� TextWrapping$
 Wrap=�6w   $�� ��6�   $	��Top=�6�   $��59��6�   �� 55   
   -
   5        $ En��55      $
��Left=�68   $��23��6S   $��
183,89,0,0q�6_   $��1��6s   $
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��120��6�    J� RenderTransformOrigin$ 0.475,-0.826&�6�   �� 56   
   -   5        $ Ru��56      $
��Left=�68   $��23��6S   $��
353,87,0,0q�6_   $��1��6s   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 57   
   -   5        $ RuSinon��57      $
��Left=�6#   $��23��6>   $��353,140,0,0q�6J   $��1��6_   $
 Wrap=�6l   $	��Top=�6�   $	��120��6�   �� 58   
   -   5        $ EnSinon��58      $
��Left=�6#   $��23��6>   $��183,140,0,0q�6J   $��1��6_   $
 Wrap=�6l   $	��Top=�6�   $	��120��6�   �� 59   
   -   5        $ Form2��59      {�. $
��Left=�62   $��23��6M   $��183,198,0,0q�6Y   $��1��6n   $
 Wrap=�6{   $	��Top=�6�   $	��120��6�   �� 5:   
   -   5        $ form3��5:      $
��Left=�6!   $��23��6<   $��353,199,0,0q�6H   $��1��6]   $
 Wrap=�6j   $	��Top=�6�   $	��120��6�   �� 5;   
   -   5         ��Name$	 ADD��5;      $	��ADD��60   $
��Left=�6>   $��
517,73,0,0q�6Y   $��1��6m   $	��Top=�6z   $��75��6�   ���	#FFDAC6A26�   �� 5<   
   -   5        $ UpDate��5<      $��UpDate��66   $
��Left=�6G   $��517,103,0,0q�6b   $��1��6w   $	��Top=�6�   $��75��6�   ���	#FFDAC6A26�   �� 5=   
   -   5        $ DELETE��5=      $��Delete��66   $
��Left=�6G   $��517,140,0,0q�6b   $��1��6w   $	��Top=�6�   $��75��6�   ���	#FFDAC6A26�   �� 5>   
   -   5         ��Name$ FindOfFiltr��5>      $ ��Отфильтровать��6(   $
��Left=�6   $��
507,42,0,0q�6�   $��1��6�   $	��Top=�6�   $ 0.355,0.692&�6�   $	��104��6�   �� 5?   
   -   5        $ Clear��5?      $��Clear��6    $
��Left=�60   $��517,175,0,0q�6K   $��1��6`   $	��Top=�6m   $��75��6�   $ 0.547,1&�6�   ���	#FFDAC6A26�   �� 5@   
   -   5         ��Name$ label��5@      $*��$Part of speech (Части речи)��6   $
��Left=�6E   $��	10,10,0,0q�6`   $��1��6s   $	��Top=�6�   $	��147��6�   �� 5A   
   -   5        $ label1��5A      $)��#Subparagraphs (Под Пункты)��6    $
��Left=�6E   $��
173,10,0,0q�6`   $��1��6t   $	��Top=�6�   $	��165��6�   �� 5B   
   -   5        $ label2��5B      $��Topic (Тематика)��6    $
��Left=�6;   $��
353,10,0,0q�6V   $��1��6j   $	��Top=�6w   $	��120��6�   �� 5C   
   -   5        $ label3��5C      $	��ID ��6    $
��Left=�6.   $��	24,89,0,0q�6I   $��1��6\   $	��Top=�6i   $��47��6�   �� 5D   
   -   5        $ label4��5D      $��En��6    $
��Left=�6-   $��
183,59,0,0q�6H   $��1��6\   $	��Top=�6i   �� 5E   
   -   5        $ label5��5E      $��Ru��6    $
��Left=�6-   $��
353,59,0,0q�6H   $��1��6\   $	��Top=�6i   $ 
3.13,0.348&�6�   �� 5F   
   -   5        $ label6��5F      $#��Synonyms(Синонимы)-->��6    $
��Left=�6@   $��
24,140,0,0q�6[   $��1��6o   $	��Top=�6|   $	��147��6�   �� 5G   
   -   5        $ label7��5G      $��Foms of verbs(Формы)��6    $
��Left=�6?   $��
24,196,0,0q�6Z   $��1��6n   $	��Top=�6{   $	��133��6�   �� 5H   
   -   5        $ label8��5H      $��
Synonym En��6    $
��Left=�65   $��185,112,0,0q�6P   $��1��6e   $	��Top=�6r   $	��104��6�   �� 5I   
   -   5        $ label9��5I      $��
Synonym Ru��6    $
��Left=�65   $��343,117,0,0q�6P   $��1��6e   $	��Top=�6r   $	��103��6�   �� 5J   
   -   5        $ label10��5J      $��Form2��6!   $
��Left=�61   $��183,175,0,0q�6L   $��1��6a   $	��Top=�6n   $	��104��6�   �� 5K   
   -    5        $ label11��5K      $��Form3��6!   $
��Left=�61   $��353,176,0,0q�6L   $��1��6a   $	��Top=�6n   $	��116��6�   �� 5L   
   -!   5        $ Ok��5L      $��Ok��6   $
��Left=�6*   $��517,208,0,0q�6E   $��1��6Z   $	��Top=�6g   $��75��6   ���	#FFDAC6A26�   �� 5M   
   -"   5        $ label12��5M      $
��Left=�6!   $��	586,5,0,0q�6r   $��1��6�   $	��Top=�6�   $��28��6�   $��46��6�   ��6<   �� $
 data��$ Items.Count�5O      5R      5S      