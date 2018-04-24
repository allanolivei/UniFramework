namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/PlayerPrefs/Float From PlayerPrefs Setter")]
    public class FloatFromPlayerPrefsSetter : Setter
    {
        public FloatVariable variable;
        public StringReference playerPrefsKey;

        public override void Set()
        {
            variable.SetValue(PlayerPrefs.GetFloat(playerPrefsKey));
        }
    }
}