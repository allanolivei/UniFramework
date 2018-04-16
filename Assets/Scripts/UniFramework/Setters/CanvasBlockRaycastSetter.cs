namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/UI/Block Raycast Setter")]
    public class CanvasBlockRaycastSetter : Setter
    {

        public CanvasGroup canvasGroup;
        public BoolReference isBlocking;

        public override void Set()
        {
            canvasGroup.blocksRaycasts = isBlocking.Value;
        }
    }
}
