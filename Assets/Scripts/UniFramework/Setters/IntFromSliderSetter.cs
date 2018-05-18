namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Setter/Variables/Int From Slider Setter")]
    public class IntFromSliderSetter : Setter
    {
        public Slider slider;
        public IntVariable variable;

        public override void Set()
        {
            variable.Value = (int)slider.value;
        }
    }
}
