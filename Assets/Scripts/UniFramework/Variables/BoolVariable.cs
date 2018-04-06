using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool", menuName = "Variables/Bool")]
public class BoolVariable : ScriptableVariable
{
    public bool value;

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

    public void SetValue(bool newValue)
    {
        value = newValue;
    }
}
