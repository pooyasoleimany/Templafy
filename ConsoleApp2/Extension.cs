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

            var parentCurrentNode = node.Parent;
            if (CheckParentCurrentNodeIsNull(parentCurrentNode)) return null;


            if (CheckThisNodeIsFirstChildOfParent(node, parentCurrentNode)) return parentCurrentNode;


            if (parentCurrentNode.Parent == null) // node in level 1
            {
                TraceLeftSideOfThisNode(node, parentCurrentNode);
                return NodeStack.Pop();
            }
            else
            {
                var previousSiblingNode = GetPreviousSiblingThisNode(node, parentCurrentNode);
                return previousSiblingNode;

            }
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

        private static bool CheckParentCurrentNodeIsNull(Node node)
        {
            if (node == null)
                return true;
            else
                return false;
        }

        private static bool CheckThisNodeIsFirstChildOfParent(Node node, Node parent)
        {
            var firstChildParentNode = parent.Children.First();
            if (node == firstChildParentNode) // node is the first child
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void TraceLeftSideOfThisNode(Node node, Node parentCurrentNode)
        {
            for (int i = 0; i <= parentCurrentNode.Children.Count(); i++)
            {
                if (parentCurrentNode.Children.ElementAt(i) == node)
                {
                    GetLastLeave(parentCurrentNode.Children.ElementAt(i - 1));
                    break;
                }
            }

        }

        private static Node GetPreviousSiblingThisNode(Node node, Node parentCurrentNode)
        {
            for (int i = 0; i <= parentCurrentNode.Children.Count(); i++)
            {
                if (parentCurrentNode.Children.ElementAt(i) == node)
                {
                    return parentCurrentNode.Children.ElementAt(i - 1);

                }

            }
            return null;

        }
    }
}
