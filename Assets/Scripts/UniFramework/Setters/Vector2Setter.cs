using UnityEngine;

[AddComponentMenu("Setter/Variables/Vector2 Setter")]
public class Vector2Setter : Setter {

    public Vector2Reference newVector2;
    public Vector2Variable variable;

    public override void Set()
    {
        variable.value = newVector2.Value;
    }
}
