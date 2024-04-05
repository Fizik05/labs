namespace First_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            int aa, bb;
            aa = int.Parse(Console.ReadLine());
            bb = int.Parse(Console.ReadLine());
            Decimal a = new Decimal(aa, bb);
            Decimal b = new Decimal(1, -10);
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Decimal c = a - b;
            Console.WriteLine((float)aa / (float)bb);
        }
    }
}