using System;

namespace ADTDriverConsoleApp
{
    public class Heap
    {
        private int _size;
        private int[] _heap;

        public Heap(int size)
        {
            _size = 0;
            _heap = new int[size];
        }

        public void Print()
        {
            Console.WriteLine($"{String.Join(",", _heap)}");
        }

        public int Size()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return _size == _heap.Length;
        }

        public void Insert(int item)
        {
            if(!IsEmpty())
            {
                _heap[_size] = item;
                BubbleUp();
                _size++;
            }
        }

        public void Remove()
        {
            if(!IsEmpty())
            {
                _heap[0] = _heap[_size--];
                BubbleDown();
            }
        }

        private void BubbleUp()
        {
            int index = _size - 1;
            while(index > 0 && _heap[index] > _heap[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void BubbleDown()
        {
            int index = 0;

            while(index <= _size && !IsValidParent(index))
            {
                int largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private void Swap(int index, int parent)
        {
            int temp = _heap[index];
            _heap[index] = _heap[parent];
            _heap[parent] = temp;
        }

        private int Parent(int index)
        {
            return (index + 1) / 2;
        }
        
        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index)) return index;
            if (!HasRightChild(index)) return LeftChildIndex(index);
            return (LeftChild(index) > RightChild(index)) ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index)) return true;

            bool isValid = _heap[index] >= LeftChild(index);
            if(HasRightChild(index))
            {
                isValid &= _heap[index] >= RightChild(index);
            }

            return isValid;
        }

        private int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private int LeftChild(int index)
        {
            return _heap[LeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return _heap[RightChildIndex(index)];
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= _size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= _size;
        }
    }

    public static class Program
    {
        static int[] testArray = { 300, 12, 199, 45, 14, 1, 60, 0, 33, 12 };

        public static void Main(string[] args)
        {
            int length = testArray.Length;
            Heap h = new Heap(length);

            //Console.WriteLine($"Array\n\t{String.Join(",", testArray)}\n({length} elements)");
            //for(int i = 0; i < length; i++)
            //    h.Insert(testArray[i]);

            h.Insert(1);
            h.Insert(10);
            h.Insert(59);
            h.Insert(33);
            h.Insert(15);
            h.Insert(4);
            h.Insert(20);
            h.Insert(12);
            h.Insert(270);
            h.Insert(99);
            h.Print();
            h.Remove();
            h.Print();
        }
    }
}
