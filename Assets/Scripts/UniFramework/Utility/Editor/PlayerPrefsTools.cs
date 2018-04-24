namespace UniFramework.Utility.Editor
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;

    public class PlayerPrefsTools : MonoBehaviour
    {

        [MenuItem("Tools/PlayerPrefs/Delete All")]
        public static void DeleteAllPrefs()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("All PlayerPrefs saves were deleted!");
        }
    }
#endif
}