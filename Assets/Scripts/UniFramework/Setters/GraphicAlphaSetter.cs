namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Setter/UI/Graphic Alpha Setter")]
    public class GraphicAlphaSetter : Setter
    {
        public Graphic UIElement;
        public FloatReference alpha;

        public override void Set()
        {
            UIElement.color = new Color(UIElement.color.r, UIElement.color.g, UIElement.color.b, alpha);
        }
    }
}
