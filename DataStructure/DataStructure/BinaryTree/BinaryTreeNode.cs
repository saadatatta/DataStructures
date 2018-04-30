
using System;

public class BinaryTreeNode
{
    public BinaryTreeNode left { get; set; }
    
    public BinaryTreeNode right { get; set; }

    public int data { get; private set; }

    public BinaryTreeNode(int data)
    {
        this.data = data;
        this.left = null;
        this.right = null;
    }
}