Introduction
We have a tree that is built using the class Node where an instance of the class represents a node in the tree. For simplicity, the node has a single data field of type int.

Your task is to write the extension method NodeExtensions.Previous() to find the previous element in the tree. You can write as many helper methods as you want, but don't change the signature of the extension method NodeExtensions.Previous().

You can use the "Sample Tests" tab to test your code. In this tab, there is a test where a tree is created, and your method is used to walk the tree, while the result is being verified against what is expected. You can use this test to test your implementation. Feel free to add any number of additional unit tests here, but you should add at least one unit test in addition to the one already there.

The code you submit should be exactly as if this was code you were checking in and creating a pull request for, in your day-to-day work. When we review your submission, we will review it as if it was a pull request.

In summary:

Implement the method NodeExtensions.Previous()
Add at least one unit test
Your solution should work for all trees and not just for the example in the sample test.
We favor readability over performance. But we do care about performance.
Additional information
You can use any online resources you want (Google, Stack Overflow etc)
You can use your own editor to develop the solution in, and paste the code into the online IDE
There is no time limit for this challenge. You can use as much time as you want.
When you submit your solution, a list of unit tests will be executed against your solution and the result will be shown to you. You cannot see the source code for these unit tests.
The Node class
The Node class looks like this:

public class Node
{

    private List<Node> _children;

    public Node(int data, params Node[] nodes)
    {
        Data = data;
        AddRange(nodes);
    }

    public Node Parent { get; set; }

    public IEnumerable<Node> Children
    {
        get
        {
            return _children != null
                ? _children
                : Enumerable.Empty<Node>();
        }
    }

    public int Data { get; private set; }

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
