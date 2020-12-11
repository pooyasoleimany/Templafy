using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Node
    {
        private List<Node> _children;
        public Node Parent { get; set; }
        public int Data { get; private set; }


        public Node(int data, params Node[] nodes)
        {
            Data = data;
            AddRange(nodes);
        }

  

        public IEnumerable<Node> Children
        {
            get
            {
                return _children != null
                    ? _children
                    : Enumerable.Empty<Node>();
            }
        }

       

        public void Add(Node node)
        {
            Debug.Assert(node.Parent == null);

            if (_children == null)
            {
                _children = new List<Node>();
            }

            _children.Add(node);
            node.Parent = this;
        }

        public void AddRange(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
