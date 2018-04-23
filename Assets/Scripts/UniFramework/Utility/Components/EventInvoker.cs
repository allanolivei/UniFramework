namespace UniFramework.Utility
{
    using System.Collections;
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.Events;

    public class EventInvoker : MonoBehaviour
    {
        public UnityEvent unityEvent;

        public IntReference[] delayInt;
        public FloatReference[] delayFloat;

        public bool invokeOnAwake;
        public bool invokeOnStart;
        public bool invokeOnUpdate;

        void Awake()
        {
            if (invokeOnAwake)
            {
                Invoke();
            }
        }

        void Start()
        {
            if (invokeOnStart)
            {
                Invoke();
            }
        }

        void Update()
        {
            if (invokeOnUpdate)
            {
                Invoke();
            }
        }

        public void Invoke()
        {
            float delay = 0;

            foreach (var item in delayInt)
            {
                delay += item;
            }
            foreach (var item in delayFloat)
            {
                delay += item;
            }

            StartCoroutine(InvokeAfterDelay(delay));
        }

        public void InvokeIgnoringDelay()
        {
            unityEvent.Invoke();
        }

        private IEnumerator InvokeAfterDelay(float totalDelay)
        {
            yield return new WaitForSeconds(totalDelay);
            unityEvent.Invoke();
        }
    }
}