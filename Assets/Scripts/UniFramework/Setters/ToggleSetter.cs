using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Setter/UI/Toggle Setter")]
public class ToggleSetter : Setter {

    public Toggle toggle;
    public BoolReference isOn;

    public override void Set()
    {
        toggle.isOn = isOn.Value;
    }
}
