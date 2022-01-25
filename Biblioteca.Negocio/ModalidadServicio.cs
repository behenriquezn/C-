using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;

namespace Biblioteca.Negocio
{
    public class ModalidadServicio
    {
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public ModalidadServicio()
        {

        }

        public override string ToString()
        {
            TipoEvento te = new TipoEvento();
            return Nombre;
        }
        OnBreakEntities bdd = new OnBreakEntities();

        public bool Read(){
            try
            {
                DALC.ModalidadServicio ms = bdd.ModalidadServicio.
                    First(m => m.IdModalidad == IdModalidad);
                this.IdModalidad = ms.IdModalidad;
                this.Nombre = ms.Nombre;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Negocio.ModalidadServicio> ReadAll(){
            try
            {
                List<Negocio.ModalidadServicio> lista_clase_modalidad = new List<ModalidadServicio>();
                List<DALC.ModalidadServicio> lista_modalidad = bdd.ModalidadServicio.ToList();
                foreach (DALC.ModalidadServicio item in lista_modalidad)
                {
                    Negocio.ModalidadServicio ms = new ModalidadServicio();
                    
                    ms.Nombre = item.Nombre.Trim();
                    ms.IdTipoEvento = item.IdTipoEvento;
                    ms.IdModalidad = item.IdModalidad;
                    ms.PersonalBase = item.PersonalBase;
                    ms.ValorBase = item.ValorBase;
                    lista_clase_modalidad.Add(ms);
                }
                return lista_clase_modalidad;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
