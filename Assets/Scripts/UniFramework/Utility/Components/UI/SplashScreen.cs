namespace UniFramework.Utility
{
    using System.Collections;
    using UnityEngine;

    using UnityEngine.SceneManagement;

    public class SplashScreen : MonoBehaviour
    {

        public CanvasGroup[] Screens;
        public string NextsceneName;
        public bool isTouching = false;
        public AnimationCurve lineAlpha;
        int indexGroup = 0;

        void Start()
        {
            StartCoroutine("Splash");
        }

        IEnumerator Splash()
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(WaitForSecondsUnscale(3.0f, Screens[0]));
        }

        IEnumerator WaitForSecondsUnscale(float duration, CanvasGroup cGroup)
        {
            //Debug.Log("Index corrotinha" + index);
            float initTime = Time.unscaledTime;
            float init = cGroup.alpha;
            while (true)
            {
                float percent = (Time.unscaledTime - initTime) / duration;
                cGroup.alpha = lineAlpha.Evaluate(percent); //Mathf.Lerp(init, toDo, percent);

                //Debug.Log("Hakuna");

#if UNITY_ANDROID
                isTouching = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#endif


#if !UNITY_ANDROID || UNITY_EDITOR
                isTouching = Input.anyKeyDown;

#endif
                if (percent >= 1.0f || isTouching)
                {
                    isTouching = false;
                    cGroup.alpha = 0;
                    if (indexGroup == 0)
                    {
                        indexGroup++;
                        yield return null;
                        StartCoroutine(WaitForSecondsUnscale(3.0f, Screens[indexGroup]));
                    }
                    else if (indexGroup == 1)
                        SceneManager.LoadScene(NextsceneName);
                    break;
                }
                yield return null;
            }
        }
    }
}