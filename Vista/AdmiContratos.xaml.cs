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
using Biblioteca.Negocio;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

using System.Globalization;
//using WpfControlLibrary1;

using System.Windows.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdmiContratos.xaml
    /// </summary>
    public partial class AdmiContratos : MetroWindow
    {
        //creacion de objeto Timer
        DispatcherTimer dt = new DispatcherTimer();

        public AdmiContratos()
        {
            InitializeComponent();
            LlenarDatos();
            //UF----------------
            ServiceReferenceUF.Service1Client WS =
                new ServiceReferenceUF.Service1Client();
            txtValorActualUF.Text = WS.UF().ToString("0,0,0");
            //-------------------
            verificarArchivoBinario();
            dt.Interval = TimeSpan.FromMinutes(5);
            dt.Tick += dtTiempo;
            dt.Start();
        }

        private async void verificarArchivoBinario()
        {
            string ruta = @"C:\Users\pc\Desktop\Copias\ArchivoBin.bin";
            if (File.Exists(ruta))
            {
                MessageDialogResult resul =
                    await this.ShowMessageAsync(
                        "Informacion",
                        "Hay una copia de datos en el cache de disco, desea recuperarlo",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (resul == MessageDialogResult.Affirmative)
                {
                    /*Memento memento = new Memento();
                    ContratoSalvar con = new ContratoSalvar();
                    con.Restaurar(memento);
                    CargarDatosContrato(con);*/
                    Stream stream = File.OpenRead(ruta);
                    BinaryFormatter formato = new BinaryFormatter();
                    ContratoSalvar con =
                        (ContratoSalvar)formato.Deserialize(stream);
                    CargarDatosContrato(con);
                    stream.Close();
                }
                else
                {
                    File.Delete(ruta);
                }
            }
        }

        private void dtTiempo(object sender, EventArgs e)
        {
            crearContratoBIN();
        }

        private void crearContratoBIN()
        {
            try
            {
                ContratoSalvar con = new ContratoSalvar();
                con.Numero = txtNumero.Text;
                con.Creacion = DateTime.Now;
                con.Termino = ctrFechaFin.RecuperarFechaYHora();
                con.RutCliente = txtRut.Text;

                con.IdModalidad = ((ModalidadServicio)cboModalidad.SelectedItem).IdModalidad;
                con.IdTipoEvento = ((TipoEvento)cboTipoEvento.SelectedItem).IdTipoEvento;
                if (cboTipoEvento.SelectedIndex >= 0)
                {
                    con.IdTipoEvento = ((TipoEvento)cboTipoEvento.SelectedItem).IdTipoEvento;
                }
                else
                {
                    con.IdTipoEvento = -1;
                }
                if (cboModalidad.SelectedIndex >= 0)
                {
                    con.IdModalidad = ((ModalidadServicio)cboModalidad.SelectedItem).IdModalidad;
                }
                else
                {
                    con.IdModalidad = "-1";
                }
                con.FechaHoraInicio = ctrFechaInicio.RecuperarFechaYHora();
                con.FechaHoraTermino = ctrFechaFin.RecuperarFechaYHora();
                con.Asistentes = int.Parse(txtAsistentes.Text);
                con.PersonalAdicional = int.Parse(txtNroPersonalAdicional.Text);
                con.Realizado = false;
                con.ValorTotalContrato = float.Parse(txtValorTotal.Text);
                con.Observaciones = txtObservaciones.Text;
                string ruta = @"C:\Users\pc\Desktop\Copias\ArchivoBin.bin";
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
                Stream grabar_Archivo = File.Create(ruta);
                BinaryFormatter serializador = new BinaryFormatter();
                serializador.Serialize(grabar_Archivo, con);
                grabar_Archivo.Close();
                //this.Title = "Almaceno el Archivo";

                //memento.Salvar(con);
                //MessageBox.Show("Guardado");
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
            }
            
        }
        
        private void CargarDatosContrato(ContratoSalvar con)
        {
            txtNumero.Text = con.Numero;
            txtRut.Text = con.RutCliente;
            dtpFechaCreacion.Text = con.Creacion.ToString("dd/MM/yyyy");
            ctrFechaInicio.VerFechaYHora(con.FechaHoraInicio);
            ctrFechaFin.VerFechaYHora(con.FechaHoraTermino);
            if (con.IdTipoEvento == -1)
            {
                cboTipoEvento.SelectedIndex = -1;
                cboModalidad.ItemsSource = null;
            }
            else
            {
                TipoEvento te = new TipoEvento() { IdTipoEvento = con.IdTipoEvento };
                te.Read();
                cboTipoEvento.Text = te.Descripcion;
                if (con.IdModalidad.Equals("-1"))
                {
                    cboModalidad.SelectedIndex = -1;
                }
                else
                {
                    ModalidadServicio mo = new ModalidadServicio() { IdModalidad = con.IdModalidad };
                    mo.Read();
                    cboModalidad.Text = mo.Nombre.Trim();
                }
            }
            /*TipoEvento te = new TipoEvento() { IdTipoEvento = con.IdTipoEvento };
            te.Read();
            cboTipoEvento.Text = te.Descripcion;
            ModalidadServicio ms = new ModalidadServicio() { IdModalidad = con.IdModalidad };
            ms.Read();
            cboModalidad.Text = ms.Nombre.Trim();*/
            txtAsistentes.Text = con.Asistentes.ToString();
            txtNroPersonalAdicional.Text = con.PersonalAdicional.ToString();
            txtValorTotal.Text = con.ValorTotalContrato.ToString();
            txtObservaciones.Text = con.Observaciones;
        }

        private void BtnCopia_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                crearContratoBIN();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
            }

        }

        //-----------------------------------------------------

        private void LlenarDatos()
        {
            txtNumero.Text = DateTime.Now.ToString("yyyyMMddHHmm");
            dtpFechaCreacion.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cboTipoEvento.ItemsSource = new TipoEvento().ReadAll();
            cboTipoEvento.Items.Refresh();
            txtAsistentes.Clear();
            txtNroPersonalAdicional.Clear();
            lblNroPersonal.Content = "";
        }

        private void BtnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            ListaClientes lc = new ListaClientes(this);
            lc.Show();
        }

        #region Crear Contrato
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato();
                con.Numero = txtNumero.Text;
                con.Creacion = DateTime.Now;
                con.Termino = ctrFechaFin.RecuperarFechaYHora();
                con.RutCliente = txtRut.Text;
                con.IdModalidad = ((ModalidadServicio)cboModalidad.SelectedItem).IdModalidad;
                con.IdTipoEvento = ((TipoEvento)cboTipoEvento.SelectedItem).IdTipoEvento;
                con.FechaHoraInicio = ctrFechaInicio.RecuperarFechaYHora();
                con.FechaHoraTermino = ctrFechaFin.RecuperarFechaYHora();
                con.Asistentes = int.Parse(txtAsistentes.Text);
                con.PersonalAdicional = int.Parse(txtNroPersonalAdicional.Text);
                con.Realizado = false;
                con.ValorTotalContrato = float.Parse(txtValorTotal.Text);
                con.Observaciones = txtObservaciones.Text;
                //--------------------------------------
                Evento ev = crearEvento();
                if (con.IdTipoEvento==10)
                {
                    CoffeeBreak cb = (CoffeeBreak)ev;
                    cb.Create();
                }
                if (con.IdTipoEvento==20)
                {
                    Cocktail ck = (Cocktail)ev;
                    ck.Create();
                }
                if (con.IdTipoEvento==30)
                {
                    Cenas ce = (Cenas)ev;
                    ce.Create();
                }
                bool resp = con.Create();
                await this.ShowMessageAsync("Contrato" , resp ? "Contrato Guardado con Exito" : "No fue posible guardar");
                if (resp)
                {
                    Limpiar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void Limpiar()
        {
            txtNumero.Text = DateTime.Now.ToString("yyyyMMddhhmm");
            txtRut.Clear();
            lblRazonSocial.Content = "Razón social del cliente seleccionado";
            dtpFechaCreacion.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ctrFechaInicio.LimpiarFechaYHora();
            ctrFechaFin.LimpiarFechaYHora();
            cboTipoEvento.SelectedIndex = -1;
            cboModalidad.SelectedIndex = -1;
            txtAsistentes.Clear();
            lblNroPersonal.Content = "";
            txtNroPersonalAdicional.Clear();
            txtValorTotal.Clear();
            txtObservaciones.Clear();
            txtValorBase.Clear();
            txtValorAsistente.Clear();
            txtValorPersonalAd.Clear();
            txtValorExtra.Clear();
            grbSeleccione.Visibility = Visibility.Visible;
            grbCenas.Visibility = Visibility.Hidden;
            grbCocktail.Visibility = Visibility.Hidden;
            grbCoffeeBreak.Visibility = Visibility.Hidden;
            txtValorBaseUF.Clear();
            txtValorAsistenteUF.Clear();
            txtValorPersonalUF.Clear();
            txtValorExtraUF.Clear();
            txtValorTotalUF.Clear();
            LimpiarEvento();
        }

        private void LimpiarEvento()
        {
            //--------------------------
            lblNroPersonal.Content = "";
            //----------------------Cenas
            cboTipoAmbientacionCenas.SelectedIndex = -1;
            chkMusicaAmbientalCenas.IsChecked = false;
            rbtLocalOnBreak.IsChecked = true;
            txtValorArriendo.Clear();
            txtComision.Clear();
            //----------------------Cocktail
            chkAmbientacionCocktail.IsChecked = false;
            chkMusicaAmbientalCocktail.IsChecked = false;
            chkClienteProveeMusica.IsChecked = false;
            cboTipoAmbientacionCocktail.SelectedIndex = -1;
            //----------------------CoffeeBreak
            rbtMixta.IsChecked = true;
        }

        #region Buscar Contrato (Llamar)

        private void BtnBuscarContrato1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato();
                con.Numero = txtNumero.Text;
                bool resp = con.Read();
                if (resp)
                {
                    CargarDatosc(con);
                }
                else
                {
                    MessageBox.Show("No existe el Contrato");
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public void CargarDatosc(Contrato con)
        {
            txtNumero.Text = con.Numero;
            txtRut.Text = con.RutCliente;
            dtpFechaCreacion.Text = con.Creacion.ToString("dd/MM/yyyy");
            ctrFechaInicio.VerFechaYHora(con.FechaHoraInicio);
            ctrFechaFin.VerFechaYHora(con.FechaHoraTermino);
            TipoEvento te = new TipoEvento() { IdTipoEvento = con.IdTipoEvento };
            te.Read();
            cboTipoEvento.Text = te.Descripcion;
            ModalidadServicio ms = new ModalidadServicio() { IdModalidad = con.IdModalidad };
            ms.Read();
            cboModalidad.Text = ms.Nombre.Trim();
            txtAsistentes.Text = con.Asistentes.ToString();
            txtNroPersonalAdicional.Text = con.PersonalAdicional.ToString();
            txtValorTotal.Text = con.ValorTotalContrato.ToString();
            txtObservaciones.Text = con.Observaciones;
            /*Evento ev;
            if (te.IdTipoEvento == 10)
            {
                ev = new CoffeeBreak() { Numero = con.Numero };
                ((CoffeeBreak)ev).Read();
                if (true)
                {
                    rbtVegetariana.IsChecked = true;
                }
                else
                {
                    rbtMixta.IsChecked = false;
                }
            }*/
            
            //cargarEvento();
        }

        private void cargarEvento()
        {
            Contrato con = new Contrato();
            TipoEvento te = new TipoEvento();
            ModalidadServicio ms = new ModalidadServicio();
            Evento ev;
            if (te.IdTipoEvento == 10)
            {
                ev = new CoffeeBreak() { Numero = con.Numero };
                ((CoffeeBreak)ev).Read();
                if (true)
                {
                    rbtVegetariana.IsChecked = true;
                }
                else
                {
                    rbtMixta.IsChecked = false;
                }
            }
            else if (te.IdTipoEvento == 20)
            {
                ev = new Cocktail() { Numero = con.Numero };
                ((Cocktail)ev).Read();
                chkAmbientacionCocktail.IsChecked =
                    ((Cocktail)ev).Ambientacion;
                chkMusicaAmbientalCocktail.IsChecked =
                    ((Cocktail)ev).MusicaAmbiental;
                chkClienteProveeMusica.IsChecked =
                    ((Cocktail)ev).MusicaCliente;
                if (((Cocktail)ev).Ambientacion == false)
                {
                    cboTipoAmbientacionCocktail.SelectedIndex = -1;
                }
                else
                {
                    TipoAmbientacion ta = new TipoAmbientacion()
                    { IdTipoAmbientacion = ((Cocktail)ev).IdTipoAmbientacion };
                    ta.Read();
                    cboTipoAmbientacionCocktail.Text = ta.Descripcion;
                }
            }
            else if (te.IdTipoEvento == 30)
            {
                ev = new Cenas()
                { Numero = con.Numero };
                ((Cenas)ev).Read();
                TipoAmbientacion ta = new TipoAmbientacion()
                { IdTipoAmbientacion = ((Cenas)ev).IdTipoAmbientacion };
                ta.Read();
                cboTipoAmbientacionCenas.Text = 
                    ta.Descripcion;
                chkMusicaAmbientalCenas.IsChecked = 
                    ((Cenas)ev).MusicaAmbiental;
                if (((Cenas)ev).LocalOnBreak)
                {
                    rbtLocalOnBreak.IsChecked = true;
                }
                else
                {
                    rbtOtroLocal.IsChecked = true;
                    txtValorArriendo.Text = (((Cenas)ev).ValorArriendo).ToString();
                    
                }
            }
        }

        #region Actualizar Contrato
        private async void BtnActualizarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato();
                con.Numero = txtNumero.Text;
                con.Creacion = DateTime.Now;
                con.Termino = ctrFechaFin.RecuperarFechaYHora();
                con.RutCliente = txtRut.Text;
                con.IdModalidad = ((ModalidadServicio)cboModalidad.SelectedItem).IdModalidad;
                con.IdTipoEvento = ((TipoEvento)cboTipoEvento.SelectedItem).IdTipoEvento;
                con.FechaHoraInicio = ctrFechaInicio.RecuperarFechaYHora();
                con.FechaHoraTermino = ctrFechaFin.RecuperarFechaYHora();
                con.Asistentes = int.Parse(txtAsistentes.Text);
                con.PersonalAdicional = int.Parse(txtNroPersonalAdicional.Text);
                con.Realizado = false;
                con.ValorTotalContrato = float.Parse(txtValorTotal.Text);
                con.Observaciones = txtObservaciones.Text;
                //--------------------------------------
                Evento ev = crearEvento();
                if (con.IdTipoEvento == 10)
                {
                    CoffeeBreak cb = (CoffeeBreak)ev;
                    cb.Update();
                }
                else if (con.IdTipoEvento == 20)
                {
                    Cocktail ck = (Cocktail)ev;
                    ck.Update();
                }
                else if (con.IdTipoEvento == 30)
                {
                    Cenas ce = (Cenas)ev;
                    ce.Update();
                }
                bool resp = con.Update();
                await this.ShowMessageAsync("Actualizar" , resp ? "Actualizo" : "No Actualizo");
                if (resp)
                {
                    Limpiar();
                }
                if (con.Realizado.Equals(true))
                {
                    await this.ShowMessageAsync("No se puede actualizar", "El contrato ya esta Terminado");
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Error:", 
                                            ex.Message);
                Logger.mensaje(ex.Message);
            }
        }
        #endregion

        #region Terminar Contrato
        private async void BtnTerminoContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageDialogResult respuesta =
                    await this.ShowMessageAsync("Terminar Contrato",
                                    "Desea Terminar Contrato?",
                                    MessageDialogStyle.AffirmativeAndNegative); ;
                if (respuesta == MessageDialogResult.Affirmative)
                {
                    Contrato con = new Contrato();
                    con.Numero = txtNumero.Text;
                    bool resp = con.Delete();
                    if (resp)
                    {
                        await this.ShowMessageAsync("Terminado", "El contrato se a terminado");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Reg. No Terminado, verificar el Rut");
                    }
                }
                else
                {
                    MessageBox.Show("Cancelo Terminado");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        //-------------------------------------------------------------------

        private void CboTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipoEvento.SelectedIndex != -1)
            {
                grbSeleccione.Visibility = Visibility.Hidden;
                grbCocktail.Visibility = Visibility.Hidden;
                grbCenas.Visibility = Visibility.Hidden;
                grbCoffeeBreak.Visibility = Visibility.Hidden;
                txtValorArriendo.Clear();
                TipoEvento tp = (TipoEvento)cboTipoEvento.SelectedItem;
                cboModalidad.ItemsSource =
                    new ModalidadServicio()
                    .ReadAll()
                    .Where(m => m.IdTipoEvento == tp.IdTipoEvento);
                    //.ToList();
                //cboModalidad.Items.Refresh();
                if (tp.IdTipoEvento == 10)
                {
                    grbCoffeeBreak.Visibility = Visibility.Visible;
                    LimpiarEvento();
                }
                else if (tp.IdTipoEvento == 20)
                {
                    grbCocktail.Visibility = Visibility.Visible;
                    cboTipoAmbientacionCocktail.ItemsSource = new TipoAmbientacion().ReadAll()
                        .Where(x => x.IdTipoAmbientacion <= 20);
                    LimpiarEvento();
                }
                else if (tp.IdTipoEvento == 30)
                {
                    grbCenas.Visibility = Visibility.Visible;
                    cboTipoAmbientacionCenas.ItemsSource = new TipoAmbientacion().ReadAll()
                        .Where(x => x.IdTipoAmbientacion <= 20);
                    LimpiarEvento();
                }
                cargarCalculos();
            }
        }

        private void CboModalidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(cboModalidad.SelectedIndex!=-1)
                {
                    ModalidadServicio ms = (ModalidadServicio)cboModalidad.SelectedItem;
                    //Contrato c = new Contrato();
                    lblNroPersonal.Content = ms.PersonalBase.ToString();
                    txtValorBase.Text = (ms.ValorBase).ToString(); //*28710
                    txtValorBaseUF.Text = (double.Parse(txtValorBase.Text) * double.Parse(txtValorActualUF.Text)).ToString("0,0,0");
                    //lblNroPersonal.Content = ms.PersonalBase.ToString();
                    //cargarCalculos();
                }
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
            }
        }

        private void TxtAsistentes_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                cargarCalculos();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                txtAsistentes.Text = "0";
                //MessageBox.Show("No elimine los valores, escriba sobre ellos");
            }
        }

        public Evento crearEvento()
        {
            Evento ev;
            Contrato con = new Contrato();
            TipoEvento te = (TipoEvento)cboTipoEvento.SelectedItem;
            if (te!=null)
            {
                ModalidadServicio ms = new ModalidadServicio();
                if (cboModalidad.SelectedIndex == -1)
                {
                    ms.IdModalidad = "0";
                }
                else
                {
                    ms = (ModalidadServicio)cboModalidad.SelectedItem;
                }
                con.IdModalidad = ms.IdModalidad;
                con.PersonalAdicional = int.Parse(txtNroPersonalAdicional.Text); //error
                con.Asistentes = int.Parse(txtAsistentes.Text);
                switch (te.Descripcion)
                {
                    case "Cocktail":
                        TipoAmbientacion ta = new TipoAmbientacion();
                        if (cboTipoAmbientacionCocktail.SelectedIndex == -1)
                        {
                            ta.IdTipoAmbientacion = 30;
                        }
                        else
                        {
                            ta = (TipoAmbientacion)cboTipoAmbientacionCocktail.SelectedItem;
                        }
                        bool ambientacionCocktail = chkAmbientacionCocktail.IsChecked == true ? true : false;
                        bool musicaAmbientalCocktail = chkMusicaAmbientalCocktail.IsChecked == true ? true : false;
                        bool clienteProveeMusicaCocktail = chkClienteProveeMusica.IsChecked == true ? true : false;
                        ev = new Cocktail()
                        {
                            Numero = txtNumero.Text,
                            IdTipoAmbientacion = ta.IdTipoAmbientacion,
                            Ambientacion = ambientacionCocktail,
                            MusicaAmbiental = musicaAmbientalCocktail,
                            MusicaCliente = clienteProveeMusicaCocktail
                        };
                        ev.TipoContrato(con);
                        break;
                    case "Cenas":
                        TipoAmbientacion tac = new TipoAmbientacion();
                        if (cboTipoAmbientacionCenas.SelectedIndex == -1)
                        {
                            tac.IdTipoAmbientacion = 30;
                        }
                        else
                        {
                            tac = (TipoAmbientacion)cboTipoAmbientacionCenas.SelectedItem;
                        }
                        bool musicaAmbientalCenas = chkMusicaAmbientalCenas.IsChecked == true ? true : false;
                        bool localOnBreak = rbtLocalOnBreak.IsChecked == true ? true : false;
                        bool otroLocal = rbtOtroLocal.IsChecked == true ? true : false;
                        int valorArriendo = int.Parse(txtValorArriendo.Text);
                        ev = new Cenas()
                        {
                            Numero = txtNumero.Text,
                            IdTipoAmbientacion = tac.IdTipoAmbientacion,
                            MusicaAmbiental = musicaAmbientalCenas,
                            LocalOnBreak = localOnBreak,
                            OtroLocalOnBreak = otroLocal,
                            ValorArriendo = valorArriendo
                        };
                        ev.TipoContrato(con);
                        break;
                    case "Coffee Break":
                        bool vegetariana = rbtVegetariana.IsChecked == true ? true : false;
                        ev = new CoffeeBreak()
                        {
                            Numero = txtNumero.Text,
                            Vegetariana = vegetariana
                        };
                        ev.TipoContrato(con);
                        break;

                    default:
                        ev = null;
                        break;
                }
                return ev;
            }
            return null;
        }

        private void cargarCalculos()
        {
            try
            {
                Evento ev = crearEvento();
                if (ev != null)
                {
                    //-------UF-----------------
                    //txtValorBase.Text = "" + ev.ValorBase();
                    txtValorAsistente.Text = "" + ev.RecargoAsistentes();
                    txtValorPersonalAd.Text = "" + ev.RecargoPersonalAdicional();
                    txtValorExtra.Text = "" + ev.RecargoExtras();
                    txtValorTotal.Text = (ev.ValorBase() + ev.RecargoAsistentes() + ev.RecargoPersonalAdicional() + ev.RecargoExtras()).ToString();

                    //---------Pesos------------------
                    //txtValorBaseUF.Text = (double.Parse(txtValorBase.Text) * double.Parse(txtValorActualUF.Text)).ToString();
                    txtValorAsistenteUF.Text = (double.Parse(txtValorAsistente.Text) * double.Parse(txtValorActualUF.Text)).ToString("0,0,0");
                    txtValorPersonalUF.Text = (double.Parse(txtValorPersonalAd.Text) * double.Parse(txtValorActualUF.Text)).ToString("0,0,0");
                    txtValorExtraUF.Text = (double.Parse(txtValorExtra.Text) * double.Parse(txtValorActualUF.Text)).ToString("0,0,0");
                    txtValorTotalUF.Text = (double.Parse(txtValorBaseUF.Text) + double.Parse(txtValorAsistenteUF.Text) + double.Parse(txtValorPersonalUF.Text) + double.Parse(txtValorExtraUF.Text)).ToString("0,0,0");
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
            }
        }

        private void txtRut_KeyDown(object sender, KeyEventArgs e)
        {
            string tecla = e.Key.ToString();
            if (tecla.Equals("Return"))
            {
                try
                {
                    Cliente cli = new Cliente();
                    cli.RutCliente = txtRut.Text;
                    cli.Read();
                    if (cli != null)
                    {
                        lblRazonSocial.Content = cli.RazonSocial;
                    }
                    else
                    {
                        MessageBox.Show("No esta");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            /*try
            {
                Contrato cont = new Contrato();
                cont.Asistentes = int.Parse(txtAsistentes.Text);
                cont.PersonalAdicional = int.Parse(txtNroPersonalAdicional.Text);
                txtValorAsistente.Text = cont.CalculoAsistentes().ToString();
                txtValorPersonalAd.Text = cont.CalculoPersonalAdicional().ToString();
                //calcular();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }*/
        }
        
        private void BtnListarContratos_Click(object sender, RoutedEventArgs e)
        {
            ListaContratos l_con = new ListaContratos();
            l_con.Show();
        }

        private void BtnBuscarContrato_Click(object sender, RoutedEventArgs e)
        {
            ListaContratos lc = new ListaContratos(this);
            lc.Show();
        }

        private void TxtNroPersonalAdicional_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                cargarCalculos();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                txtNroPersonalAdicional.Text = "0";
            }
        }

        private void ChkAmbientacionCocktail_Checked(object sender, RoutedEventArgs e)
        {
            cboTipoAmbientacionCocktail.IsEnabled = true;
        }

        private void ChkAmbientacionCocktail_Unchecked(object sender, RoutedEventArgs e)
        {
            cboTipoAmbientacionCocktail.SelectedIndex = -1;
            cargarCalculos();
            cboTipoAmbientacionCocktail.IsEnabled = false;
        }

        private void ChkMusicaAmbientalCocktail_Checked(object sender, RoutedEventArgs e)
        {
            cargarCalculos();
            chkClienteProveeMusica.IsEnabled = true;
        }

        private void ChkMusicaAmbientalCocktail_Unchecked(object sender, RoutedEventArgs e)
        {
            cargarCalculos();
            chkClienteProveeMusica.IsChecked = false;
            chkClienteProveeMusica.IsEnabled = false;
        }

        private void CboTipoAmbientacionCocktail_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargarCalculos();
        }

        private void RbtLocalOnBreak_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                txtValorArriendo.Text = "0";
                rbtOtroLocal.IsChecked = false;
                lblValorArriendo.Visibility = Visibility.Hidden;
                lblComision.Visibility = Visibility.Hidden;
                txtValorArriendo.Visibility = Visibility.Hidden;
                txtComision.Visibility = Visibility.Hidden;
                
                cargarCalculos();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
            }
        }

        private void RbtOtroLocal_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                txtValorArriendo.Text = "0";
                rbtOtroLocal.IsChecked = true;
                lblValorArriendo.Visibility = Visibility.Visible;
                lblComision.Visibility = Visibility.Visible;
                txtValorArriendo.Visibility = Visibility.Visible;
                txtComision.Visibility = Visibility.Visible;
                
                cargarCalculos();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
            }
        }

        private void CboTipoAmbientacionCenas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargarCalculos();
        }

        private void TxtValorArriendo_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                txtComision.Text = (int.Parse(txtValorArriendo.Text) * 0.05)
                    .ToString();
                cargarCalculos();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                txtValorArriendo.Text = "0";
                cargarCalculos();
            }
        }

        private void ChkMusicaAmbientalCenas_Checked(object sender, RoutedEventArgs e)
        {
            cargarCalculos();
        }

        private void BtnLimpiarDatos_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void TxtValorActualUF_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
