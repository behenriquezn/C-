using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Biblioteca.Negocio;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para ListaClientes.xaml
    /// </summary>
    public partial class ListaClientes : MetroWindow
    {
        public Object ventana_origen;

        public ListaClientes()
        {
            InitializeComponent();
            Cargar();

        }
        public ListaClientes(Object obj)
        {
            InitializeComponent();
            Cargar();
            ventana_origen = obj;

        }

        private void Cargar()
        {
            dtgLista.ItemsSource = new Cliente().ReadAll2();
            cboActividadEmpresa.ItemsSource = new ActividadEmpresa().ReadAll();
            cboTipoEmpresa.ItemsSource = new TipoEmpresa().ReadAll();
        }

        private void BtnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente();
            dtgLista.ItemsSource = cli.ReadAll2()
                .Where(c => c.RUT.Equals(txtRut.Text))
                .ToList();
        }

        private void BtnFiltrarTipoEmp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente();
                cli.IdTipoEmpresa = ((TipoEmpresa)cboTipoEmpresa.SelectedItem).IdTipoEmpresa;
                dtgLista.ItemsSource =
                    cli.ReadAllByTipoEmpresa2();
            }
            catch (Exception)
            {

                
            }
        }
        private void BtnFiltrarActEmpre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente();
                cli.IdActividadEmpresa = ((ActividadEmpresa)cboActividadEmpresa.SelectedItem).IdActividadEmpresa;
                dtgLista.ItemsSource =
                    cli.ReadAllByActividadEmpresa2();
            }
            catch (Exception)
            {


            }

        }

        private void limpiar()
        {
            txtRut.Clear();
            cboActividadEmpresa.SelectedIndex = -1;
            cboTipoEmpresa.SelectedIndex = -1;
        }

        private void BtnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {
            dtgLista.ItemsSource = new Cliente().ReadAll2();
            limpiar();
            dtgLista.Items.Refresh();
        }

        private void BtnTraspaso_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                CListaClientes lc = (CListaClientes)dtgLista.SelectedItem;
                Cliente cli = new Cliente() { RutCliente = lc.RUT };
                cli.Read();

                if (ventana_origen.GetType() == typeof(AdmiClientes))
                {
                    ((AdmiClientes)ventana_origen).CargarDatos(cli);
                }
                else
                {
                    MessageBox.Show("No se puede ingresar desde esta pestal");
                }
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                MessageBox.Show("Error: no se puede traspasar desde esta pestaña", ex.Message);
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
