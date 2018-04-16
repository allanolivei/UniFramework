namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Variables/Vector3 Setter")]
    public class Vector3Setter : Setter
    {

        public Vector3Reference newVector3;
        public Vector3Variable variable;

        public override void Set()
        {
            variable.Value = newVector3.Value;
        }
    }
}
