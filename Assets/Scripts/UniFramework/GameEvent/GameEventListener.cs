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
        public Vector2Reference randomVariance;

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
            if (delay <= 0)
                Response.Invoke();
            else
                StartCoroutine(RaiseAfter(delay.Value + Random.Range(randomVariance.Value.x, randomVariance.Value.y)));
        }

        IEnumerator RaiseAfter(float seconds)
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