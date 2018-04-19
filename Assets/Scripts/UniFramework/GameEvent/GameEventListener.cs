namespace UniFramework.Events
{
    using UnityEngine;
    using UnityEngine.Events;

    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
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