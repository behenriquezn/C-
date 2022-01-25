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
    /// Lógica de interacción para ListaContratos.xaml
    /// </summary>
    public partial class ListaContratos : Window
    {
        public Object ventana_origen_contrato;

        public ListaContratos()
        {
            InitializeComponent();
            CargarDatos();
        }

        public ListaContratos(Object obj)
        {
            InitializeComponent();
            CargarDatos();
            ventana_origen_contrato = obj;
        }

        private void CargarDatos()
        {
            dtgListaContratos.ItemsSource = new Contrato().ReadAll2();

            cboTipoEvento.ItemsSource = new TipoEvento().ReadAll();
            cboModalidadServicio.ItemsSource = new ModalidadServicio().ReadAll();
        }

        private void BtnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {
            Contrato cont = new Contrato();
            dtgListaContratos.ItemsSource = cont.ReadAll()
                .Where(co => co.RutCliente.Equals(txtRut.Text))
                .ToList();
            
        }

        private void BtnBorrarFiltro_Click(object sender, RoutedEventArgs e)
        {
            dtgListaContratos.ItemsSource = new Contrato().ReadAll2();
        }


        private void BtnFiltrarModalidadServicio_Click(object sender, RoutedEventArgs e)
        {
            Contrato con = new Contrato();
            con.IdModalidad = ((ModalidadServicio)cboModalidadServicio.SelectedItem).IdModalidad;
            dtgListaContratos.ItemsSource =
                con.ReadAllByModalidadServicio2();
        }

        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            ListaClientes lc = new ListaClientes(this);
            lc.Show();
        }

        private void BtnListarTodo_Click(object sender, RoutedEventArgs e)
        {
            dtgListaContratos.ItemsSource = new Contrato().ReadAll();
        }

        private void BtnNroContrato_Click(object sender, RoutedEventArgs e)
        {
            Contrato cont = new Contrato();
            dtgListaContratos.ItemsSource = cont.ReadAll2()
                .Where(c => c.NUMERO.Equals(txtNroContrato.Text))
                .ToList();
        }

        private void CboModalidadServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnTraspaso_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ClistaContrato lc = (ClistaContrato)dtgListaContratos.SelectedItem;
                Contrato con = new Contrato() { Numero = lc.NUMERO };
                con.Read();

                if (ventana_origen_contrato.GetType() == typeof(AdmiContratos))
                {
                    ((AdmiContratos)ventana_origen_contrato).CargarDatosc(con);
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















            /*Contrato con = (Contrato)dtgListaContratos.SelectedItem;
            if (ventana_origen.GetType() == typeof(AdmiContratos))
            {
                Cliente c = (Cliente)dtgListaContratos.SelectedItem;
                ((AdmiContratos)ventana_origen).txtNumero.Text = con.Numero;
            }
            //---------------------------------------------------------
            Contrato reg = (Contrato)dtgListaContratos.SelectedItem;
            if (ventana_origen.GetType() == typeof(AdmiContratos))
            {
                Contrato c = (Contrato)dtgListaContratos.SelectedItem;
                ((AdmiContratos)ventana_origen).txtRut.Text = c.RutCliente;
                ((AdmiContratos)ventana_origen).txtNumero.Text = c.Numero;
                ((AdmiContratos)ventana_origen).dtpFechaCreacion.Text = c.Creacion.ToString();
                ((AdmiContratos)ventana_origen).txtAsistentes.Text = c.Asistentes.ToString();
                ((AdmiContratos)ventana_origen).txtNroPersonalAdicional.Text = c.PersonalAdicional.ToString();
                //((AdmiContratos)ventana_origen).dtpInicio.SelectedDate = c.FechaHoraInicio;
                //((AdmiContratos)ventana_origen).ctrFechaFin.SelectedDate = c.FechaHoraTermino;
                ((AdmiContratos)ventana_origen).txtValorTotal.Text = c.ValorTotalContrato.ToString();
                ((AdmiContratos)ventana_origen).txtObservaciones.Text = c.Observaciones;
                ModalidadServicio ms = new ModalidadServicio() { IdModalidad = c.IdModalidad };
                TipoEvento te = new TipoEvento() { IdTipoEvento = c.IdTipoEvento };
                ms.Read();
                te.Read();
                ((AdmiContratos)ventana_origen).cboModalidad.Text = ms.Nombre.Trim();
                ((AdmiContratos)ventana_origen).txtNroPersonalAdicional.Text = ms.PersonalBase.ToString();
                ((AdmiContratos)ventana_origen).cboTipoEvento.Text = te.Descripcion;

            }
            //------------------------------------------
            try
            {
                ClistaContrato lc = (ClistaContrato)dtgListaContratos.SelectedItem;
                Contrato con2 = new Contrato() { Numero = lc.NUMERO };
                con.Read();

                if (ventana_origen.GetType() == typeof(AdmiContratos))
                {
                    ((AdmiContratos)ventana_origen).CargarDatosc(con);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: no se puede traspasar desde esta pestaña",ex.Message);
            }*/
        }

        private void BtnFiltrarTipoEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato();
                con.IdTipoEvento = ((TipoEvento)cboTipoEvento.SelectedItem).IdTipoEvento;
                dtgListaContratos.ItemsSource =
                    con.ReadallByTipoEvento2();
            }
            catch (Exception)
            {

                
            }
        }
    }
}
