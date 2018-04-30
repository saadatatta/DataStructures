using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Node
{
    public int data { get; private set; }
    public Node next;

    public Node(int data)
    {
        this.data = data;
        next = null;
    }
}

    
