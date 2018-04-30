
using System;
using System.Collections.Generic;

public class BinaryTree
{
    BinaryTreeNode root;

    public BinaryTree()
    {
        this.root = null;
    }

    public BinaryTree(BinaryTreeNode root)
    {
        this.root = root;
    }

    public void PrintTreeLevelOrder()
    {
        if (root == null) return;

        Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
        queue.Enqueue(root);

        Console.WriteLine("Printing Tree");
        Console.WriteLine("\n\n");
        while (true)
        {
            int size = queue.Count;

            if (size == 0) break;

            while (size > 0)
            {
                BinaryTreeNode current = queue.Dequeue();

                if (current.left != null)
                    queue.Enqueue(current.left);

                if (current.right != null)
                    queue.Enqueue(current.right);

                Console.Write("\t" + current.data);
                size--;
            }
            Console.WriteLine("\n");
        }
    }

    public void PrintTreeInOrder()
    {
        if (root == null) return;

        Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();

        BinaryTreeNode current = root;

        while(current != null)
        {
            stack.Push(current);
            current = current.left;
        }

        while(stack.Count > 0)
        {
            BinaryTreeNode node = stack.Pop();
            Console.Write("\t" + node.data);

            current = node.right;

            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
        }
    }

    public void PrintTreeInOrderRecursive(BinaryTreeNode root)
    {
        if (root == null) return;

        PrintTreeInOrderRecursive(root.left);
        Console.WriteLine(root.data);
        PrintTreeInOrderRecursive(root.right);
    }

    public void MorrisInOrderTraversal()
    {
        if (root == null) return;

        BinaryTreeNode current = root;
        BinaryTreeNode predecessor = null;

        while(current != null)
        {
            if(current.left == null)
            {
                Console.Write("\t" + current.data);
                current = current.right;
            }
            else
            {
                predecessor = current.left;

                while (predecessor.right != null && predecessor.right != current)
                {
                    predecessor = predecessor.right;
                }

                if(predecessor.right == null)
                {
                    predecessor.right = current;
                    current = current.left;
                }
                else // predecessor right is current node.
                     // Left is already visited. Go right after visiting.
                {
                    predecessor.right = null;
                    Console.Write("\t "+ current.data);
                    current = current.right;
                }
            }
        }
        Console.WriteLine("\n");
    }

    public void MorrisPreOrderTraversal()
    {
        if (root == null) return;

        BinaryTreeNode current = root;
        BinaryTreeNode predecessor = null;

        while (current != null)
        {
            if (current.left == null)
            {
                Console.Write("\t" + current.data);
                current = current.right;
            }
            else
            {
                predecessor = current.left;

                while (predecessor.right != null && predecessor.right != current)
                {
                    predecessor = predecessor.right;
                }

                if (predecessor.right == null)
                {
                    predecessor.right = current;
                    Console.Write("\t " + current.data);// This is where we print node.
                                                        //Different from Inorder where we print in else part.
                    current = current.left;
                }
                else // predecessor right is current node.
                     // Left is already visited. 
                {
                    predecessor.right = null;
                    current = current.right;
                }
            }
        }
        Console.WriteLine("\n");
    }

    public void PostOrderTraversalUsingOneStack()
    {
        /* Algorithm
            1.1 Create an empty stack
            2.1 Do following while root is not NULL
                a) Push root's right child and then root to stack.
                b) Set root as root's left child.
            2.2 Pop an item from stack and set it as root.
                a) If the popped item has a right child and the right child 
                   is at top of stack, then remove the right child from stack,
                   push the root back and set root as root's right child.
                b) Else print root's data and set root as NULL.
            2.3 Repeat steps 2.1 and 2.2 while stack is not empty.
         */
        if (root == null) return;

        Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
        BinaryTreeNode current = root;

        if (current.right != null)
            stack.Push(current.right);
        stack.Push(current);
        current = current.left;

        while (stack.Count > 0)
        {

            while (current != null)
            {
                if (current.right != null)
                    stack.Push(current.right);
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            
            if (current.right != null && stack.Count>0 &&current.right == stack.Peek())
            {
                stack.Pop();
                stack.Push(current);
                current = current.right;
            }
            else
            {
                Console.Write("\t" + current.data+"  ");
                current = null;
            }
        }
    }
}