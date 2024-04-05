using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_ex
{
    abstract class Decorator: IDateTimePrinter
    {
        protected IDateTimePrinter dateTime;

        public Decorator(IDateTimePrinter dateTime)
        {
            this.dateTime = dateTime;
        }

        public abstract string DateTimePrinter();
    }
}
