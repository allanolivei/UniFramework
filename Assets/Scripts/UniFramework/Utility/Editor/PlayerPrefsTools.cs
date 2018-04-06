#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerPrefsTools : MonoBehaviour {

    [MenuItem("Tools/PlayerPrefs/Delete All")]
    public static void DeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs saves were deleted!");
    }
}
#endif