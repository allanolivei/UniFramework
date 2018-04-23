namespace UniFramework.Utility
{
    using UnityEngine;
    using UnityEngine.Events;

    public class EventInvoker : MonoBehaviour
    {
        public UnityEvent unityEvent;

        public bool invokeOnAwake;
        public bool invokeOnStart;
        public bool invokeOnUpdate;

        void Awake()
        {
            if (invokeOnAwake)
            {
                unityEvent.Invoke();
            }
        }

        void Start()
        {
            if (invokeOnStart)
            {
                unityEvent.Invoke();
            }
        }

        void Update()
        {
            if (invokeOnUpdate)
            {
                unityEvent.Invoke();
            }
        }
    }
}