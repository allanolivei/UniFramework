namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Setter/Variables/Float From Slider Setter")]
    public class FloatFromSliderSetter : Setter
    {
        public Slider slider;
        public FloatVariable variable;

        public override void Set()
        {
            variable.Value = slider.value;
        }
    }
}
