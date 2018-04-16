namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/Transform/Scale Setter")]
    public class ScaleSetter : Setter
    {

        public Vector3Reference newScale;
        public Transform target;

        public override void Set()
        {
            target.localScale = newScale.Value;
        }
    }
}
