using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode
{
    /**
     * Implementing a MinHeap from scratch:
     * A Min Heap:
     * - Is a complete binary tree (all levels are fully filled except possibly the last level, which is filled from left to right).
     * - The value of each node is less than or equal to the values of its children.
     * 
     */
    internal class MinHeap : IHeap
    {
        private int[] minHeap;
        private int heapSize;
        private int capacity;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            this.heapSize = 0;
            this.minHeap = new int[capacity + 1];

            this.minHeap[0] = 0; // Unused, to make the index start from 1
        }

        public void Add(int value)
        {            
            if (this.heapSize == this.capacity)
            {
                throw new InvalidOperationException("Heap is full");
            }

            this.heapSize++;

            this.minHeap[this.heapSize] = value;
            int currentIndex = this.heapSize;

            // Parent node of the newly added element
            // Note if we use an array to represent the complete binary tree
            // and store the root node at index 1
            // index of the parent node of any node is [index of the node / 2]
            // index of the left child node is [index of the node * 2]
            // index of the right child node is [index of the node * 2 + 1]
            int parent = currentIndex / 2;
            // If the newly added element is smaller than its parent node,
            // its value will be exchanged with that of the parent node 
            while (minHeap[currentIndex] < minHeap[parent] && currentIndex > 1)
            {
                int temp = minHeap[currentIndex];
                minHeap[currentIndex] = minHeap[parent];
                minHeap[parent] = temp;
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
            return this.minHeap[1];
        }

        public int Size() 
        { 
            return this.heapSize; 
        }

        public int Pop()
        {
            if(this.heapSize < 1) {                 
                throw new InvalidOperationException("Heap is empty");
            }

            int removeElement = this.minHeap[1];
            this.minHeap[1] = minHeap[this.heapSize];
            this.heapSize--;
            int index = 1;

            while (index <= this.heapSize / 2)
            {
                // the left child of the deleted element
                int left = index * 2;
                // the right child of the deleted element
                int right = (index * 2) + 1;
                // If the deleted element is larger than the left or right child
                // its value needs to be exchanged with the smaller value
                // of the left and right child
                if (this.minHeap[index] > this.minHeap[left] || this.minHeap[index] > this.minHeap[right])
                {
                    if (this.minHeap[left] < this.minHeap[right])
                    {
                        int temp = this.minHeap[left];
                        this.minHeap[left] = this.minHeap[index];
                        this.minHeap[index] = temp;
                        index = left;
                    }
                    else
                    {
                        // maxHeap[left] >= maxHeap[right]
                        int temp = this.minHeap[right];
                        this.minHeap[right] = this.minHeap[index];
                        this.minHeap[index] = temp;
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
