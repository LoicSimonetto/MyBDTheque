   M S B A M L   `   `   `  ����W  SMyBDTheque.BackOffice.WPF.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Cclr-namespace:MyBDTheque.BackOffice.WPF.UI.MVVM.Views.BandeDessinee5MyBDTheque.BackOffice.WPF.UI.MVVM.Views.BandeDessinee  5      �Hclr-namespace:MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee:MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee  5      S    MMyBDTheque.BackOffice.WPF.UI.MVVM.Views.BandeDessinee.BandeDessineeEditViewUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      UlocalCclr-namespace:MyBDTheque.BackOffice.WPF.UI.MVVM.Views.BandeDessinee     5      ^	viewModelHclr-namespace:MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels.BandeDessinee     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $	��19* �6   �� 5      $	��61* �6    � RowDefinitions 5   
   �� 5      $	��45* �6   �� 5      $	��52* �6   �� 5      $	��50* �6   �� 5      $	��49* �6   �� 5      $	��53* �6   �� 5      $	��49* �6   �� 5      $	��38* �6   .+�5   
   �� $
��Left=�60   $��	10,10,0,0q�6K   $	��Top=�6^   $��26��6v   $��76��6�   ��6   �� *WindowTitle+6�   �� 5   
   $��Retour��6   $
��Left=�6F   $��	525,8,0,0q�6a   $	��Top=�6t   $��75��6�    J� RenderTransformOrigin$ 0.538,-2.507&�6�   $��6��6�   $��20��6�   $��1��6�   ��6"   �� *NavigateToIndex+6�   �� 5   
   $��Valider��6   $��1��6B   $
��Left=�6R   $��	426,8,0,0q�6m   $��6��6�   $	��Top=�6�   $��75��6�   ��6#   �� *
Validation+6�   �� 5   
   $��Titre��6   $
��Left=�6    $��	10,10,0,0q�6;   $��1��6N   $	��Top=�6[   $	��170��6s   �� 5   
   $��Série��6   $
��Left=�6    $��	10,14,0,0q�6;   $��2��6N   $	��Top=�6[   $	��170��6s   �� 5   
   $��Date de Sortie��6   $
��Left=�6)   $��	10,13,0,0q�6D   $��3��6W   $	��Top=�6d   $	��170��6|   �� 5    
   $
��Tome��6   $
��Left=�6   $��	10,17,0,0q�6:   $��4��6M   $	��Top=�6Z   $	��170��6r   �� 5!   
   $��Auteurs��6   $
��Left=�6"   $��	10,13,0,0q�6=   $��5��6P   $	��Top=�6]   $	��170��6u   �� 5"   
   $��1��6   $
��Left=�6"   $��23��6=   $��	28,13,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $	��Top=�6�   $	��284��6�   $��1��6�   ��6p   �� *
Bd.Titre+6�   �� 5#   
   $��1��6   $
��Left=�6"   $��23��6=   $��	28,17,0,0q�6I   $
 Wrap=�6\   $	��Top=�6�   $	��284��6�   $��2��6�   ��6p   �� *
Bd.Serie+6�   �� 5$   
   -   5        $��1��5$      $
��Left=�6"   $��23��6=   $��	28,20,0,0q�6I   $
 Wrap=�6\   $	��Top=�6�   $	��284��6�   $��4��6�   ��6p   �� *	Bd.Tome+6�   �� 5%   
   $��1��6   $
��Left=�6"   $��23��6=   $��	28,16,0,0q�6I   $
 Wrap=�6\   $	��Top=�6�   $	��284��6�   $��5��6�   ��6p   �� *
Bd.Auteurs+6�   (  "System.Windows.Controls.DatePicker  5&   
   $��1��6   $
��Left=�6N   $��	28,13,0,0q�6i   $��3��6|   $	��Top=�6�      SelectedDate 6%   �� *Bd.DateDeSortie+6�   5'      5(      