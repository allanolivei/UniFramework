namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("Setter/UI/Slider Setter")]
    public class SliderSetter : Setter
    {

        public bool useFloatVariable = true;
        public FloatVariable variable;
        public IntVariable intVariable;
        public Slider slider;

        public override void Set()
        {
            slider.value = useFloatVariable ? variable.Value : intVariable.Value;
        }
    }
}
