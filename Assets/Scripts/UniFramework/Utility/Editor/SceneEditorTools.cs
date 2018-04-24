namespace UniFramework.Utility.Editor
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEditor.SceneManagement;
    using UnityEngine;

    public class SceneEditorTools
    {

        [MenuItem("Scene/Game _F5")]
        public static void OpenMainScene()
        {
            EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/Game.unity");
        }

        [MenuItem("Scene/Main Menu")]
        public static void Menu()
        {
            EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/Menu.unity");
        }

        [MenuItem("Scene/Preload")]
        public static void Preload()
        {
            EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/_preload.unity");
        }

        [MenuItem("Scene/Load Scene")]
        public static void LoadScene()
        {
            EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/LoadScene.unity");
        }

        //[MenuItem("Scene/Load Next")]
        //public static void LoadNextScene()
        //{
        //    EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex + 1); 
        //}

        //[MenuItem("Scene/Load Previous")]
        //public static void LoadPreviousScene()
        //{
        //    EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex - 1);
        //}
    }
#endif
}