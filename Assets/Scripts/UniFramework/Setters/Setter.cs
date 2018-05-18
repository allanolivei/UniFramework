namespace UniFramework.Setters
{
    using UnityEngine;

    [AddComponentMenu("")]
    public class Setter : MonoBehaviour
    {

        public bool setOnAwake;
        public bool setOnStart;
        public bool setOnEnable;
        public bool setOnUpdate;

        void Awake()
        {
            if (setOnAwake)
            {
                Set();
            }
        }

        void Start()
        {
            if (setOnStart)
            {
                Set();
            }
        }

        private void OnEnable()
        {
            if (setOnEnable)
            {
                Set();
            }
        }

        void Update()
        {
            if (setOnUpdate)
            {
                Set();
            }
        }

#if ODIN_INSPECTOR && UNITY_EDITOR
        private bool IsPlaying()
        {
            return Application.isPlaying;
        }

        [Sirenix.OdinInspector.Button(Sirenix.OdinInspector.ButtonSizes.Medium)]
        [Sirenix.OdinInspector.PropertyOrder(9999)]
        [Sirenix.OdinInspector.ShowIf("IsPlaying")]
#endif
        public virtual void Set()
        {

        }
    }
}
