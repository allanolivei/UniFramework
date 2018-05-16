namespace UniFramework.Utility
{
    using System.Collections.Generic;
    using UnityEngine;


    public static class ObjectPool
    {
        public class Pool
        {
            public string id;
            public GameObject prefab;
            public Transform defaultParent;
            public Queue<GameObject> pooling = new Queue<GameObject>();
            public List<GameObject> used = new List<GameObject>();
        }

        public static Dictionary<string, Pool> pooling = new Dictionary<string, Pool>();

        public static bool Register(string id, GameObject prefab, Transform defaultParent = null)
        {
            if (pooling.ContainsKey(id)) return false;
            Pool p = new Pool() { id = id, prefab = prefab, defaultParent = defaultParent };
            pooling.Add(id, p);
            return true;
        }

        public static void Warm(GameObject obj, string id, int amount)
        {
            GameObject[] objs = new GameObject[amount];
            if (pooling.ContainsKey(id))
            {
                for (int i = 0; i < amount; i++)
                {
                    objs[i] = Create(obj);
                    objs[i].SetActive(false);
                }
                for (int i = 0; i < amount; i++)
                {
                    Recycle(id, objs[i]);
                }
            }
            else
            {
                Debug.LogError("There is no pool registered with id \" " + id + " \"");
            }
        }

        public static GameObject Get(string id)
        {
            Pool p;
            if (pooling.TryGetValue(id, out p))
            {
                GameObject go = (p.pooling.Count > 0) ? p.pooling.Dequeue() : Create(p.prefab);
                go.SetActive(true);
                p.used.Add(go);
                return go;
            }

            return default(GameObject);
        }

        public static List<GameObject> GetUsed(string id)
        {
            Pool p;
            if (pooling.TryGetValue(id, out p)) return p.used;

            return default(List<GameObject>);
        }

        public static T Get<T>(string id) where T : MonoBehaviour
        {
            return Get(id).GetComponent<T>();
        }

        public static bool Recycle(string id, GameObject obj)
        {
            Pool p;
            obj.SetActive(false);

            if (pooling.TryGetValue(id, out p))
            {
                obj.transform.SetParent(p.defaultParent);
                p.pooling.Enqueue(obj);

                if (p.used.Contains(obj)) p.used.Remove(obj);

                return true;
            }

            return false;
        }

        public static void Clear(string id)
        {
            Pool p;
            if (pooling.TryGetValue(id, out p))
            {
                foreach (GameObject ob in p.pooling)
                    GameObject.Destroy(ob);
                p.pooling.Clear();

                foreach (GameObject ob in p.used)
                    GameObject.Destroy(ob);
                p.used.Clear();
            }
        }

        public static void Clear()
        {
            foreach (KeyValuePair<string, Pool> pair in pooling) Clear(pair.Key);
        }

        public static void Destroy(string id)
        {
            Clear(id);
            pooling.Remove(id);
        }

        public static void Destroy()
        {
            Clear();
            pooling.Clear();
        }

        public static GameObject Create(GameObject prefab)
        {
            return GameObject.Instantiate(prefab);
        }
    }

    public interface IObjectPool
    {
        void Recycle(Object obj);
    }

    public class ObjectPoolTP<T> : IObjectPool where T : Object
    {
        private Queue<T> pool = new Queue<T>();
        private T objRef;

        public ObjectPoolTP(T objRef, int initAmount = 0)
        {
            this.objRef = objRef;
            for (int i = 0; i < initAmount; i++) pool.Enqueue(Create());
        }

        public void Recycle(Object obj)
        {
            pool.Enqueue(obj as T);
        }

        public void Recycle(T obj)
        {
            pool.Enqueue(obj);
        }

        public bool Has()
        {
            return pool.Count > 0;
        }

        public T Get()
        {
            return (pool.Count > 0) ? pool.Dequeue() : Create();
        }

        public T Create()
        {
            return Object.Instantiate<T>(objRef);
        }

        public void Clear()
        {
            foreach (T obj in pool) if (obj != null) GameObject.Destroy(obj);
            pool.Clear();
        }

        public int Length { get { return pool.Count; } }

    }
}