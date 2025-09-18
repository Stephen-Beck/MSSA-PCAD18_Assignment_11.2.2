/*
LeetCode #206: Reverse Linked List

     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
 
    public class Solution
    {
        public ListNode ReverseList(ListNode head)
        {

        }
    }

Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
*/

/*
Given the head of a singly linked list, reverse the list, and return the reversed list.

Example 1:
    (1)->(2)->(3)->(4)->(5)
               |
               v
    (5)->(4)->(3)->(2)->(1)

        Input: head = [1,2,3,4,5]
        Output: [5,4,3,2,1]

Example 2:
    (1)->(2)
        |
        v
    (2)->(1)
    
        Input: head = [1,2]
        Output: [2,1]

Example 3:
        Input: head = []
        Output: []
*/

namespace Assignment_11._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = [1, 2, 3, 4, 5];
            TestIterative(input);

            input = [1, 2];
            TestIterative(input);

            input = [];
            TestIterative(input);
        }

        static ListNode ReverseListIterative(ListNode currentNode)
        {
            /*
             ## Iterative Walkthrough ##

             Input: 1 -> 2 -> 3 -> 4 -> 5 -> null (starting from head)

                                                              [next] <-- temp variable
            iteration    head(start)    head.next    prev    head(end)
                0             1             2        null       N/A     [starting values; not in while loop yet]
                1             1            null        1         2
                2             2             1          2         3
                3             3             2          3         4
                4             4             3          4         5
                5             5             4          5        null
                6            null (break loop)

            Output: 5 -> 4 -> 3 -> 2 -> 1 -> null (starting from prev)
            */

            ListNode prevNode = null;

            // Adjust values so .next is reversed, thus reversing the list
            while (currentNode != null)
            {
                ListNode nextNode = currentNode.next; // Hold value of next Node so we don't lose it when changing .next value
                currentNode.next = prevNode;          // Set .next to previous Node
                prevNode = currentNode;               // Set prevNode to current Node
                currentNode = nextNode;               // Set currentNode to next Node to continue the loop
            }
            return prevNode; // Return prev so you start from the last element in the list, which now points backwards
        }

        static void TestIterative(int[] input)
        {
            // Helper function to clean up Main method

            var list = SinglyLinkedList.GenerateList(input);    // Generate singly linked list from int[]
            Console.WriteLine($" Input: [{list.PrintList()}]");         // Print list
            list.Head = ReverseListIterative(list.Head);                      // Reverse list iteratively, assign to list.Head as list is now reversed
            Console.WriteLine($"Output: [{list.PrintList()}]\n");       // Print reversed list
        }

        #region Recursion method; had to look it up
        public ListNode ReverseListRecursive(ListNode head)
        {
            // I had to look this up. I think I understand it properly,
            // but recursion is hard to follow in my head and I was not able to come up with a working solution!

            if (head == null || head.next == null)
                return head;

            ListNode newHead = ReverseListRecursive(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        } 
        #endregion

        #region Original; refactored to match LeetCode problem above
        //Didn't realize LeetCode returns a node, not the full list
        static void TestOriginal(int[] input)
        {
            SinglyLinkedList head = SinglyLinkedList.GenerateList(input);
            var reversed = ReverseList(head.Head);
            Console.WriteLine($"Input: head = [{head.PrintList()}]");
            Console.WriteLine($"Output: [{reversed.PrintList()}]\n");
        }

        static SinglyLinkedList ReverseList(ListNode head)
        {
            Stack<int> intStack = new();

            while (head != null)
            {
                intStack.Push(head.val);
                head = head.next;
            }

            return SinglyLinkedList.GenerateList(intStack);
        }
        #endregion
    }
}
