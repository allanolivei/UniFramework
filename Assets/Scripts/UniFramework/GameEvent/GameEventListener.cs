namespace UniFramework.Events
{
    using System.Collections;
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.Events;

    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        public FloatReference delay;

        [Tooltip("Response to invoke when Event is invoked.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            Event.AddListener(this);
        }

        private void OnDisable()
        {
            Event.RemoveListener(this);
        }

        public void OnEventRaised()
        {
            if (delay <= 0)
                Response.Invoke();
            else
                StartCoroutine(InvokeAfter(delay));
        }

        IEnumerator InvokeAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            Response.Invoke();
        }

#if ODIN_INSPECTOR
        private string GetButtonName { get { return "Invoke " + Event?.name; } }

        [Sirenix.OdinInspector.Button("$GetButtonName", Sirenix.OdinInspector.ButtonSizes.Large)]
        public void Invoke()
        {
            Event.Invoke();
        }
#endif
    }
}