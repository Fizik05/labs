using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_ex.Decorators
{
    internal class HIDecorator : Decorator
    {
        private string _prefix;

        public HIDecorator(IDateTimePrinter dateTime, string prefix) : base(dateTime)
        {
            _prefix = prefix;
        }

        public override string DateTimePrinter()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_prefix);
            sb.Append(dateTime.DateTimePrinter());
            return sb.ToString();
        }
    }
}
