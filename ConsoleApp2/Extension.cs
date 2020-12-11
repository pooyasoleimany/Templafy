using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{

    public static class NodeExtensions
    {

        private static readonly Stack<Node> NodeStack = new Stack<Node>();
        public static Node Previous(this Node node)
        {

            var parentNode = node.Parent;
            if (CheckParentNodeIsNull(parentNode)) return null;

            if (CheckThisNodeIsFirstChildOfParent(node, parentNode)) return parentNode;

            var previousSiblingNode = GetPreviousThisNode(node, parentNode);
            return previousSiblingNode;

        }


        public static void GetLastLeave(Node node)
        {
            if (node.Children.Count() == 0)
            {
                NodeStack.Push(node);
            }
            else
            {
                foreach (Node child in node.Children)
                {
                    NodeStack.Push(child);
                    GetLastLeave(child); //<-- recursive
                }
            }

        }

        private static bool CheckParentNodeIsNull(Node parent)
        {
            if (parent == null)
                return true;
            else
                return false;
        }

        private static bool CheckThisNodeIsFirstChildOfParent(Node node, Node parent)
        {
            var firstChildParentNode = parent.Children.First();
            if (node == firstChildParentNode) // node is the first child
                return true;
            else
                return false;

        }


        private static Node GetPreviousThisNode(Node node, Node parent)
        {
            for (int i = 0; i <= parent.Children.Count(); i++)
            {
            
                if (parent.Children.ElementAt(i) == node)
                {
                    if(parent.Children.ElementAt(i - 1).Children.Count()==0)
                    return parent.Children.ElementAt(i - 1);

                    else
                    {
                        GetLastLeave(parent.Children.ElementAt(i - 1));
                        return NodeStack.Pop();
                    }

                }

            }
            return null;

        }
    }
}
