namespace CSharpLeetCode.types
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

    public MinHeap(int capacity) {
      this.capacity = capacity;
      heapSize = 0;
      minHeap = new int[capacity + 1];

      minHeap[0] = 0; // Unused, to make the index start from 1
    }

    public void Add(int value) {
      if (heapSize == capacity)
      {
        throw new InvalidOperationException("Heap is full");
      }

      heapSize++;

      minHeap[heapSize] = value;
      int currentIndex = heapSize;

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

    public int Peek() {
      if (heapSize == 0)
      {
        throw new InvalidOperationException("Heap is empty");
      }
      return minHeap[1];
    }

    public int Size() {
      return heapSize;
    }

    public int Pop() {
      if (heapSize < 1)
      {
        throw new InvalidOperationException("Heap is empty");
      }

      int removeElement = minHeap[1];
      minHeap[1] = minHeap[heapSize];
      heapSize--;
      int index = 1;

      while (index <= heapSize / 2)
      {
        // the left child of the deleted element
        int left = index * 2;
        // the right child of the deleted element
        int right = index * 2 + 1;
        // If the deleted element is larger than the left or right child
        // its value needs to be exchanged with the smaller value
        // of the left and right child
        if (minHeap[index] > minHeap[left] || minHeap[index] > minHeap[right])
        {
          if (minHeap[left] < minHeap[right])
          {
            int temp = minHeap[left];
            minHeap[left] = minHeap[index];
            minHeap[index] = temp;
            index = left;
          }
          else
          {
            // maxHeap[left] >= maxHeap[right]
            int temp = minHeap[right];
            minHeap[right] = minHeap[index];
            minHeap[index] = temp;
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
