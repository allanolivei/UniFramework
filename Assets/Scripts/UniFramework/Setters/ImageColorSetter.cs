using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Setter/UI/Image Color Setter")]
public class ImageColorSetter : Setter {

    public ColorReference newColor;
    public Image image;

    public override void Set()
    {
        image.color = newColor.Value;
    }
}
