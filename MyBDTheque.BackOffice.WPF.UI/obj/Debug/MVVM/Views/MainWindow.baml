   M S B A M L   `   `   `  ����W  SMyBDTheque.BackOffice.WPF.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MyBDTheque.BackOffice.WPF.UIMyBDTheque.BackOffice.WPF.UI  5   	   k:clr-namespace:MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels,MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels  5   	   8    2MyBDTheque.BackOffice.WPF.UI.MVVM.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:MyBDTheque.BackOffice.WPF.UI     5   	   Q
viewModels:clr-namespace:MyBDTheque.BackOffice.WPF.UI.MVVM.ViewModels     5   	   $	��450��5
   '   $	��800��64     � Title  6	   �� *WindowTitle+.��5      �  � RowDefinitions 5   
   �� 5      $	��83* �6   �� 5      $
��336* �6   .+�5   
   �� $��1,1,1,1q�6   
���   �6+   ]� 5   
   $��0q�6   .+�5      �� $��Bandes Dessinées��6   $	��103��6i   $
��Left=�6u   $��20q�6�   ��61   �� *%#NavigateToBandeDessineeIndexCommand+6�   �� 5      $��Séries��6   $	��103��6'   $
��Left=�63   $��20q�6N   �� 5      $��Auteurs��6   $	��103��6(   $
��Left=�64   $��20q�6O   �� 5      $��22��6   $
��Wrap=�6$   $��Center=�6U   $��Right=�6p   $��
70,30,0,31q�6�   $��71��6�   ��68   �� *Utilisateur+6�   �� 5      $��Déconnexion��6   $��Right=�6K   $��87��6g   $��20q�6r    J� RenderTransformOrigin$ 0.755,0.512&�6~   ��6+   �� *Deconnexion+6~   5      �� 5   
   $��1,1,1,1q�6   
���   �$��1��6r   ��6G   �� *Navigation.CurrentView+6r   5      5      