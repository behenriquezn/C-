   M S B A M L   `   `   `  ����@  <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	       Vista.ListaClientes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Vista     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	     � Title$H  B                                               LISTADO DE CLIENTES��5   	   $��479.206��6T   $��884.146��6e   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dtgLista��5      $
��Left=�6%   $	��249��6@   $��
47,166,0,0q�6M   $	��Top=�6a   $	��696��6y   ���	#FF40CBFF
�������
���   �6�   �� 5   
   -   5         ��Name$ lblRut��5      $	��RUT��6    $
��Left=�6.   $��29��6I   $��	93,52,0,0q�6U   $	��Top=�6h   $��61��6�   $��Microsoft JhengHei)�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ lblTipoEmpresa��5      $��TIPO EMPRESA��6(   $
��Left=�6?   $��29��6Z   $��
238,52,0,0q�6f   $	��Top=�6z   $	��117��6�   $��Microsoft JhengHei)�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5        $ lblActividad��5      $��ACTIVIDAD EMPRESA��6&   $
��Left=�6B   $��29��6]   $��
418,52,0,0q�6i   $	��Top=�6}   $	��164��6�   $��Microsoft JhengHei)�6�   $��14(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ cboActividadEmpresa��5      $
��Left=�60   $��27��6K   $��
418,75,0,0q�6W   $	��Top=�6k   $	��164��6�   �� 5   
   -   5        $ cboTipoEmpresa��5      $
��Left=�6+   $��28��6F   $��
224,76,0,0q�6R   $	��Top=�6f   $	��141��6~   �� 5   
   -   5         ��Name$ txtRut��5      $
��Left=�6"   $��16��6=   $��	59,76,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��124��6�   �� 5   
   -   5         ��Name$ btnFiltrarRut��5      $��FILTRAR��6(   $
��Left=�6:   $��30��6U   $��
59,102,0,0q�6a   $	��Top=�6u   $	��124��6�   ���	#FFE4D3276�   �� 5   
   -	   5        $ btnFiltrarTipoEmp��5      $��FILTRAR��6,   $
��Left=�6>   $��30��6Y   $��224,102,0,0q�6e   $	��Top=�6z   $	��141��6�   ���	#FFE4D3276�   �� 5   
   -
   5        $ btnFiltrarActEmpre��5      $��FILTRAR��6-   $
��Left=�6?   $��30��6Z   $��418,102,0,0q�6f   $	��Top=�6{   $	��164��6�   ���	#FFE4D3276�   �� 5   
   -   5        $ btnBorrarFiltro��5      $��QUITAR FILTRO��6*   $
��Left=�6B   $��38��6]   $��
608,64,0,0q�6i   $	��Top=�6}   $	��123��6�   ���	#FFE4D327���	#FF2C2828���	#FF2C28286�   �� 5   
   -   5        $ btnTraspaso��5      $
��Left=�6'   $��76��6B   $��767,166,0,0q�6N   $	��Top=�6c   $��88��6{   ���	#FF40CBFF.��5      �� $��imagenes/traspaso.png��6   $��Center=�63   $��66��6P   $��54��6[   $��Center=�6g    J� RenderTransformOrigin$ 0.528,0.495&�6�   5      �� 5   
   -   5        $ 	btnCerrar��5      $��CERRAR��6$   $
��Left=�65   $��76��6P   $��767,339,0,0q�6\   $	��Top=�6q   $��88                 ��6�   ���	#FFE4D3275   *   �� 5   
   $��imagenes/aa.png��6   $��755,0,21,309q�6)   6A   �� 5   
   $��Traspaso...��6   $
��Left=�6&   $��39��6A   $��767,218,0,0q�6M   $	��Top=�6b   $��76��6z   
�������$��11(�6�   5       5!      