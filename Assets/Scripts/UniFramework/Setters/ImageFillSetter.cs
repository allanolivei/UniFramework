namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Setter/UI/Image Fill Setter")]
    public class ImageFillSetter : Setter
    {

        public bool useFloatVariable = true;
        public FloatVariable variable;
        public IntVariable intVariable;
        public Image image;
        public float divisor = 1;

        public override void Set()
        {
            image.fillAmount = useFloatVariable ? variable.Value / divisor : intVariable.Value / divisor;
        }
    }
}
