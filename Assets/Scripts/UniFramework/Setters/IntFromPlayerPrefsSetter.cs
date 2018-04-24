namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/PlayerPrefs/Int From PlayerPrefs Setter")]
    public class IntFromPlayerPrefsSetter : Setter
    {
        public IntVariable variable;
        public StringReference playerPrefsKey;

        public override void Set()
        {
            variable.SetValue(PlayerPrefs.GetInt(playerPrefsKey));
        }
    }
}