using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "Variables/Color")]
public class ColorVariable : ScriptableVariable {

    public Color value;

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

    public void SetValue(Color newValue)
    {
        value = newValue;
    }
}
