namespace UniFramework.Utility
{
    using DG.Tweening;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class LoadSceneWithProgressBar : MonoBehaviour
    {
        public Image imageToFill;
        public AudioListener audioListener;
        public float delayToStartLoading = .5f;
        public float delayToOpenLoadedScene = .25f;
        public bool fakeProgress = true;
        public float fakeProgressRate = 2f;
        public UnityEvent operationDone;
        public static int sceneIndex;

        private float percent = 0;
        private float progress = 0;

        private void Start()
        {
            try
            {
                LoadLevel(sceneIndex);
            }
            catch (System.Exception)
            {
                LoadLevel(0);
                throw;
            }
        }

        private void LoadLevel(int sceneIndex)
        {
            imageToFill.fillAmount = 0;
            StartCoroutine(LoadAsync(sceneIndex));
        }

        private IEnumerator LoadAsync(int sceneIndex)
        {
            string loadSceneName = SceneManager.GetActiveScene().name;
            float initTime = Time.unscaledTime;
            progress = 0;
            Time.timeScale = 0;
            DOTween.timeScale = 0;

            yield return new WaitForSecondsRealtime(delayToStartLoading);
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

            while (!operation.isDone || progress < 1)
            {
                if (operation.progress >= 1 || operation.isDone)
                {
                    audioListener.enabled = false;
                }

                percent = (Time.unscaledTime - initTime) / fakeProgressRate;

                if (fakeProgress)
                {
                    progress = Mathf.Min(Mathf.Clamp01(operation.progress / .9f), percent);
                }
                else
                {
                    progress = Mathf.Clamp01(operation.progress / .9f);
                }

                imageToFill.fillAmount = percent;

                yield return null;
            }

            operationDone.Invoke();
            yield return new WaitForSecondsRealtime(delayToOpenLoadedScene);

            Time.timeScale = 1;
            DOTween.timeScale = 1;
            SceneManager.UnloadSceneAsync(loadSceneName);
        }
    }
}