using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;

namespace Biblioteca.Negocio
{
    public class Cocktail : Evento
    {
        public string Numero { get; set; }
        public int IdTipoAmbientacion { get; set; }
        public bool Ambientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool MusicaCliente { get; set; }
        public Cocktail()
        {

        }

        OnBreakEntities bdd = new OnBreakEntities();

        public bool Create()
        {
            try
            {
                DALC.Cocktail c = new DALC.Cocktail();
                CommonBC.Syncronize(this, c);
                bdd.Cocktail.Add(c);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                DALC.Cocktail c = bdd.Cocktail.Find(this.Numero);
                CommonBC.Syncronize(c, this);
                bdd.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                DALC.Cocktail c = bdd.Cocktail.Find(this.Numero);
                Contrato con = new Contrato() { Numero = this.Numero };
                con.Read();
                if (con.Realizado)
                {
                    if (c == null)
                    {
                        DALC.CoffeeBreak coff = bdd.CoffeeBreak.Find(this.Numero);
                        if (coff == null)
                        {
                            DALC.Cenas cen = bdd.Cenas.Find(this.Numero);
                            bdd.Cenas.Remove(cen);
                            bdd.SaveChanges();
                        }
                        else
                        {
                            bdd.CoffeeBreak.Remove(coff);
                            bdd.SaveChanges();
                        }
                        c = new DALC.Cocktail();
                        CommonBC.Syncronize(this, c);
                        bdd.Cocktail.Add(c);
                        bdd.SaveChanges();
                    }
                    CommonBC.Syncronize(this, c);
                    bdd.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                DALC.Cocktail c = bdd.Cocktail.Find(this.Numero);
                bdd.Cocktail.Remove(c);
                bdd.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return false;
            }
        }

        public override double ValorBase()
        {
            string modalidad = base.cont.IdModalidad;
            ModalidadServicio m = new ModalidadServicio();
            m.IdModalidad = modalidad;
            m.Read();
            double valor_base = m.ValorBase;
            return valor_base;
        }

        public override double RecargoAsistentes()
        {
            double recargo = 0;
            int ra = base.cont.Asistentes;
            if (ra >= 1 && ra <= 20)
            {
                recargo = 4;
            }
            else if (ra >= 21 && ra <= 50)
            {
                recargo = 6;
            }
            else if (ra > 50)
            {
                recargo = 6 + (((ra - 50) / 20) * 2);
            }
            return recargo;
        }

        public override double RecargoPersonalAdicional()
        {
            double recargo = 0;
            int pa = base.cont.PersonalAdicional;
            if (pa == 2)
            {
                recargo = 2;
            }
            else if (pa == 3)
            {
                recargo = 3;
            }
            else if (pa > 3)
            {
                recargo = 3 + ((pa - 3) * 0.5);
            }
            return recargo;
        }

        public override double RecargoExtras()
        {
            double ambientacion = 0;
            double musica_ambiental = 0;
            TipoAmbientacion ta = new TipoAmbientacion();
            ta.IdTipoAmbientacion = this.IdTipoAmbientacion;
            ta.Read();
            if (ta.Descripcion == null)
            {
                ambientacion = 0;
            }
            else if (ta.Descripcion.Equals("Básica"))
            {
                ambientacion = 2;
            }
            else if (ta.Descripcion.Equals("Personalizada"))
            {
                ambientacion = 5;
            }
            if (MusicaAmbiental)
            {
                musica_ambiental = 1;
            }
            return ambientacion + musica_ambiental;

        }
    }

}
