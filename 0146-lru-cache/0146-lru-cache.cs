public class LRUCache 
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache;
    private readonly LinkedList<KeyValuePair<int, int>> _lru;

    public LRUCache(int capacity) 
    {
        _capacity = capacity;        
        _cache = new();
        _lru = new();
    }
    
    public int Get(int key) 
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }
        
        _lru.Remove(node);
        _cache[key] = _lru.AddFirst(node.Value);//This AddFirst accepts "Value"
        
        return node.Value.Value;        
    }
    
    public void Put(int key, int value) 
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _lru.Remove(node);
            _cache.Remove(key);
        }
        
        node = _lru.AddFirst(new KeyValuePair<int, int>(key, value));
        _cache[key] = node;
        
        if (_lru.Count > _capacity)
        {
            node = _lru.Last;            
            _lru.RemoveLast();
            _cache.Remove(node.Value.Key);            
        }
    }
}


// public class LRUCache {
   
//     private int _capacity = 0;
    
//     /* dic: maintain the key-value mapping for 2 purposes:
//        1. Get cache value by cache key in O(1)
//        2. Use LinkedListNode as the dictionry value, so that later we can use LinkedList.Remove(dic[key]) to remove an element in O(1).
//     */
//     private Dictionary<int, LinkedListNode<Cache>> dic = new Dictionary<int, LinkedListNode<Cache>>();
    
//     /*
//         lruList: 
//         1. Most recently used cache will be added to the head of the LinkedList.
//         2. Use LinkedListNode to add/remove element to achieve O(1) time complexity.
//         3. LinkedList<T>.Last returns the last LinkedListNode<T>.
// 			- LinkedList<T>.Last is a property which is an O(1) operation.
// 			- LinkedList<T>.Last() uses LINQ to get the last element which is an O(n) operation.
//     */
//     private LinkedList<Cache> lruList = new LinkedList<Cache>();
        
//     public LRUCache(int capacity) {
//         _capacity = capacity;
//     }
    
//     public int Get(int key) {
//         if(!dic.ContainsKey(key))
//             return -1;
        
//         var cache = dic[key];
        
//         // move the cache to the head of lruList, indicating it is the most recent used cache.
//         lruList.Remove(cache);
//         lruList.AddFirst(cache);
        
//         return cache.Value.CacheVal;
//     }
    
//     public void Put(int key, int value) {
//         if(dic.ContainsKey(key))
//         {
//             // update the cache value
//             dic[key].Value.CacheVal = value;
            
//             // move the updated cache to the head of the lruList
//             var cache = dic[key];
//             lruList.Remove(cache);
//             lruList.AddFirst(cache);
//         }
//         else
//         {   
//             // add a new cache to the dic and lru
//             Cache cache = new Cache(key, value);
//             dic.Add(key, new LinkedListNode<Cache>(cache));
//             lruList.AddFirst(dic[key]);
            
//             if(dic.Count > _capacity)
//             {
//                 // remove the last cache from the dic and lruList if capacity execeeds the limit
//                 // use lruList.Last instead of lruList.Last() to get the LinkedListNode object
// 				// this helps remove lastCache from lruList in O(1)
//                 LinkedListNode<Cache> lastCache = lruList.Last;
//                 dic.Remove(lastCache.Value.CacheKey);
//                 lruList.Remove(lastCache);
//             }  
//         } 
//     }
// }


// public class Cache
// {
//     public int CacheKey;
//     public int CacheVal;
//     public Cache(int key, int val)
//     {
//         CacheKey = key;
//         CacheVal = val;
//     }
// }

// using System.Collections.Specialized;
// public class LRUCache 
// {
//     private readonly OrderedDictionary map;
//     private readonly int capacity;
    
//     public LRUCache(int capacity)     
//     {
//         map = new OrderedDictionary();
//         this.capacity = capacity;
//     }
    
//     public int Get(int key) 
//     {
//         if(map.Count > 0 && map.Contains(key))
//         {
//             int target = (int)map[(object)key];            
//             map.Remove((object)key);
//             map.Add(key,target);            
//             return target;
//         }
//         return -1;
//     }
    
//     public void Put(int key, int value) 
//     {
//         if(map.Contains((object)key))
//         {
//             map.Remove((object)key);
//             map.Add(key,value); 
//         }
//         else
//         {
//             if(map.Count >= capacity)
//             {
//                 map.RemoveAt(0);
//             }
//             map.Add(key,value);
//         }
//     }
// }


/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */