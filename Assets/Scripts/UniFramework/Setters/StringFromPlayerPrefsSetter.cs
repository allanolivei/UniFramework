namespace UniFramework.Setters
{
    using UniFramework.Variables;
    using UnityEngine;

    [AddComponentMenu("Setter/PlayerPrefs/String From PlayerPrefs Setter")]
    public class StringFromPlayerPrefsSetter : Setter
    {
        public StringVariable variable;
        public StringReference playerPrefsKey;

        public override void Set()
        {
            variable.SetValue(PlayerPrefs.GetString(playerPrefsKey));
        }
    }
}
