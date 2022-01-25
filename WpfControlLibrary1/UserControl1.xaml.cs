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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Biblioteca.Negocio;

namespace WpfControlLibrary1
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            dtpFecha.DisplayDateStart = DateTime.Now;
            dtpFecha.DisplayDateEnd = DateTime.Now.AddMonths(8);

            for (int i = 0; i < 24; i++)
            {
                cboHora.Items.Add(i);
            }

            for (int i = 0; i < 60; i++)
            {
                cboMinutos.Items.Add(i);
            }
        }


        public void VerFechaYHora(DateTime fyh)
        {
            try
            {
                dtpFecha.Text = fyh.ToString("dd/MM/yyyy");
                string hora = fyh.ToString("HH");
                string minutos = fyh.ToString("mm");
                if (hora.Substring(0, 1) == "0")
                {
                    hora = hora.Substring(1, 1);
                }
                if (minutos.Substring(0, 1) == "0")
                {
                    minutos = minutos.Substring(1, 1);
                }
                cboHora.Text = hora;
                cboMinutos.Text = minutos;

                cboHora.Text = hora;
                cboMinutos.Text = minutos;
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                throw new ArgumentException("No se puede visualizar la fecha. ");
            }
        }


        public DateTime RecuperarFechaYHora()
        {
            try
            {
                int anno = ((DateTime)dtpFecha.SelectedDate).Year;
                int mes = ((DateTime)dtpFecha.SelectedDate).Month;
                int dia = ((DateTime)dtpFecha.SelectedDate).Day;
                int hora = int.Parse(cboHora.SelectedValue.ToString());
                int min = int.Parse(cboMinutos.SelectedValue.ToString());

                DateTime fyh = new DateTime(anno, mes, dia, hora, min, 0);

                //return fyh;
                if (fyh>=fyh)
                {
                    return fyh;
                }
                else
                {
                    throw new ArgumentException("Error, no debe ser menor a la fecha de hoy."); ;
                }
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                throw new ArgumentException ("Error en recuperar datos");////
            }
        }

        public void LimpiarFechaYHora()
        {
            dtpFecha.SelectedDate = DateTime.Now;
            cboHora.SelectedIndex = -1;
            cboMinutos.SelectedIndex = -1;
        }
    }
}
