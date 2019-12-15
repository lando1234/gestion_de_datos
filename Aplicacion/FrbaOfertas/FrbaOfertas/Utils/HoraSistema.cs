using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Utils
{
    class HoraSistema
    {

        public static DateTime get(){
            return DateTime.Parse(FrbaOfertas.Config.configurationsDb.Default.fechaSistema);
        }

    }
}
