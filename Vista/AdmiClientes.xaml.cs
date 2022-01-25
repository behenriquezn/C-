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
//Metro
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using Biblioteca.Negocio;



namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdmiClientes.xaml
    /// </summary>
    public partial class AdmiClientes : MetroWindow
    {
        public AdmiClientes()
        {
            InitializeComponent();
            cboActividadEmpresa.ItemsSource = new ActividadEmpresa().ReadAll();
            cboTipoEmpresa.ItemsSource =
                new TipoEmpresa().ReadAll();
            cboTipoEmpresa.Items.Refresh();
            cboActividadEmpresa.Items.Refresh();
        }

        private async void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente();
                cli.RutCliente = txtRut.Text;
                cli.NombreContacto = txtNombreContacto.Text;
                cli.RazonSocial = txtRazonSocial.Text;
                cli.MailContacto = txtMailContacto.Text;
                cli.Direccion = txtDireccion.Text;
                cli.Telefono = txtTelefono.Text;
                cli.IdActividadEmpresa = 
                    ((ActividadEmpresa)cboActividadEmpresa.SelectedItem).IdActividadEmpresa;
                cli.IdTipoEmpresa = 
                    ((TipoEmpresa)cboTipoEmpresa.SelectedItem).IdTipoEmpresa;
                bool resp = cli.Create();
                await this.ShowMessageAsync("Guardar:", resp ? "Guardo con exito" : "No pudo Guardar");
                //MessageBox.Show(resp ? "Grabo" : "No Grabo");
                if (resp)
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                await this.ShowMessageAsync("Error, no fue posible guardar el contrato",ex.Message);
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                c.RutCliente = txtRut.Text;
                bool resp = c.Read();
                if (resp)
                {
                    CargarDatos(c);
                }
                else
                {
                    MessageBox.Show("No existe el Cliente");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //ES PUBLICO PARA QUE AL TRASPASAR NO HAYA PROBLEMAS
        public void CargarDatos(Cliente c)
        {
            txtRut.Text = c.RutCliente;
            txtRazonSocial.Text = c.RazonSocial;
            txtNombreContacto.Text = c.NombreContacto;
            txtMailContacto.Text = c.MailContacto;
            txtDireccion.Text = c.Direccion;
            txtTelefono.Text = c.Telefono;
            ActividadEmpresa ae = new ActividadEmpresa() { IdActividadEmpresa = c.IdActividadEmpresa };
                ae.Read();
            cboActividadEmpresa.Text = ae.Descripcion;
            TipoEmpresa te = new TipoEmpresa() { IdTipoEmpresa = c.IdTipoEmpresa };
                te.Read();
            cboTipoEmpresa.Text = te.Descripcion;
        }

        private async void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente cli = new Cliente();
                cli.RutCliente = txtRut.Text;
                cli.NombreContacto = txtNombreContacto.Text;
                cli.RazonSocial = txtRazonSocial.Text;
                cli.MailContacto = txtMailContacto.Text;
                cli.Direccion = txtDireccion.Text;
                cli.Telefono = txtTelefono.Text;
                cli.IdActividadEmpresa =
                    ((ActividadEmpresa)cboActividadEmpresa.SelectedItem).IdActividadEmpresa;
                cli.IdTipoEmpresa =
                    ((TipoEmpresa)cboTipoEmpresa.SelectedItem).IdTipoEmpresa;
                bool resp = cli.Update();
                await this.ShowMessageAsync("Actualizacion:",
                    resp ? "Modifico Registro" : "No se pudo Modificar");
                if (resp)
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                await this.ShowMessageAsync("Error, no fue posible modificar el contrato", ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult respuesta =
                    MessageBox.Show("Desea Eliminar?",
                                    "Eliminar Reg.",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Warning);
                if (respuesta==MessageBoxResult.Yes)
                {
                    Cliente cli = new Cliente();
                    cli.RutCliente = txtRut.Text;
                    bool resp = cli.Delete();
                    if (resp)
                    {
                        MessageBox.Show("Eliminado");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Reg. No Eliminado, verificar el Rut");
                    }
                }
                else
                {
                    MessageBox.Show("Cancelo Eliminacion");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Limpiar()
        {
            txtRut.Clear();
            txtRazonSocial.Clear();
            txtNombreContacto.Clear();
            txtMailContacto.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            cboActividadEmpresa.SelectedIndex = -1;
            cboTipoEmpresa.SelectedIndex = -1;
        }

        private void TxtRut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CboActividadEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnListaCli_Click(object sender, RoutedEventArgs e)
        {
            ListaClientes lc = new ListaClientes(this);
            lc.Show();
        }
    }
}
