using UnityEngine;

[AddComponentMenu("Setter/Transform/Rotation Setter")]
public class RotationSetter : Setter {

    public Vector3Reference newRotation;
    public Transform target;

    public override void Set()
    {
        target.localEulerAngles = newRotation.Value;
    }
}
