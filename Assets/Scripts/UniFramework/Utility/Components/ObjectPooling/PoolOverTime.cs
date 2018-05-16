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
        public IntReference amountPerTick;
        public IntReference ticks;
        public FloatReference interval;
        public FloatReference delay;
        [Space(10)]
        [Tooltip("Warning: enabling this will make pooling on Start ONLY work if the scene is loaded using Additive mode. Awake and OnEnable work both ways.")]
        public bool poolOnAdditiveScene;
        [Tooltip("You may leave this empty if Pool On Additive Scene is set to false")]
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.ShowIf("poolOnAdditiveScene")]
#endif
        public StringReference targetSceneName;


        /// <summary>
        /// If true, pooling on Awake, Start or OnEnable will disable subsequent pools in the future (for this instance).
        /// This setting does NOT affect pools called manually using Pool() by other scripts.
        /// </summary>
        [HideInInspector]
        public bool poolOnce = true;
        private bool pooled;

        void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnLevelFinishedLoadingAwake;
            SceneManager.activeSceneChanged -= OnLevelFinishedLoadingStart;
            SceneManager.activeSceneChanged -= OnLevelFinishedLoadingEnable;
            ObjectPool.Clear(poolID);
        }

        void Awake()
        {
            if (poolOnAwake && !pooled)
            {
                if (poolOnAdditiveScene)
                    SceneManager.activeSceneChanged += OnLevelFinishedLoadingAwake;
                else
                    Pool();
            }
        }

        void Start()
        {
            if (poolOnStart && !pooled)
            {
                if (poolOnAdditiveScene)
                    SceneManager.activeSceneChanged += OnLevelFinishedLoadingStart;
                else
                    Pool();
            }
        }

        void OnEnable()
        {
            if (poolOnEnable && !pooled)
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
            if (!poolOnce || (poolOnce && !pooled))
            {
                Pool(prefab, poolID, transform, interval, ticks, amountPerTick, delay: delay);
                pooled = true;
            }
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
        public void Pool(GameObject prefab, string id, Transform defaultParent, float interval, int ticks, int spawnAmountPerTick, float delay = 0)
        {
            ObjectPool.Register(id, prefab, defaultParent: defaultParent);
            StartCoroutine(WarmOverTime(id, interval, ticks, spawnAmountPerTick, delay));
        }

        private IEnumerator WarmOverTime(string id, float interval, int ticks, int spawnAmountPerTick, float delay = 0)
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