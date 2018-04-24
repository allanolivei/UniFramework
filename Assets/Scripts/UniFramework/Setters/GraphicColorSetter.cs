namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Setter/UI/Graphic Color Setter")]
    public class GraphicColorSetter : Setter
    {
        public Graphic UIElement;
        public ColorReference color;

        public override void Set()
        {
            UIElement.color = color;
        }
    }
}
