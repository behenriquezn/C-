   M S B A M L   `   `   `  ����@  <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	       Vista.AdmiClientes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Vista     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	     � Title$<  6                           ADMINISTRACIÓN DE CLIENTES��5   	   $	��606��6G   $	��467��6T    � 
ResizeMode$ NoResize=�6`    � WindowStartupLocation$ CenterScreen=�6v   .��5      � .+�5   
   �� -   5         ��Name$ lblRut��5      $	��Rut��6    $
��Left=�6.   $��26��6I   $��	36,74,0,0q�6U   $	��Top=�6h   $��70��6�   $��14(�6�   $
��Bold"�6�   $��Microsoft JhengHei UI)�6�   �� 5   
   -   5        $ lblRazonSocial��5      $��Razón Social��6(   $
��Left=�6?   $��36��6Z   $��
36,171,0,0q�6f   $	��Top=�6z   $	��104��6�   $��14(�6�   $��Microsoft JhengHei UI)�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblNombreContacto��5      $��Nombre Contacto��6+   $
��Left=�6E   $��27��6`   $��
36,124,0,0q�6l   $	��Top=�6�   $	��133��6�   $��14(�6�   $��Microsoft JhengHei UI)�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblMailContacto��5      $��Mail Contacto��6)   $
��Left=�6A   $��27��6\   $��
36,230,0,0q�6h   $	��Top=�6|   $	��104��6�   $��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ lblDireccion��5      $��
Dirección��6&   $
��Left=�6:   $��27��6U   $��
36,278,0,0q�6a   $	��Top=�6u   $��82��6�   $��Microsoft JhengHei UI)�6�   $��14(�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblTelefono��5      $��	Teléfono��6%   $
��Left=�68   $��32��6S   $��
36,331,0,0q�6_   $	��Top=�6s   $��70��6�   $��14(�6�   $��Microsoft JhengHei UI)�6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.214,-1&�6�   �� 5   
   -   5        $ lblActividadEmpresa��5      $��Actividad Empresa��6-   $
��Left=�6I   $��27��6d   $��
36,389,0,0q�6p   $	��Top=�6�   $	��144��6�   $��Microsoft JhengHei UI)�6�   $
��Bold"�6�   $��14(�6�   $ 0.275,-1.852&�6�   �� 5   
   -   5        $ lblTipoEmpresa��5      $��Tipo Empresa��6(   $
��Left=�6?   $��27��6Z   $��239,389,0,0q�6f   $	��Top=�6{   $	��135��6�   $��Microsoft JhengHei UI)�6�   $��14(�6�   $
��Bold"�6�   �� 5   
   -	   5         ��Name$ txtRut��5      *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Rut��6"      ClearTextButton . $
��Left=�6   $��24��6�   $��	67,93,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��181��6�   6�   �� 5   
   -
   5        $ txtRazonSocial��5      $ Ingrese Razon Social��6*    . $
��Left=�6�   $��27��6�   $��
67,198,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��236��6�   �� 5   
   -   5        $ txtNombreContacto��5      $ Ingrese Nombre Contacto��6-    . $
��Left=�6�   $��27��6�   $��
67,151,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��236��6�   �� 5   
   -   5        $ txtMailContacto��5      $ Ingrese Mail de Contacto��6+    . $
��Left=�6�   $��27��6�   $��
67,257,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��236��6�   �� 5   
   -   5        $ txtDireccion��5      $ Ingrese Dirección��6(    . $
��Left=�6�   $��27��6�   $��
67,305,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��236��6�   �� 5   
   -   5        $ txtTelefono��5      $ Ingrese Teléfono��6'    . $
��Left=�6�   $��12��6�   $��
67,358,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��236��6�   $ 0.333,0.615&�6�   �� 5   
   -   5        	 ��Name$	 cboActividadEmpresa��5      $
��Left=�60   $��27��6K   $��
53,421,0,0q�6W   $	��Top=�6k   $	��127��6�   6�   �� 5   
   -   5        $	 cboTipoEmpresa��5      $
��Left=�6+   $��19��6F   $��239,422,0,0q�6R   $	��Top=�6g   $	��126��6   �� 5   
   -   5        
 ��Name$
 	btnGrabar��5      $
��Left=�6%   $��81                 ��6@   $��342,178,0,0q�5      $	��Top=�6(   $��81��6@   ���	#FFE4D327.��5      �� $��imagenes/grabarrrr.png��6   $��Center=�64   $��59��6Q   $��60��6\   $��Center=�6h   $ 0.528,0.495&�6�   5       �� 5!   
   -   5        $
 	btnBuscar��5!      $
��Left=�6$   $��56��6?   $��
254,74,0,0q�6K   $	��Top=�6_   $	��111��6w   ���	#FFE4D327.��5#      �� $��imagenes/buscar.png��6   $��Center=�61   $��42��6N   $��30��6Y   $��Center=�6e   $ 
0.734,0.54&�6�   5$      �� 5&   
   -   5        $
 btnActualizar��5&      $
��Left=�6(   $��81��6C   $��266,473,0,0q�6O   $	��Top=�6d   $��81��6|   ���	#FFE4D327.��5'      �� $��imagenes/actualizar.png��6   $��Center=�65   $��64��6R   $��63��6]   $��Center=�6i   $ 
0.734,0.54&�6�   5(      �� 5*   
   -   5        $
 btnEliminar��5*      $
��Left=�6'   $��81��6B   $��
79,473,0,0q�6N   $	��Top=�6b   $��81��6z   ���	#FFE4D327.��5+      �� $��imagenes/eliminar.png��6   $��Center=�63   $��62��6P   $��82��6[   $��Center=�6g   $ 
0.734,0.54&�6�   5,      �� 5-   
   $��imagenes/aa.png��6   $��193,-25,188,477q�6)   6D   �� 5.   
   -   5        $
 btnListaCli��5.      $
��Left=�6&   $��81��6A   $��342,292,0,0q�6M   $	��Top=�6b   $��81                 ��6z   ���	#FFE4D327.��50      �� $��imagenes/guardar.png��6   $��Center=�62   $��73��6O   $��71��6Z   $��Center=�6f   $ 0.5,0.5&�6�   51      �� 52   
   $��Listar Cliente...��6   $��342,350,39,204q�6,   
�������$��11(�6W   �� 53   
   $��
Guardar...��6   $
��Left=�6%   $��22��6@   $��342,237,0,0q�6L   $	��Top=�6a   $��59��6y   
�������$��11(�6�   �� 54   
   $��Actualizar...��6   $
��Left=�6(   $��23��6C   $��266,531,0,0q�6O   $	��Top=�6d   $��69��6|   
�������$��11(�6�   �� 55   
   $��Eliminar...��6   $
��Left=�6&   $��24��6A   $��
79,531,0,0q�6M   $	��Top=�6a   $��61��6y   $��11(�6�   
�������6�   �� 56   
   $��Buscar         Cliente...��6   $
��Left=�64   $��30��6O   $��253,100,0,0q�6[   $	��Top=�6p   $	��112��6�   $��11(�6�   
�������6�   57      58      