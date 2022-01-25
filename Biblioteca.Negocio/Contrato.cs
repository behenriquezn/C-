using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DALC;
namespace Biblioteca.Negocio
{
    public class Contrato : IMetodos
    {
        private string _numero;

        public string Numero
        {
            get { return _numero; }
            set {
                if (value.Trim().Length > 0)
                {
                    _numero = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Numero");
                }
            }
        }

        public DateTime Creacion { get; set; }
        public DateTime Termino { get; set; }
        private string _rut;

        public string RutCliente
        {
            get { return _rut; }
            set
            {
                if (value.Trim().Length > 0)
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese un Rut");
                }
            }
        }

        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        private string _observaciones;

        public string Observaciones
        {
            get { return _observaciones; }
            set {
                if (value.Trim().Length > 0)
                {
                    _observaciones = value;
                }
                else
                {
                    throw new ArgumentException("Ingrese observaciones");
                }
            }
        }

        //public Cliente cli { get; set; }

        public Contrato()
        {

        }
        OnBreakEntities bdd = new OnBreakEntities();

        public bool Create(){
            try
            {
                DALC.Contrato cont = new DALC.Contrato();
                CommonBC.Syncronize(this, cont);
                bdd.Contrato.Add(cont);
                bdd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return false;
            }
        }

        public bool Read(){
            try
            {
                DALC.Contrato cont = bdd.Contrato
                    .First(c => c.Numero.Equals(this.Numero));
                CommonBC.Syncronize(cont, this);
                return true;
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return false;
            }
        }


