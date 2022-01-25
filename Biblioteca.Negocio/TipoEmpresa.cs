using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;

namespace Biblioteca.Negocio
{
    public class TipoEmpresa
    {
        public int IdTipoEmpresa { get; set; }
        public string Descripcion { get; set; }

        public TipoEmpresa()
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
                DALC.TipoEmpresa tipo =
                    bdd.TipoEmpresa.First(t => t.IdTipoEmpresa == IdTipoEmpresa);
                this.IdTipoEmpresa = tipo.IdTipoEmpresa;
                this.Descripcion = tipo.Descripcion;
                return true;

                   
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Negocio.TipoEmpresa> ReadAll()
        {
            try
            {
                List<Negocio.TipoEmpresa> lista_clase_tipoemp = new List<TipoEmpresa>();
                List<DALC.TipoEmpresa> lista_tipoemp = bdd.TipoEmpresa.ToList();
                foreach (DALC.TipoEmpresa item in lista_tipoemp)
                {
                    Negocio.TipoEmpresa tipo = new TipoEmpresa();
                    tipo.IdTipoEmpresa = item.IdTipoEmpresa;
                    tipo.Descripcion = item.Descripcion;
                    lista_clase_tipoemp.Add(tipo);
                }
                return lista_clase_tipoemp;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
