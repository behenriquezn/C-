using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Negocio
{
    interface IMetodos
    {
        bool Create();
        bool Update();
        bool Delete();
        bool Read();
    }
}
