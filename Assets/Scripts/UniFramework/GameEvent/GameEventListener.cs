namespace UniFramework.Events
{
    using System.Collections;
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.Events;

    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent[] Events;

        public FloatReference delay;
        public Vector2Reference randomVariance;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            if (Events.Length == 0)
            {
                Debug.LogWarning($"There are no GameEvents registered on {gameObject.name}'s GameEventListener!");
            }

            for (int i = 0; i < Events.Length; i++)
            {
                Events[i].AddListener(this);
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < Events.Length; i++)
            {
                Events[i].RemoveListener(this);
            }
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
    }
}