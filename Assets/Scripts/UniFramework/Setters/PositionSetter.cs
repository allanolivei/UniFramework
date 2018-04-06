using UnityEngine;

[AddComponentMenu("Setter/Transform/Position Setter")]
public class PositionSetter : Setter {

    public Vector3Reference newPosition;
    public Transform target;

    public override void Set()
    {
        target.position = newPosition.Value;
    }
}
