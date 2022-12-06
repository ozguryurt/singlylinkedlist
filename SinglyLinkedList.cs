using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add, Insert, RemoveData, RemoveIndex, GetList
            SinglyLinkedList a = new SinglyLinkedList();

            a.Add(0); // 0
            a.Add(1); // 0 1
            a.Add(2); // 0 1 2
            a.RemoveData(0); // 1 2
            a.Insert(0, 13); // 13 1 2
            a.RemoveIndex(1); // 13 2
            a.RemoveIndex(0); // 2
            a.Insert(0, 9); // 9 2
            a.RemoveIndex(1); // 9
            a.Insert(1, 6); // 9 6
            a.RemoveData(9); // 6
            a.RemoveData(6); //

            int[] arr = a.GetList();
            for(int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
        }
    }

    class SinglyLinkedList
    {
        private int count;
        Node firstNode;
        Node lastNode;

        public SinglyLinkedList()
        {
            count = 0;
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if(count == 0)
            {
                firstNode = newNode;
                lastNode = newNode;
                count++;
            }
            else if (count > 0)
            {
                lastNode.next = newNode;
                lastNode = newNode;
                count++;
            }
        }

        public void Insert(int index, int data)
        {
            if (count != 0)
            {
                if (count == 1)
                {
                    if(index == 0)
                    {
                        Node newNode = new Node(data);
                        newNode.next = firstNode;
                        lastNode = firstNode; // !
                        firstNode = newNode;
                        count++;
                    }
                    else if (index == 1)
                    {
                        Node newNode = new Node(data);
                        firstNode.next = newNode;
                        lastNode = newNode;
                        count++;
                    }
                }
                else if (count != 1)
                {
                    if (index > 0 && index < count - 1)
                    {
                        Node newNode = new Node(data);
                        Node prev = null;
                        Node curr = firstNode;
                        for (int i = 0; i < index; i++)
                        {
                            prev = curr;
                            curr = curr.next;
                        }
                        prev.next = newNode;
                        newNode.next = curr;
                        count++;
                    }
                    else if (index == 0)
                    {
                        Node newNode = new Node(data);
                        newNode.next = firstNode;
                        firstNode = newNode;
                        count++;
                    }
                    else if (index == count - 1)
                    {
                        Node newNode = new Node(data);
                        Node prev = null;
                        Node curr = firstNode;
                        for (int i = 0; i < index; i++)
                        {
                            prev = curr;
                            curr = curr.next;
                        }
                        prev.next = newNode;
                        newNode.next = curr;
                        lastNode = curr;
                        count++;
                    }
                }
            }
            else
            {
                throw new Exception("liste boş");
            }
        }

        public void RemoveData(int data)
        {
            if(count != 0)
            {
                Node prev = null;
                Node curr = firstNode;

                while (curr != null)
                {
                    if (curr.data == data)
                    {
                        if (curr.next == null)
                            lastNode = prev;

                        if (prev == null)
                            firstNode = curr.next;

                        if(prev != null)
                            prev.next = curr.next;

                        count--;
                        break;
                    }
                    prev = curr;
                    curr = curr.next;
                }
            }
            else
            {
                throw new Exception("liste boş");
            }
        }

        public void RemoveIndex(int index)
        {
            if(count != 0)
            {
                if(index < count)
                {
                    if (count == 1)
                    {
                        firstNode = null;
                        lastNode = null;
                        count--;
                    }
                    else if (count != 1)
                    {
                        if (index > 0 && index < count - 1)
                        {
                            Node prev = null;
                            Node curr = firstNode;
                            for (int i = 0; i < index; i++)
                            {
                                prev = curr;
                                curr = curr.next;
                            }
                            prev.next = curr.next;
                            count--;
                        }
                        else if (index == 0)
                        {
                            firstNode = firstNode.next;
                            count--;
                        }
                        else if (index == count - 1)
                        {
                            Node prev = null;
                            Node curr = firstNode;
                            for (int i = 0; i < index; i++)
                            {
                                prev = curr;
                                curr = curr.next;
                            }
                            prev.next = curr.next;
                            if (curr.next == null)
                                lastNode = prev;
                            count--;
                        }
                    }
                }
                else
                {
                    throw new Exception("hatalı index");
                }
            }
            else
            {
                throw new Exception("liste boş");
            }
        }

        public int[] GetList()
        {
            int[] arr = new int[count];
            int i = 0;
            if (count != 0)
            {
                Node curr = firstNode;
                while (curr != null)
                {
                    arr[i] = curr.data;
                    i++;
                    curr = curr.next;
                }
            }
            return arr;
        }
    }

    class Node
    {
        public int data;
        public Node next;

        public Node()
        {

        }

        public Node(int data)
        {
            this.data = data;
        }
    }
}
