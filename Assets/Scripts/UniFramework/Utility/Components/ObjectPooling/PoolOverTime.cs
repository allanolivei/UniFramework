namespace UniFramework.Utility
{
    using System.Collections;
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PoolOverTime : MonoBehaviour
    {
        public BoolReference poolOnAwake;
        [Tooltip("Warning: if poolOnAdditiveScene is enabled, the pooling on Start will ONLY work if the scene is loaded using Additive mode. Awake and OnEnable will work on Additive and Single (Default).")]
        public BoolReference poolOnStart;
        public BoolReference poolOnEnable;
        [Space(10)]
        public GameObject prefab;
        public StringReference poolID;
        [Tooltip("The name of the scene where this prefab will be pooled")]
        public StringReference targetSceneName;
        [Tooltip("Warning: enabling this will make pooling on Start ONLY work if the scene is loaded using Additive mode. Awake and OnEnable will work both ways.")]
        public BoolReference poolOnAdditiveScene;
        [Space(10)]
        public IntReference amountPerTick;
        public IntReference ticks;
        public FloatReference interval;
        public FloatReference delay;

        void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnLevelFinishedLoadingAwake;
            SceneManager.activeSceneChanged -= OnLevelFinishedLoadingStart;
            SceneManager.activeSceneChanged -= OnLevelFinishedLoadingEnable;
        }

        void Awake()
        {
            if (poolOnAwake)
            {
                if (poolOnAdditiveScene)
                    SceneManager.activeSceneChanged += OnLevelFinishedLoadingAwake;
                else
                    Pool();
            }
        }

        void Start()
        {
            if (poolOnStart)
            {
                if (poolOnAdditiveScene)
                    SceneManager.activeSceneChanged += OnLevelFinishedLoadingStart;
                else
                    Pool();
            }
        }

        void OnEnable()
        {
            if (poolOnEnable)
            {
                if (poolOnAdditiveScene)
                    SceneManager.activeSceneChanged += OnLevelFinishedLoadingEnable;
                else
                    Pool();
            }
        }

        void OnLevelFinishedLoadingAwake(Scene previousScene, Scene newScene)
        {
            if (newScene.name == targetSceneName)
            {
                Pool();
            }
        }

        void OnLevelFinishedLoadingStart(Scene previousScene, Scene newScene)
        {
            if (newScene.name == targetSceneName)
            {
                Pool();
            }
        }

        void OnLevelFinishedLoadingEnable(Scene previousScene, Scene newScene)
        {
            if (newScene.name == targetSceneName)
            {
                Pool();
            }
        }

        /// <summary>
        /// Spawn and pool over time instances of a prefab acording to the settings of the SpawnFromPool's instance variables
        /// </summary>
        public void Pool()
        {
            Pool(prefab, poolID, interval, ticks, amountPerTick, delay: delay);
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
        public void Pool(GameObject prefab, string id, float interval, int ticks, int spawnAmountPerTick, float delay = 0)
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