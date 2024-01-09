using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test1
{
    /*
 * 더블 링크드 리스트의 순서를 뒤바꾸기
 *    - Reverse 함수를 구현하시면 됩니다.
 *    - 노드의 prev, next 값이 올바르게 설정되어야 합니다.
 */
    class Node
    {
        public int value;
        public Node prev;
        public Node next;
    }

    class Program
    {
        //static void Main(string[] args)
        //{
        //    Node head = CreateTestNodes(5);

        //    Print(head);

        //    Node reversed = Reverse_2(head);

        //    Print(reversed);
        //}

        #region Stub
        static Node CreateTestNodes(int count)
        {
            var nodes = new Node[count];
            for (int i = 0; i < count; i++)
                nodes[i] = new Node() { value = i + 1 };

            for (int i = 1; i < count; i++)
                nodes[i].prev = nodes[i - 1];

            for (int i = 0; i < count - 1; i++)
                nodes[i].next = nodes[i + 1];

            return nodes[0];
        }

        static void Print(Node head)
        {
            var node = head;
            while (node != null)
            {
                Console.Write(node.value + " ");
                node = node.next;
            }

            Console.WriteLine();
        }
        #endregion

        static Node Reverse(Node head)
        {
            // 링크드 리스트의 순서를 뒤바꾸도록 구현해 주세요.
            Node curNode = new Node();
            Node swapNode = new Node();

            while (head != null)
            {
                curNode = head;

                swapNode = head.next;
                head.next = head.prev;
                head.prev = swapNode;

                head = swapNode;
            }

            return curNode;
        }

        static Node Reverse_2(Node head)
        {
            // 링크드 리스트의 순서를 뒤바꾸도록 구현해 주세요.
            Node swapNode = head.next;
            head.next = head.prev;
            head.prev = swapNode;

            if (swapNode == null)
                return head;
            else
                return Reverse_2(swapNode);
        }
    }
}

