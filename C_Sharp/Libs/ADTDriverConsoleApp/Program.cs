using System;
using System.Collections.Generic;
using System.Linq;

namespace ADTDriverConsoleApp
{
    public class Heap
    {
        private int size;
        private int[] heap;

        public Heap(int size)
        {
            size = 0;
            heap = new int[size];
        }

        public void Print()
        {
            Console.WriteLine($"{String.Join(",", heap)}");
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == heap.Length;
        }

        public void Insert(int item)
        {
            if(!IsEmpty())
            {
                heap[size] = item;
                BubbleUp();
                size++;
            }
        }

        public void Remove()
        {
            if(!IsEmpty())
            {
                heap[0] = heap[size--];
                BubbleDown();
            }
        }

        private void BubbleUp()
        {
            int index = size - 1;
            while(index > 0 && heap[index] > heap[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void BubbleDown()
        {
            int index = 0;

            while(index <= size && !IsValidParent(index))
            {
                int largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private void Swap(int index, int parent)
        {
            int temp = heap[index];
            heap[index] = heap[parent];
            heap[parent] = temp;
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

            bool isValid = heap[index] >= LeftChild(index);
            if(HasRightChild(index))
            {
                isValid &= heap[index] >= RightChild(index);
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
            return heap[LeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return heap[RightChildIndex(index)];
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }
    }


    public class MapPoint
    {
        public string name;
        public int id;
        public List<int> connections;

        public MapPoint(int mId, string mName)
        {
            connections = new List<int>();
            id = mId;
            name = mName;
        }

        public void AddConnection(int id)
        {
            if (!connections.Contains(id))
                connections.Add(id);
        }

        public void RemoveConnection(int id)
        {
            if(connections.Contains(id))
                connections.Remove(id);
        }

        public List<int> Connections()
        {
            return connections;
        }

        public void Describe()
        {
            Console.WriteLine($"Map Point: [{id}] {name} - ({connections.Count} connections)");
        }
    }

    public class Map
    {
        public string name;
        public int currentId;
        public List<MapPoint> points;

        public Map(string mName)
        {
            name = mName;
            currentId = 0;
            points = new List<MapPoint>();
        }

        public void AddPoint(string name)
        {
            points.Add(new MapPoint(currentId, name));
            currentId++;
        }

        public void RemovePoint(int id)
        {
            MapPoint delPoint = points.FirstOrDefault(x => x.id == id);

            if (delPoint != null)
            {
                points.Remove(delPoint);

                foreach (MapPoint point in points)
                {
                    int? delId = point.connections.FirstOrDefault(x => x == id);
                    if (delId != null)
                    {
                        point.RemoveConnection(id);
                    }
                }
            }
        }

        public void ConnectPoints(int id1, int id2)
        {
            MapPoint p1 = points.FirstOrDefault(x => x.id == id1);
            MapPoint p2 = points.FirstOrDefault(x => x.id == id2);

            if(p1 != null && p2 != null)
            {
                p1.AddConnection(p2.id);
                p2.AddConnection(p1.id);
            }
        }

        public void Describe()
        {
            Console.WriteLine($"Map: {name}, ({points.Count} map points)");
            foreach(MapPoint p in points)
            {
                p.Describe();

                foreach(int id in p.connections)
                {
                    MapPoint mp = points.FirstOrDefault(x => x.id == id);
                    Console.WriteLine($"{mp.name} is connected to {p.name}");
                }
            }
        }
    }

    public static class Program
    {
        static int[] testArray = { 300, 12, 199, 45, 14, 1, 60, 0, 33, 12 };

        public static void Main(string[] args)
        {
            int length = testArray.Length;
            //Heap h = new Heap(length);

            //Console.WriteLine($"Array\n\t{String.Join(",", testArray)}\n({length} elements)");
            //for(int i = 0; i < length; i++)
            //    h.Insert(testArray[i]);

            //h.Insert(1);
            //h.Insert(10);
            //h.Insert(59);
            //h.Insert(33);
            //h.Insert(15);
            //h.Insert(4);
            //h.Insert(20);
            //h.Insert(12);
            //h.Insert(270);
            //h.Insert(99);
            //h.Print();
            //h.Remove();
            //h.Print();

            Map map = new Map("Test Map");
            map.AddPoint("test point 1");
            map.AddPoint("test point 2");
            map.AddPoint("test point 3");
            map.AddPoint("test point 4");
            map.AddPoint("test point 5");

            map.Describe();
            
            map.ConnectPoints(4, 3);
            map.ConnectPoints(4, 2);
            map.ConnectPoints(0, 1);
            map.ConnectPoints(0, 1);
            map.ConnectPoints(0, 2);
            map.ConnectPoints(0, 3);
            map.ConnectPoints(6, 9);

            map.Describe();
        }
    }
}
