using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;

namespace Biblioteca.Negocio
{
    public class Cliente : IMetodos
    {
        private string _rutCliente;

        public string RutCliente
        {
            get { return _rutCliente; }
            set {
                if (value.Trim().Length>=9 && value.Trim().Length<=10)
                {
                    _rutCliente = value;
                }
                else
                {
                    throw new ArgumentException("Rut Invalido");
                }
            }
        }

        private string _razonSocial;

        public string RazonSocial
        {
            get { return _razonSocial; }
            set {
                if (value.Trim().Length>0)
                {
                    _razonSocial = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese una Razon Social");
                }
            }
                
        }

        private string _nombreContacto;

        public string NombreContacto
        {
            get { return _nombreContacto; }
            set {
                if (value.Trim().Length>0)
                {
                    _nombreContacto = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Nombre de Contacto");
                }
            }
        }

        private string _mailContacto;

        public string MailContacto
        {
            get { return _mailContacto; }
            set {
                if (value.Trim().Length>0)
                {
                    _mailContacto = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Mail de Contacto");
                }
            }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set {
                if (value.Trim().Length>0)
                {
                    _direccion = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese una Direccion");
                }
            }
        }

        private string _telefono;

        public string Telefono
        {
            get { return _telefono; }
            set {
                if (value.Trim().Length>0)
                {
                    _telefono = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Telefono");
                }
            }
        }

        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }

        public Cliente()
        {
                
        }
        //metodos
        OnBreakEntities bdd = new OnBreakEntities();

        public bool Create(){
            try
            {
                DALC.Cliente cli = new DALC.Cliente();

                CommonBC.Syncronize(this, cli);

                bdd.Cliente.Add(cli);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update()
        {
            try
            {
                DALC.Cliente cli =
                    bdd.Cliente.
                    First(c => c.RutCliente.Equals(RutCliente));

                CommonBC.Syncronize(this, cli);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete()
        {
            try
            {
                DALC.Cliente cli =
                    bdd.Cliente.
                    First(c => c.RutCliente.Equals(RutCliente));

                bdd.Cliente.Remove(cli);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Read()
        {
            try
            {
                DALC.Cliente cli =
                    bdd.Cliente.
                    First(c => c.RutCliente.Equals(RutCliente));

                CommonBC.Syncronize(cli, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<Cliente> ReadAll()
        {
            try
            {
                List<Cliente> listaClases = new List<Cliente>();
                foreach (DALC.Cliente item in bdd.Cliente.ToList())
                {
                    Cliente c = new Cliente();
                    CommonBC.Syncronize(item, c);
                    listaClases.Add(c);

                }
                return listaClases;

            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }
        public List<Cliente> ReadAllbyTipoEmpresa()
        {
            try
            {
                return ReadAll().Where(c => c.IdTipoEmpresa == IdTipoEmpresa).ToList(); 
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }
        public List<Cliente> ReadAllbyActividadEmpresa()
        {
            try
            {
                return ReadAll()
                    .Where(c => c.IdActividadEmpresa == IdActividadEmpresa).ToList();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }
        public List<Cliente> ReadAllbyRut()
        {
            try
            {
                return ReadAll()
                    .Where(c => c.RutCliente == RutCliente).ToList();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }

        // EL READ ALL se hace con un LINQ dejando que una queri muestre las descripciones de los combos en el datagrid
        //Tambien con eso se crea una clase llamada "CListaClientes"
        public List<CListaClientes> ReadAll2()
        {
            var x = from cli in new Cliente().ReadAll()
                    join act in bdd.ActividadEmpresa 
                    on cli.IdActividadEmpresa equals act.IdActividadEmpresa
                    join tipo in bdd.TipoEmpresa on cli.IdTipoEmpresa equals tipo.IdTipoEmpresa
                    select new CListaClientes()
                    {
                        RUT = cli.RutCliente,
                        NOMBRECONTACTO = cli.NombreContacto,
                        RAZONSOCIAL = cli.RazonSocial,
                        MAIL = cli.MailContacto,
                        DIRECCION = cli.Direccion,
                        TELEFONO = cli.Telefono,
                        ACTIVIDADEMPRESA = act.Descripcion,
                        TIPOEMPRESA = tipo.Descripcion
                    };
            return x.ToList();
        }
        public List<CListaClientes> ReadAllByTipoEmpresa2()
        {
            var x = from cli in new Cliente().ReadAll()
                    join act in bdd.ActividadEmpresa on cli.IdActividadEmpresa equals act.IdActividadEmpresa
                    join tipo in bdd.TipoEmpresa on cli.IdTipoEmpresa equals tipo.IdTipoEmpresa
                    where tipo.IdTipoEmpresa == this.IdTipoEmpresa
                    select new CListaClientes()
                    {
                        RUT = cli.RutCliente,
                        NOMBRECONTACTO = cli.NombreContacto,
                        RAZONSOCIAL = cli.RazonSocial,
                        MAIL = cli.MailContacto,
                        DIRECCION = cli.Direccion,
                        TELEFONO = cli.Telefono,
                        ACTIVIDADEMPRESA = act.Descripcion,
                        TIPOEMPRESA = tipo.Descripcion
                    };
            return x.ToList();
        }
        public List<CListaClientes> ReadAllByActividadEmpresa2()
        {
            var x = from cli in new Cliente().ReadAll()
                    join act in bdd.ActividadEmpresa on cli.IdActividadEmpresa equals act.IdActividadEmpresa
                    join tipo in bdd.TipoEmpresa on cli.IdTipoEmpresa equals tipo.IdTipoEmpresa
                    where act.IdActividadEmpresa == this.IdActividadEmpresa
                    select new CListaClientes()
                    {
                        RUT = cli.RutCliente,
                        NOMBRECONTACTO = cli.NombreContacto,
                        RAZONSOCIAL = cli.RazonSocial,
                        MAIL = cli.MailContacto,
                        DIRECCION = cli.Direccion,
                        TELEFONO = cli.Telefono,
                        ACTIVIDADEMPRESA = act.Descripcion,
                        TIPOEMPRESA = tipo.Descripcion
                    };
            return x.ToList();
        }
    }
}
