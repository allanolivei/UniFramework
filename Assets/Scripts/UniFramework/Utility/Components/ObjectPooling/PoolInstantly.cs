namespace UniFramework.Utility
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PoolInstantly : MonoBehaviour
    {
        public BoolReference poolOnAwake;
        [Tooltip("Warning: if poolOnAdditiveScene is enabled, the pooling on Start will ONLY work if the scene is loaded using Additive mode. Awake and OnEnable will work on Additive and Single (Default).")]
        public BoolReference poolOnStart;
        public BoolReference poolOnEnable;
        [Space(10)]
        public GameObject prefab;
        public StringReference poolID;
        public IntReference amountToPool;
        [Space(10)]
        [Tooltip("Warning: enabling this will make pooling on Start ONLY work if the scene is loaded using Additive mode. Awake and OnEnable work both ways.")]
        public bool poolOnAdditiveScene;
        [Tooltip("You may leave this empty if Pool On Additive Scene is set to false")]
#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.ShowIf("poolOnAdditiveScene")]
#endif
        public StringReference targetSceneName;

        /// <summary>
        /// If true, Pooling on Awake, Start or OnEnable will disable automatic pools in the future (for this instance).
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
        /// Intantiate and pool instances of a prefab acording to the settings of the SpawnFromPool's instance variables
        /// </summary>
        public void Pool()
        {
            if (!poolOnce || (poolOnce && !pooled))
            {
                Pool(prefab, poolID, transform, amount: amountToPool);
                pooled = true;
            }
        }

        /// <summary>
        /// Intantiate and pool instances of a prefab
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="id">The id registered to the prefab's ObjectPool</param>
        /// <param name="amount"></param>
        public static void Pool(GameObject prefab, string id, Transform defaultParent, int amount = 1)
        {
            ObjectPool.Register(id, prefab, defaultParent: defaultParent);
            ObjectPool.Warm(prefab, id, amount);
        }
    }
}