﻿using UnityEngine;

[CreateAssetMenu(fileName = "Vector3", menuName = "Variables/Vector3")]
public class Vector3Variable : ScriptableVariable
{

    public Vector3 value;

    public override dynamic DynamicGet()
    {
        return value;
    }

    public override void DynamicSet(dynamic newValue)
    {
        try
        {
            SetValue(newValue);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public void SetValue(Vector3 newValue)
    {
        value = newValue;
    }
}