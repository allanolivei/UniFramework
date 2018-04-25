﻿using UnityEditor;

/// <summary>
/// Originally "UnityUtilities" from https://github.com/TobiasWehrum/unity-utilities
/// </summary>
namespace UniFramework.Utility.Editor
{
    [CustomPropertyDrawer(typeof(RangedInt))]
    public class RangeIntPropertyDrawer : RangePropertyDrawerBase
    {
    }
}