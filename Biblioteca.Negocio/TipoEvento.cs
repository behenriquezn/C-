using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;

namespace Biblioteca.Negocio
{
    public class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }

        public TipoEvento()
        {

        }
        public override string ToString()
        {
            return Descripcion;
        }

        // METODOS.

        OnBreakEntities bdd = new OnBreakEntities();

        public bool Read()
        {
            try
            {
                DALC.TipoEvento tipoev = bdd.TipoEvento.
                    First(e => e.IdTipoEvento == IdTipoEvento);
                this.IdTipoEvento = tipoev.IdTipoEvento;
                this.Descripcion = tipoev.Descripcion;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Negocio.TipoEvento> ReadAll()
        {
            try
            {
                List<Negocio.TipoEvento> lista_clase_tipoeven = new List<TipoEvento>();
                List<DALC.TipoEvento> lista_evento = bdd.TipoEvento.ToList();
                foreach (DALC.TipoEvento item in lista_evento)
                {
                    Negocio.TipoEvento tipoev = new TipoEvento();
                    tipoev.IdTipoEvento = item.IdTipoEvento;
                    tipoev.Descripcion = item.Descripcion;
                    lista_clase_tipoeven.Add(tipoev);
                }
                return lista_clase_tipoeven;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