        public List<Contrato> ReadAll(){
            try
            {
                List<Contrato> listaClase = new List<Contrato>();
                List<DALC.Contrato> listaBDD = bdd.Contrato.ToList();
                foreach (DALC.Contrato item in listaBDD)
                {
                    Contrato c = new Contrato();
                    CommonBC.Syncronize(item, c);
                    listaClase.Add(c);
                }
                return listaClase;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<Contrato> ReadAllbyTipoEvento()
        {
            try
            {
                return ReadAll().Where(c => c.IdTipoEvento == IdTipoEvento).ToList();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }
        public List<Contrato> ReadAllbyModalidadServicio()
        {
            try
            {
                return ReadAll().Where(c => c.IdModalidad == IdModalidad).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Update()
        {
            try
            {
                DALC.Contrato con =
                    bdd.Contrato.
                    First(c => c.Numero.Equals(Numero));

                CommonBC.Syncronize(this, con);
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
                DALC.Contrato cont = bdd.Contrato
                    .First(c => c.Numero.Equals(this.Numero));
                cont.Termino = DateTime.Now;
                cont.Realizado = false;
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ContratosFinalizados(){
            var x = bdd.Contrato
                .Where(c => c.FechaHoraTermino < DateTime.Now && c.Realizado == true);
            foreach (DALC.Contrato item in x.ToList())
            {
                item.Termino = DateTime.Now;
                bdd.SaveChanges();
            }
            return true;
        }
        
        /*public double CalculoAsistentes(){
            double vc = 0;
            if (Asistentes>=1 && Asistentes<=20)
            {
                vc = (vc + 3)* 28710;
            }
            if (Asistentes >= 21 && Asistentes <= 50)
            {
                vc = (vc + 5)*28710;
            }
            if (Asistentes>50)
            {
                int calculo = Asistentes - 50;
                vc = (((calculo/20)*2) + 5)* 28710;
            }
            return vc;
        }
        public double CalculoPersonalAdicional(){
            double pa = 0;
            if (PersonalAdicional<=2)
            {
                pa = (pa + 2)* 28710;
            }
            if (PersonalAdicional==3)
            {
                pa = (pa + 3)* 28710;
            }
            if (PersonalAdicional==4)
            {
                pa = (pa + 3.5)* 28710;
            }
            if (PersonalAdicional>4)
            {
                pa = ((pa + 3.5)+0.5 * PersonalAdicional-4)* 28710;
            }
            return pa;
        }
        public double CalculoTipoEvento()
        {
            ModalidadServicio ms = new ModalidadServicio();
            if (IdTipoEvento==ms.IdTipoEvento)
            {
                return (ms.ValorBase)* 28710;
            }
            return (ms.ValorBase)* 28710;
        }

        public double CalculoValorTotal
        {
            get
            {
                ModalidadServicio moda = new ModalidadServicio();
                moda.IdModalidad = IdModalidad;
                moda.Read();
                double valor_base = moda.ValorBase;
                double vc = 0;
                double pa = 0;
                double total = 0;
                if (Asistentes >= 1 && Asistentes <= 20)
                {
                    vc =( vc + 3)* 28710;
                }
                else if (Asistentes >= 21 && Asistentes <= 50)
                {
                    vc = (vc + 5)* 28710;
                }
                else
                {
                    int calculo = Asistentes - 50;
                    vc = (((calculo / 20) * 2)+5)* 28710;
                }

                if (PersonalAdicional == 2)
                {
                    pa = (pa + 2)* 28710;
                }
                else if (PersonalAdicional == 3)
                {
                    pa = (pa + 3)* 28710;
                }
                else if (PersonalAdicional == 4)
                {
                    pa = (pa + 3.5)* 28710;
                }
                else
                {
                    pa = (3.5 + (0.5* (PersonalAdicional-4)))* 28710;
                }

                return total= -+ valor_base -+ vc -+ pa;
            }
        }*/
        
        public List<ClistaContrato> ReadAll2()
        {
            try
            {
                var x = from con in new Contrato().ReadAll()
                        join te in bdd.TipoEvento
                        on con.IdTipoEvento equals te.IdTipoEvento
                        join ms in bdd.ModalidadServicio
                        on con.IdModalidad equals ms.IdModalidad
                        select new ClistaContrato()
                        {
                            NUMERO = con.Numero,
                            CREACION = con.Creacion,
                            TERMINO = con.Termino,
                            RUTCLIENTE = con.RutCliente,
                            MODALIDAD = ms.Nombre,
                            TIPOEVENTO = te.Descripcion,//te.Descripcion
                            FECHA_HORAINICIO = con.FechaHoraInicio,
                            FECHA_HORATERMINO = con.FechaHoraTermino,
                            ASISTENTES = con.Asistentes,
                            PERSONAL_ADICIONAL = con.PersonalAdicional,
                            REALIZADO = con.Realizado,
                            VALOR_TOTAL_CONTRATO = con.ValorTotalContrato,
                            OBSERVACIONES = con.Observaciones
                        };
                return x.ToList();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }
        public List<ClistaContrato> ReadallByTipoEvento2()
        {
            try
            {
                var x = from con in new Contrato().ReadAll()
                        join te in bdd.TipoEvento
                        on con.IdTipoEvento equals te.IdTipoEvento
                        join ms in bdd.ModalidadServicio
                        on con.IdModalidad equals ms.IdModalidad
                        where te.IdTipoEvento == this.IdTipoEvento
                        select new ClistaContrato()
                        {
                            NUMERO = con.Numero,
                            CREACION = con.Creacion,
                            TERMINO = con.Termino,
                            RUTCLIENTE = con.RutCliente,
                            MODALIDAD = ms.Nombre,
                            TIPOEVENTO = te.Descripcion,//te.Descripcion
                            FECHA_HORAINICIO = con.FechaHoraInicio,
                            FECHA_HORATERMINO = con.FechaHoraTermino,
                            ASISTENTES = con.Asistentes,
                            PERSONAL_ADICIONAL = con.PersonalAdicional,
                            REALIZADO = con.Realizado,
                            VALOR_TOTAL_CONTRATO = con.ValorTotalContrato,
                            OBSERVACIONES = con.Observaciones
                        };
                return x.ToList();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }
        public List<ClistaContrato> ReadAllByModalidadServicio2()
        {
            try
            {
                var x = from con in new Contrato().ReadAll()
                        join te in bdd.TipoEvento
                        on con.IdTipoEvento equals te.IdTipoEvento
                        join ms in bdd.ModalidadServicio
                        on con.IdModalidad equals ms.IdModalidad
                        where ms.IdModalidad == this.IdModalidad
                        select new ClistaContrato()
                        {
                            NUMERO = con.Numero,
                            CREACION = con.Creacion,
                            TERMINO = con.Termino,
                            RUTCLIENTE = con.RutCliente,
                            MODALIDAD = ms.Nombre,
                            TIPOEVENTO = te.Descripcion,//te.Descripcion
                            FECHA_HORAINICIO = con.FechaHoraInicio,
                            FECHA_HORATERMINO = con.FechaHoraTermino,
                            ASISTENTES = con.Asistentes,
                            PERSONAL_ADICIONAL = con.PersonalAdicional,
                            REALIZADO = con.Realizado,
                            VALOR_TOTAL_CONTRATO = con.ValorTotalContrato,
                            OBSERVACIONES = con.Observaciones
                        };
                return x.ToList();
            }
            catch (Exception ex)
            {
                Logger.mensaje(ex.Message);
                return null;
            }
        }
    }
}
