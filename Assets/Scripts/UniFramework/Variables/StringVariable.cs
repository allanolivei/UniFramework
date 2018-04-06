using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "String", menuName = "Variables/String")]
public class StringVariable : ScriptableVariable {
    public string value;

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

    public void SetValue(string newValue)
    {
        value = newValue;
    }
}
