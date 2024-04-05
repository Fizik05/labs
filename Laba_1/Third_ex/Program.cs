namespace Third_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree batya = new Tree(1);
            Tree child1 = new Tree(2);
            Tree child2 = new Tree(3);
            Tree grandchild11 = new Tree(4);
            Tree grandchild21 = new Tree(5);
            Tree grandchild12 = new Tree(6);
            Tree doubleGrandchild = new Tree(7);

            batya.addChild(child1);
            batya.addChild(child2);

            child1.addChild(grandchild11);
            child1.addChild(grandchild21);

            child2.addChild(grandchild12);

            grandchild21.addChild(doubleGrandchild);

            batya.Read();
        }
    }
}