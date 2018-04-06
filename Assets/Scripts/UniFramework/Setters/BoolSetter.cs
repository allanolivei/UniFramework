using UnityEngine;

[AddComponentMenu("Setter/Variables/Bool Setter")]
public class BoolSetter : Setter {
    public BoolReference newValue;
    public BoolVariable variable;

    public override void Set()
    {
        variable.SetValue(newValue.Value);
    }
}
