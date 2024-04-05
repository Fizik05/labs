using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_ex
{
    internal class AmericanDateTime: IDateTimePrinter
    {
        public string DateTimePrinter()
        {
            CultureInfo client = new CultureInfo("en-EN");
            return DateTime.Now.ToString(client);
        }
    }
}
