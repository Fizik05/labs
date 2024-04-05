using Second_ex.Decorators;

namespace Second_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            EuropeanDateTime europe = new EuropeanDateTime();
            Console.WriteLine(europe.DateTimePrinter());

            AmericanDateTime american = new AmericanDateTime();
            Console.WriteLine(american.DateTimePrinter());

            HIDecorator headInDecorator = new HIDecorator(europe, "PREFIX ");
            Console.WriteLine(headInDecorator.DateTimePrinter());

            TIDecorator tailInDecorator = new TIDecorator(headInDecorator, " SUFFIX");
            Console.WriteLine(tailInDecorator.DateTimePrinter());

            TIDecorator tailInDecorator1 = new TIDecorator(tailInDecorator, " SUFFIX");
            Console.WriteLine(tailInDecorator1.DateTimePrinter());
        }
    }
}