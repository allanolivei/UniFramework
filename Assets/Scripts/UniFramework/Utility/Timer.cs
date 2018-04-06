using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Timer : MonoBehaviour {

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
        elapsedTime.value = initialValue;
        PauseTimer();
    }

    private void Update()
    {
        if (running)
        {
            if (!decremental)
            {
                elapsedTime.value = Mathf.Clamp(elapsedTime.value + Time.deltaTime, limits.x, limits.y);
            }
            else
            {
                elapsedTime.value = Mathf.Clamp(elapsedTime.value - Time.deltaTime, limits.x, limits.y);
            }

            if (checkLimits)
            {
                if (elapsedTime.value == limits.x)
                {
                    lowerLimitCallback.Invoke();
                    if (pauseOnLimitCallback)
                        PauseTimer();
                }
                if (elapsedTime.value == limits.y)
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
        elapsedTime.value = initialValue;
        StartTimer();
    }

    public void Add(float amount)
    {
        elapsedTime.value = Mathf.Clamp(elapsedTime.value + amount, limits.x, limits.y);
    }
}
