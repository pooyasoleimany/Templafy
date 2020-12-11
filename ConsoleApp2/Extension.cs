/*
Name changes 
    CheckThisNodeIsFirstChildOfParent => IsFirstChild
    GetPreviousThisNode => GetPreviousSibling 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp2
{

	public static class NodeExtensions
	{
		public static Node Previous(this Node node)
		{

			var parent = node.Parent;
			if (parent == null) return null;

			if (parent.IsFirstChild(node)) return parent;

			var leftSibling = node.GetLeftSibling();
			var previous = leftSibling.GetLastInSubtree();
			
			return previous;
		}

		private static Node GetLeftSibling(this Node rightChild)
		{
			Node previousChild = null;
			foreach (var child in rightChild.Parent.Children)
			{
				if (child == rightChild)
					break;
					
				previousChild = child;
			}
			return previousChild;
		}

		private static Node GetLastInSubtree(this Node node)
		{
			while (node.Children.Any())
				node = node.Children.Last();
			return node;
		}

		private static bool IsFirstChild(this Node parent, Node node) =>
			parent.Children.FirstOrDefault() == node;
	}
}
