using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Int", menuName = "Variables/Int")]
public class IntVariable : ScriptableVariable {

    public int value;

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

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public void Add(int x)
    {
        value += x;
    }

    public void Subtract(int x)
    {
        value -= x;
    }

    public void Multiply(int x)
    {
        value *= x;
    }

    public void Divide(int x)
    {
        value /= x;
    }
}
