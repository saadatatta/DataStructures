using System;
using System.Collections;

public class LinkedList
{
    public Node head {  get; private set; }

    public LinkedList(Node head)
    {
        this.head = head;
    }

    //Push a node to front of linked list.
    public void Push(int data)
    {
        Node newNode = new Node(data);
        newNode.next = head;
        head = newNode;
    }

    public void InsertAfter(Node previousNode,int data)
    {
        if (previousNode == null)
        {
            Console.WriteLine("Previous node is null.");
            return;
        }

        Node newNode = new Node(data);

        newNode.next = previousNode.next;

        previousNode.next = newNode;
    }

    //Add a new node at the end of linked list.
    public void Append(int data)
    {
        Node newNode = new Node(data);

        if(head == null)//If linked list is empty.
        {
            head = newNode;
            return;
        }

        Node temp = head;

        while(temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    public void Delete(int data)
    {
        if (head == null)
            return;

        if(head.data == data)
        {
            head = head.next;
            return;
        }

        Node previous = null;
        Node current = head;

        while(current != null &&  current.data != data)
        {
            previous = current;
            current = current.next;
        }

        if (current== null)
        {
            Console.WriteLine("Value not found");
            return;
        }

        previous.next = current.next;
        current.next = null;
    }

    public void DeleteAtPosition(int pos)
    {
        if (head == null)
            return;

        if (pos == 0)
        {
            head = head.next;
            return;
        }

        Node previous = null;
        Node current = head;
        int count = 0;

        while (current != null && count < pos)
        {
            previous = current;
            current = current.next;
            count++;
        }

        if (current == null)
        {
            Console.WriteLine("Position is greater than linked list length.");
            return;
        }

        previous.next = current.next;
        current.next = null;
        //Position is zero based
        //Position is zero based
    }//Position is zero based.

    //Length of linked list.
    public void Length()
    {
        Node current = head;
        int count = 0;

        while(current != null)
        {
            count++;
            current = current.next;
        }

        Console.WriteLine("Length of linked list is "+ count);
    }

    //Recursive way to find length of list.
    public int Length(Node node)
    {
        if (node == null) return 0;

        return 1 + Length(node.next);
    }

    //Search a value in a linked list.
    public bool Search(int data)
    {
        Node current = head;

        while(current != null && current.data != data)
        {
            current = current.next;
        }

        if (current == null) return false;

        return true;
    }

    //Recursive way to search for an element.
    public bool Search(Node head,int data)
    {
        if (head == null) return false;

        if (head.data == data) return true;

        return Search(head.next, data);

    }

    public Node FindNode(int data)
    {
        Node current = head;

        while (current != null && current.data != data)
        {
            current = current.next;
        }

        if (current == null) return null;

        return current;
    }

    //Find previous node of given node.
    public Node FindPreviousNode(int data)
    {
        Node current = head;

        while (current.next != null && current.next.data != data)
        {
            current = current.next;
        }

        if (current.next == null) return null;

        return current;
    }

    public void SwapNodes(int x,int y)
    {
        Node firstNode, secondNode;
        Node firstNodePrevious;
        Node secondNodePrevious;

        if (x == y)
            return;

        firstNode = FindNode(x);
        secondNode = FindNode(y);

        if (firstNode == null || secondNode == null)
            return;

        
        firstNodePrevious = FindPreviousNode(x);
        secondNodePrevious = FindPreviousNode(y);

        if(firstNodePrevious == null && secondNodePrevious.data == firstNode.data)
        {
            firstNode.next = secondNode.next;
            secondNode.next = firstNode;
            head = secondNode;
            return;
        }

        if (firstNodePrevious == null)
        {
            Node temp = firstNode.next;

            firstNode.next = secondNode.next;

            secondNodePrevious.next = firstNode;
            secondNode.next = temp;

            head = secondNode;

            return;
        }

        Node temp1 = firstNode.next;
        firstNode.next = secondNode.next;
        firstNodePrevious.next = secondNode;
        secondNode.next = temp1;
        secondNodePrevious.next = firstNode;
    }

    public Node FindMiddleNode()
    {
        int count = 0;
        Node temp = head;

        while(temp != null)
        {
            count++;
            temp = temp.next;
        }

        int mid = (count / 2) + 1;

        temp = head;
        count = 1;

        while(count != mid)
        {
            count++;
            temp = temp.next;
        }

        return temp;
    }

    //Recursive way to find the nth node.
    //Index is zero based.
    public Node GetNthNode(Node head,int index)
    {
        int count = 0;

        if (count == index)
            return head;

        return GetNthNode(head.next, index - 1);
    }

    public Node GetNthNodeFromLast(int n)
    {
        Node sp = head, fp = head;

        int count = 0;

        while(count < n) // Give a head start to fast pointer by n.
        {
            fp = fp.next;
            count++;

            if (fp == null)
            {
                Console.WriteLine("Value passed is greater than list length");
                return null;
            }
        }

        while (fp != null)
        {
            fp = fp.next;
            sp = sp.next;
        }

        return sp;

    }

    //Same as above method with different implementation.
    public void PrintNthNodeFromLast(int n)
    {
        int len = 0;
        Node temp = head;

        // 1) count the number of nodes in Linked List
        while (temp != null)
        {
            temp = temp.next;
            len++;
        }

        // check if value of n is not more than length of
        // the linked list
        if (len < n)
            return;

        temp = head;

        // 2) get the (n-len+1)th node from the begining
        for (int i = 1; i < len - n + 1; i++)
            temp = temp.next;

        Console.WriteLine("Nth Node from Last is " + temp.data);
    }

    public void DeleteList()
    {
        head = null;
    }

    public void ReverseList()
    {
        Node prev = null;
        Node current = head;
        Node next;

        if (head == null)
            return;

        if (current.next == null) // Only one node.
            return;

        next = current.next;

        while(next != null)
        {
            
            current.next = prev;
            prev = current;
            current = next;
            next = current.next;
            
        }
        current.next = prev;
        head = current;
    }

    public bool LoopDetect()
    {
        if (head == null) return false;

        if (head.next == null) return false;

        Node sp = head, fp;

        fp = sp.next.next;

        while(fp != sp && fp != null && fp.next !=null)
        {
            fp = fp.next.next;
            sp = sp.next;
        }

        if (sp == fp)
            return true;

        return false;
    }

    public Node MergeTwoSortedLists(Node list1,Node list2)
    {
        Node head = null;

        if (list1 == null)
        {
            return list2;
        }
        if (list2 == null)
        {
            return list1;
        }

        if (list1.data <= list2.data)
        {
            Node temp = new Node(list1.data);
            head = temp;
            list1 = list1.next;
        }
        else
        {
            Node temp = new Node(list2.data);
            head = temp;
            list2 = list2.next;
        }

        Node temp1 = head;

        while (list1 != null && list2 != null)
        {
            if(list1.data <= list2.data)
            {
                Node n = new Node(list1.data);
                temp1.next = n;
                temp1 = n;
                list1 = list1.next;
            }
            else
            {
                Node n = new Node(list2.data);
                temp1.next = n;
                temp1 = n;
                list2 = list2.next;
            }
        }

        while(list1 != null)
        {
            Node n = new Node(list1.data);
            temp1.next = n;
            temp1 = n;
            list1 = list1.next;
        }

        while(list2 != null)
        {
            Node n = new Node(list2.data);
            temp1.next = n;
            temp1 = n;
            list2 = list2.next;
        }

        return head;
    }

    public Node MergeTwoSortedlistsRecursive(Node h1, Node h2)
    {
        Node result = null;

        if (h1 == null)
            return h2;
        if (h2 == null)
            return h1;

        if (h1.data <= h2.data)
        {
            result = h1;
            result.next = MergeTwoSortedlistsRecursive(h1.next, h2);
        }
        else
        {
            result = h2;
            result.next = MergeTwoSortedlistsRecursive(h1, h2.next);
        }

        return result;
    }

    public bool IsPalindrome()
    {
        if (head == null)
            return false;

        Node current = head;
        Stack stack = new Stack();

        while(current != null)
        {
            stack.Push(current.data);
            current = current.next;
        }

        current = head;

        while(current != null)
        {
            if (current.data == (int)stack.Pop())
            {
                current = current.next;
            }
            else
            {
                return false;
            }  
        }

        return true;
    }

    public int FindIntersectingNode(Node head1,Node head2)
    {
        Node temp1 = head1;
        Node temp2 = head2;

        int c1 = Length(temp1);
        int c2 = Length(temp2);
        int diff = 0;

        temp1 = head1;
        temp2 = head2;

        if(c1> c2)
        {
            diff = c1 - c2;
            return GetIntersectionNode(diff, temp1, temp2);
        }
        else
        {
            diff = c2 - c1;
            return GetIntersectionNode(diff, temp2, temp1);
        }
    }

    //utility function for FindIntersectingNode
    private int GetIntersectionNode(int diff,Node head1,Node head2)
    {
        Node temp1 = head1, temp2 = head2;
        
        for(int i = 0; i < diff; i++) // Forward the pointer of temp1 so it aligns with temp2.
        {
            temp1 = temp1.next;
        }

        while(temp1 != null && temp2 != null)
        {
            if(temp1.data == temp2.data)
            {
                return temp1.data;
            }
            temp1 = temp1.next;
            temp2 = temp2.next;
        }
        return -1;
    }

    public void PrintList()
    {
        Node current = head;
        Console.WriteLine("\nPrinting Linked List........ \n");

        while (current != null)
        {
            Console.Write(current.data + "  " + "---->" + "  ");
            current = current.next;
        }
        Console.Write("null");
        Console.WriteLine("\n\nFinsihed Printing Linked List........ \n");

    }
}