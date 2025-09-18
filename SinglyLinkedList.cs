using System.Text;

namespace Assignment_11._2._2
{
    // ListNode class is pulled from LeetCode problem
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.next = next;
            this.val = val;
        }
    }

    // Self-made Singly Linked List to hold ListNodes
    public class SinglyLinkedList
    {
        public ListNode Head { get; set; }
        public ListNode Tail { get; set; }

        public SinglyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public void Add(int data)
        {
            ListNode newNode = new ListNode(data);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.next = newNode;
                Tail = newNode;
            }
        }

        public string PrintList()
        {
            if (Head == null) return null;
            else
            {
                StringBuilder sb = new();
                ListNode currentNode = Head;

                while (currentNode != null)
                {
                    sb.Append(currentNode.val);
                    
                    if (currentNode.next != null) 
                        sb.Append(",");

                    currentNode = currentNode.next;
                }

                return sb.ToString();
            }
        }

        public static SinglyLinkedList GenerateList(int[] input)
        {
            SinglyLinkedList list = new();

            foreach (int i in input)
            {
                list.Add(i);
            }

            return list;
        }

        public static SinglyLinkedList GenerateList(Stack<int> input)
        {
            SinglyLinkedList list = new();

            while(input.Count>0)
            {
                list.Add(input.Pop());
            }

            return list;
        }
    }
}
