using UnityEngine;

[AddComponentMenu("Setter/Variables/Int Setter")]
public class IntSetter : Setter {

    public IntReference newValue;
    public IntVariable variable;

    public override void Set()
    {
        variable.SetValue(newValue.Value);
    }
}
