namespace UniFramework.Utility
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.Events;

    public class Timer : MonoBehaviour
    {

#if ODIN_INSPECTOR
        [Sirenix.OdinInspector.InlineEditor]
#endif
        public FloatVariable elapsedTime;
        public bool decremental;
        public float initialValue;
        public Vector2 limits = new Vector2(0, 60);
        public bool checkLimits;
        public bool pauseOnLimitCallback = true;
        public UnityEvent lowerLimitCallback;
        public UnityEvent upperLimitCallback;
        private bool running;

        private void Awake()
        {
            elapsedTime.Value = initialValue;
            PauseTimer();
        }

        private void Update()
        {
            if (running)
            {
                if (!decremental)
                {
                    elapsedTime.Value = Mathf.Clamp(elapsedTime.Value + Time.deltaTime, limits.x, limits.y);
                }
                else
                {
                    elapsedTime.Value = Mathf.Clamp(elapsedTime.Value - Time.deltaTime, limits.x, limits.y);
                }

                if (checkLimits)
                {
                    if (elapsedTime.Value == limits.x)
                    {
                        lowerLimitCallback.Invoke();
                        if (pauseOnLimitCallback)
                            PauseTimer();
                    }
                    if (elapsedTime.Value == limits.y)
                    {
                        upperLimitCallback.Invoke();
                        if (pauseOnLimitCallback)
                            PauseTimer();
                    }
                }
            }

        }

        public void StartTimer()
        {
            running = true;
        }

        public void PauseTimer()
        {
            running = false;
        }

        public void ToggleTimer()
        {
            running = !running;
        }

        public void ResetAndStart()
        {
            elapsedTime.Value = initialValue;
            StartTimer();
        }

        public void Add(float amount)
        {
            elapsedTime.Value = Mathf.Clamp(elapsedTime.Value + amount, limits.x, limits.y);
        }
    }
}
