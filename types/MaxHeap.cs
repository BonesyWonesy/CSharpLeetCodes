namespace CSharpLeetCode.types
{
  internal class MaxHeap : IHeap
  {
    private int[] maxHeap;
    private int heapSize;
    private int capacity;

    public MaxHeap(int capacity) {
      this.capacity = capacity;
      heapSize = 0;
      maxHeap = new int[capacity + 1];

      maxHeap[0] = 0; // Unused, to make the index start from 1
    }

    public void Add(int value) {
      if (heapSize == capacity)
      {
        throw new InvalidOperationException("Heap is full");
      }

      heapSize++;
      maxHeap[heapSize] = value;
      int currentIndex = heapSize;

      // Parent node of the newly added element
      // Note if we use an array to represent the complete binary tree
      // and store the root node at index 1
      // index of the parent node of any node is [index of the node / 2]
      // index of the left child node is [index of the node * 2]
      int parent = currentIndex / 2;

      // If the newly added element is larger than its parent node,
      // its value will be exchanged with that of the parent node 
      while (maxHeap[currentIndex] > maxHeap[parent] && currentIndex > 1)
      {
        int temp = maxHeap[currentIndex];
        maxHeap[currentIndex] = maxHeap[parent];
        maxHeap[parent] = temp;
        currentIndex = parent;
        parent = currentIndex / 2;
      }
    }

    public int Peek() {
      if (heapSize == 0)
      {
        throw new InvalidOperationException("Heap is empty");
      }
      return maxHeap[1];
    }

    public int Size() {
      return heapSize;
    }

    public int Pop() {
      // If the number of elements in the current Heap is 0,
      // print "Don't have any elements" and return a default value
      if (heapSize < 1)
      {
        throw new InvalidOperationException("Heap is empty");
      }
      else
      {
        // When there are still elements in the Heap
        // realSize >= 1
        int removeElement = maxHeap[1];
        // Put the last element in the Heap to the top of Heap
        maxHeap[1] = maxHeap[heapSize];
        heapSize--;
        int index = 1;

        // When the deleted element is not a leaf node
        while (index <= heapSize / 2)
        {
          // the left child of the deleted element
          int left = index * 2;
          // the right child of the deleted element
          int right = index * 2 + 1;
          // If the deleted element is smaller than the left or right child
          // its value needs to be exchanged with the larger value
          // of the left and right child
          if (maxHeap[index] < maxHeap[left] || maxHeap[index] < maxHeap[right])
          {
            if (maxHeap[left] > maxHeap[right])
            {
              int temp = maxHeap[left];
              maxHeap[left] = maxHeap[index];
              maxHeap[index] = temp;
              index = left;
            }
            else
            {
              // maxHeap[left] <= maxHeap[right]
              int temp = maxHeap[right];
              maxHeap[right] = maxHeap[index];
              maxHeap[index] = temp;
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
