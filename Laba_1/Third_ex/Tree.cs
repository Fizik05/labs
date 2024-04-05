using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_ex
{
    internal class Tree
    {
        public int _value { get; }
        List<Tree> _children {  get; }
        public Tree(int value)
        {
            _value = value;
            _children = new List<Tree>();
        }
        public void addChild(Tree child)
        {
            _children.Add(child);
        }
        public void Read()
        {
            if (_children.Count == 0) return;
            Console.Write($"{_value}'s children: ");
            foreach (var i in _children)
            {
                Console.Write($"{i._value} ");
            }
            Console.WriteLine();
            foreach (var i in _children)
            {
                i.Read();
            }
        }
    }
}
