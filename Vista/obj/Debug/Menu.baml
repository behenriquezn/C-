   M S B A M L   `   `   `  ����@  <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	   	   F BToggleClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:ToggleClass;assembly=ToggleClassToggleClass 5
   	       
Vista.Menu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Vista     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5	   	   @ToggleClass.clr-namespace:ToggleClass;assembly=ToggleClass  5
   	     � Title$,  &                                 MENÚ��5   	   $	��460��67   $��332.949��6D    � WindowStartupLocation$ CenterScreen=�6T    � 
ResizeMode$ NoResize=�6y   .��5      � .+�5   
   �� -   5         ��Name$ btnAdministracionClientes��5      $
��Left=�64   $	��105��6O   $��
39,114,0,0q�6\   $	��Top=�6p   $	��105��6�   
����������	#FFE4D327.��5      �� $	��119��5   	   $��Center=�6   $��imagenes/cliente.png��60    J� RenderTransformOrigin$ 
0.734,0.54&�6N   $	��115��6q   $��Center=�6~   5      �� 5   
   -   5        $ btnListadoContratos��5      $��184,251,0,0q�6.   ���	#FFE4D327
�������$	��105��6�   $	��Top=�6�   $
��Left=�6�   $	��105��6�   .��5      �� $��imagenes/listar.png��6   $��Center=�61   $	��119��6N   $	��115��6Z   $��Center=�6g   $ 
0.734,0.54&�6�   5      �� 5   
   -   5        $ btnContratos��5      $
��Left=�6'   $	��105��6B   $��184,114,0,0q�6O   $	��Top=�6d   $	��105��6|   ���	#FFE4D327
�������.��5      �� $��imagenes/contrato.png��6   $��Center=�63   $	��119��6P   $	��115��6\   $��Center=�6i   $ 
0.734,0.54&�6�   5      �� 5   
   -   5        $ btnListadoClientes��5      $
��Left=�6-   $	��105��6H   $��
39,251,0,0q�6U   $	��Top=�6i   $	��105��6�   ���	#FFE4D327
�������.��5      �� $��imagenes/listar.png��6   $��Center=�61   $	��119��6N   $	��115��6Z   $��Center=�6g   $ 
0.734,0.54&�6�   5      �� 5   
   $��imagenes/aa.png��6   $��114,-36,124,291q�6)   �� 5   
   $��Clientes...��6   $
��Left=�6&   $��31��6A   $��
39,196,0,0q�6M   $	��Top=�6a   $��77��6y   $��11(�6�   
�������6�   �� 5   
   $��Contratos...��6   $
��Left=�6'   $��31��6B   $��184,196,0,0q�6N   $	��Top=�6c   $��78��6{   
�������$��11(�6�   �� 5   
   $��Listar Clientes...��6   $
��Left=�6-   $��33��6H   $��
39,333,0,0q�6T   $	��Top=�6h   $��90��6�   $��11(�6�   
���������6�   Z� 6�   �� 5    
   $��Listar Contratos...��6   $
��Left=�6.   $��33��6I   $��184,333,0,0q�6U   $	��Top=�6j   $	��114��6�   $��11(�6�   
�������6�     ToggleClass.Toggle  5#   
   -   5          Name$ AltoContraste��5#      $��Toggle��64   $
��Left=�6E   $��133,380,0,0q�6`   $	��Top=�6u   6�   5&      5'      