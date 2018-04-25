#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Originally "UnityUtilities" from https://github.com/TobiasWehrum/unity-utilities
/// </summary>
namespace UniFramework.Utility.Editor
{
    [CustomPropertyDrawer(typeof(RangedFloat))]
    public class RangeFloatPropertyDrawer : RangePropertyDrawerBase
    {
    }
}
#endif