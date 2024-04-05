using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Second_ex.Decorators
{
    internal class IDecorator: Decorator
    {
        string _prefix, _suffix;
        public IDecorator(IDateTimePrinter dateTime, string prefix, string suffix) : base(dateTime)
        {
            _prefix = prefix;
            _suffix = suffix;
        }

        public override string DateTimePrinter()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_prefix);
            sb.Append(dateTime.DateTimePrinter());
            sb.Append(_suffix);
            return sb.ToString();
        }
    }
}
