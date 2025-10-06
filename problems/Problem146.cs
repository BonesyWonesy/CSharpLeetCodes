using CSharpLeetCode.types;

namespace CSharpLeetCode.problems
{

  internal class CacheItem
  {
    public readonly int Key;
    public int Value;

    public CacheItem(int key, int value) {
      Key = key;
      Value = value;
    }
  }

  internal class LRUCache
  {
    private int capacity;
    private Dictionary<int, LinkedListNode<CacheItem>> cache;
    private LinkedList<CacheItem> lruList;
    public LRUCache(int capacity) {
      this.capacity = capacity;
      cache = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
      lruList = new LinkedList<CacheItem>();
    }
    public int Get(int key) {
      if (!cache.ContainsKey(key))
      {
        return -1;
      }

      LinkedListNode<CacheItem> node = cache[key];
      lruList.Remove(node);
      lruList.AddFirst(node);
      return node.Value.Value;
    }
    public void Put(int key, int value) {
      if (cache.TryGetValue(key, out LinkedListNode<CacheItem>? existingNode))
      {
        existingNode.Value.Value = value;
        lruList.Remove(existingNode);
        lruList.AddFirst(existingNode);
      }
      else
      {
        if (cache.Count == capacity)
        {
          LinkedListNode<CacheItem> lruNode = lruList.Last;
          lruList.RemoveLast();
          cache.Remove(lruNode.Value.Key);
        }

        LinkedListNode<CacheItem> addedNode = lruList.AddFirst(new CacheItem(key, value));
        cache.Add(key, addedNode);
      }
    }
  }

  /*
   * Implement the LRUCache class:
   * 
   * LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
   * 
   * int get(int key) Return the value of the key if the key exists, otherwise return -1.
   * 
   * void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
   * 
   * The functions get and put must each run in O(1) average time complexity.
  */
  internal class Problem146 : LeetCodeProblem, ILeetCodeProblem<(string command, int[] args), int?>
  {
    private LRUCache? lruCache = null;
    public Problem146() : base(Difficulty.Medium) { }

    public string FormatOutput(int? result) => result?.ToString() ?? "null";
    public bool IsEqual(int? result, int? expected) => result == expected;

    public IEnumerable<((string command, int[] args), int?)> GetTests() {
      return new ((string command, int[] args), int?)[]
      {
                (("LRUCache", new int[]{2}), null),
                (("put", new int[]{2,1}), null),
                (("put", new int[]{2,2}), null),
                (("get", new int[]{2}), 2),
                (("put", new int[]{1,1}), null),
                (("put", new int[]{4,1}), null),
                (("get", new int[]{2}), 2)
      };
      /*{
          (("LRUCache", new int[]{2}), null),
          (("put", new int[]{1,1}), null),
          (("put", new int[]{2,2}), null),
          (("get", new int[]{1}), 1),
          (("put", new int[]{3,3}), null),
          (("get", new int[]{2}), -1),
          (("put", new int[]{4,4}), null),
          (("get", new int[]{1}), -1),
          (("get", new int[]{3}), 3),
          (("get", new int[]{4}), 4)
      };*/
    }

    public int? Test((string command, int[] args) testCase) {
      var (command, args) = testCase;

      switch (command)
      {
        case "LRUCache":
          lruCache = new LRUCache(args[0]);
          return null;
        case "put":
          lruCache?.Put(args[0], args[1]);
          return null;
        case "get":
          return lruCache?.Get(args[0]);
        default:
          return null;
      }
    }
  }
}
