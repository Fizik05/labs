using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_ex
{
    internal class EuropeanDateTime: IDateTimePrinter
    {
        public string DateTimePrinter()
        {
            CultureInfo client = new CultureInfo("ru-RU");
            return DateTime.Now.ToString(client);
        }
    }
}
