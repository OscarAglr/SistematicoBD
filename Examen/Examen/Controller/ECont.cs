using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Controller
{
    class ECont
    {
        public DataTable MostrarTablas(Model.Model m)
        {
            return m.MostrarTabla();
        }
    }
}
