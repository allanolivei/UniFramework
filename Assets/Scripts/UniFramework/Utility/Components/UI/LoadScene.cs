﻿namespace UniFramework.Utility
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class LoadScene : MonoBehaviour
    {

        public void LoadWithProgressBar(int sceneIndex)
        {
            LoadSceneWithProgressBar.sceneIndex = sceneIndex;
            Load("LoadScene");
        }

        public void Load(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Reload()
        {
            Load(SceneManager.GetActiveScene().buildIndex);
        }
    }
}