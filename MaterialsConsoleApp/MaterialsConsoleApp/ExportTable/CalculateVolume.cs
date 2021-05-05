
namespace MaterialsConsoleApp.ExportTable
{

    using System;

    public class CalculateVolume
    {
        public CalculateVolume(string name)
        {
            this.MaterialName = name;
            this.LinkedList = new CustomLinkedList<double>();
        }
        public string MaterialName { get; set; }

        public CustomLinkedList<double> LinkedList { get; set; }
    }
    public class CustomLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; set; }

        public void AddFirst(T node)
        {
            Node<T> newHead = new Node<T>(node);
            if (this.Count == 0)
            {
                this.Head = this.Tail = newHead;
                this.Count++;
                return;
            }
            newHead.Next = Head;
            this.Head.Previous = newHead;
            this.Head = newHead;
            this.Count++;
        }

        public void AddLast(T node)
        {
            Node<T> newTail = new Node<T>(node);
            if (this.Count == 0)
            {
                this.Head = this.Tail = newTail;
                this.Count++;
                return;
            }
            newTail.Previous = this.Tail;
            this.Tail.Next = newTail;
            this.Tail = newTail;
            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new NullReferenceException("The collection is empty!");
            }

            T value = this.Head.Value;
            this.Head = this.Head.Next;
            if (this.Head != null)
            {
                this.Head.Previous = null;
            }
            else
            {
                this.Tail = null;
            }
            this.Count--;
            return value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new NullReferenceException("The collection is empty!");
            }
            T value = this.Tail.Value;

            return value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new NullReferenceException("The collection is empty!");
            }

            T value = this.Tail.Value;
            this.Tail = this.Tail.Previous;
            if (this.Tail != null)
            {
                this.Tail.Next = null;
            }
            else
            {
                this.Head = null;
            }
            this.Count--;
            return value;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            var currentNode = this.Head;
            int count = 0;

            while (currentNode != null)
            {
                array[count] = currentNode.Value;
                currentNode = currentNode.Next;
                count++;
            }
            return array;
        }
    }
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
}
