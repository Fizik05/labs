using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_ex.Decorators
{
    internal class TIDecorator: Decorator
    {
        string _suffix;
        public TIDecorator(IDateTimePrinter dateTime, string suffix) : base(dateTime)
        {
            _suffix = suffix;
        }

        public override string DateTimePrinter()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(dateTime.DateTimePrinter());
            sb.Append(_suffix);
            return sb.ToString();
        }
    }
}
