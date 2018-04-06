using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float", menuName = "Variables/Float")]
public class FloatVariable : ScriptableVariable {

    public float value;

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

    public void SetValue(float newValue)
    {
        value = newValue;
    }

    public void Add(float x)
    {
        value += x;
    }

    public void Subtract(float x)
    {
        value -= x;
    }

    public void Multiply(float x)
    {
        value *= x;
    }

    public void Divide(float x)
    {
        value /= x;
    }
}
