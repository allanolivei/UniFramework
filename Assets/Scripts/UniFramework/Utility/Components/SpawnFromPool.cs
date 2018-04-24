namespace UniFramework.Utility
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SpawnFromPool : MonoBehaviour
    {
        public BoolReference spawnOnAwake;
        public BoolReference spawnOnStart;
        public BoolReference spawnOnEnable;
        [Space(10)]
        public GameObject prefab;
        public StringReference targetSceneName;
        public StringReference poolID;
        public IntReference amountToPool;

        void Awake()
        {
            if (spawnOnAwake)
            {
                SceneManager.activeSceneChanged += OnLevelFinishedLoading;
            }
        }

        void Start()
        {
            if (spawnOnStart)
            {
                Spawn();
            }
        }

        void OnEnable()
        {
            if (spawnOnEnable)
            {
                Spawn();
            }
        }

        void OnLevelFinishedLoading(Scene previousScene, Scene newScene)
        {
            if (newScene.name == targetSceneName)
            {
                Spawn();
            }
        }

        /// <summary>
        /// Spawn and pool instances of a prefab acording to the settings of the SpawnFromPool instance variables
        /// </summary>
        public void Spawn()
        {
            Spawn(prefab, poolID, amount: amountToPool);
        }

        /// <summary>
        /// Spawn and pool instances of a prefab
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="id">The id registered to the prefab's ObjectPool</param>
        /// <param name="amount"></param>
        public static void Spawn(GameObject prefab, string id, int amount = 1)
        {
            ObjectPool.Register(id, prefab);
            ObjectPool.Warm(prefab, id, amount);
        }
    }
}