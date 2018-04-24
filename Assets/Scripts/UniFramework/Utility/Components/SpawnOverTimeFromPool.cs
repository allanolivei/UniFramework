namespace UniFramework.Utility
{
    using System.Collections;
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SpawnOverTimeFromPool : MonoBehaviour
    {
        public BoolReference spawnOnAwake;
        public BoolReference spawnOnStart;
        public BoolReference spawnOnEnable;
        [Space(10)]
        public GameObject prefab;
        [Tooltip("The name of the scene where this prefab will be spawned")]
        public StringReference targetSceneName;
        public StringReference poolID;
        [Space(10)]
        public IntReference amountPerTick;
        public IntReference ticks;
        public FloatReference interval;
        public FloatReference delay;

        void Awake()
        {
            if (spawnOnAwake.Value)
            {
                //Workaround to make it work on Additive scenes
                SceneManager.activeSceneChanged += OnLevelFinishedLoading;
            }
        }

        void Start()
        {
            if (spawnOnStart.Value)
            {
                Spawn();
            }
        }

        void OnEnable()
        {
            if (spawnOnEnable.Value)
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
        /// Spawn and pool over time instances of a prefab acording to the settings of the SpawnFromPool instance variables
        /// </summary>
        public void Spawn()
        {
            SpawnOverTime(prefab, poolID, interval, ticks, amountPerTick, delay: delay);
        }

        /// <summary>
        /// Spawn and pool over time instances of a prefab
        /// </summary>
        /// <param name="prefab">GameObject (Prefab) to be spawned</param>
        /// <param name="id">The id registered to the prefab's ObjectPool</param>
        /// <param name="interval">Interval between spawnings</param>
        /// <param name="ticks">Amount of spawnings</param>
        /// <param name="spawnAmountPerTick">Amount to be spawned on every interval</param>
        /// <param name="delay">Delay before the first tick</param>
        public void SpawnOverTime(GameObject prefab, string id, float interval, int ticks, int spawnAmountPerTick, float delay = 0)
        {
            ObjectPool.Register(id, prefab);
            StartCoroutine(WarmOverTime(id, interval, ticks, spawnAmountPerTick, delay));
        }

        IEnumerator WarmOverTime(string id, float interval, int ticks, int spawnAmountPerTick, float delay = 0)
        {
            yield return new WaitForSeconds(delay);
            WaitForSeconds wait = new WaitForSeconds(interval);
            for (int i = 0; i < ticks; i++)
            {
                ObjectPool.Warm(prefab, id, spawnAmountPerTick);
                yield return wait;
            }
        }
    }
}