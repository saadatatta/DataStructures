using System;

class Program
{
    static void Main(string[] args)
    {
        BinaryTreeNode node1 = new BinaryTreeNode(1);
        BinaryTreeNode node2 = new BinaryTreeNode(2);
        BinaryTreeNode node3 = new BinaryTreeNode(3);
        BinaryTreeNode node4 = new BinaryTreeNode(4);
        BinaryTreeNode node5 = new BinaryTreeNode(5);
        BinaryTreeNode node6 = new BinaryTreeNode(6);
        BinaryTreeNode node7 = new BinaryTreeNode(7);

        BinaryTree binaryTree = new BinaryTree(node1);
        node1.left = node2;
        node1.right = node3;
        node2.left = node4;
        node2.right = node5;
        node3.left = node6;
        node3.right = node7;

        //binaryTree.PrintTreeLevelOrder();
        // binaryTree.PrintTreeInOrder();
        //binaryTree.PrintTreeInOrderRecursive(node1);
        //binaryTree.MorrisInOrderTraversal();
        binaryTree.PostOrderTraversalUsingOneStack();
    }
}

