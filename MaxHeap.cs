using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    internal class MaxHeap : IHeap
    {
        private int[] maxHeap;
        private int heapSize;
        private int capacity;

        public MaxHeap(int capacity)
        {
            this.capacity = capacity;
            this.heapSize = 0;
            this.maxHeap = new int[capacity + 1];

            this.maxHeap[0] = 0; // Unused, to make the index start from 1
        }

        public void Add(int value)
        {
            if (this.heapSize == this.capacity)
            {
                throw new InvalidOperationException("Heap is full");
            }

            this.heapSize++;
            this.maxHeap[this.heapSize] = value;
            int currentIndex = this.heapSize;

            // Parent node of the newly added element
            // Note if we use an array to represent the complete binary tree
            // and store the root node at index 1
            // index of the parent node of any node is [index of the node / 2]
            // index of the left child node is [index of the node * 2]
            int parent = currentIndex / 2;

            // If the newly added element is larger than its parent node,
            // its value will be exchanged with that of the parent node 
            while (this.maxHeap[currentIndex] > this.maxHeap[parent] && currentIndex > 1)
            {
                int temp = this.maxHeap[currentIndex];
                this.maxHeap[currentIndex] = this.maxHeap[parent];
                this.maxHeap[parent] = temp;
                currentIndex = parent;
                parent = currentIndex / 2;
            }
        }

        public int Peek()
        {
            if (this.heapSize == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }
            return this.maxHeap[1];
        }

        public int Size()
        {
            return this.heapSize;
        }

        public int Pop()
        {
            // If the number of elements in the current Heap is 0,
            // print "Don't have any elements" and return a default value
            if (this.heapSize < 1)
            {
                throw new InvalidOperationException("Heap is empty");
            }
            else
            {
                // When there are still elements in the Heap
                // realSize >= 1
                int removeElement = this.maxHeap[1];
                // Put the last element in the Heap to the top of Heap
                this.maxHeap[1] = this.maxHeap[this.heapSize];
                this.heapSize--;
                int index = 1;

                // When the deleted element is not a leaf node
                while (index <= this.heapSize / 2)
                {
                    // the left child of the deleted element
                    int left = index * 2;
                    // the right child of the deleted element
                    int right = (index * 2) + 1;
                    // If the deleted element is smaller than the left or right child
                    // its value needs to be exchanged with the larger value
                    // of the left and right child
                    if (this.maxHeap[index] < this.maxHeap[left] || this.maxHeap[index] < this.maxHeap[right])
                    {
                        if (this.maxHeap[left] > this.maxHeap[right])
                        {
                            int temp = this.maxHeap[left];
                            this.maxHeap[left] = this.maxHeap[index];
                            this.maxHeap[index] = temp;
                            index = left;
                        }
                        else
                        {
                            // maxHeap[left] <= maxHeap[right]
                            int temp = this.maxHeap[right];
                            this.maxHeap[right] = this.maxHeap[index];
                            this.maxHeap[index] = temp;
                            index = right;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return removeElement;
            }
        }
    }
}
