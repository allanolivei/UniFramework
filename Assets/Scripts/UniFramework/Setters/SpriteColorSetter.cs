using UnityEngine;

[AddComponentMenu("Setter/2D and 3D/Sprite Color Setter")]
public class SpriteColorSetter : Setter {

    public ColorReference newColor;
    public SpriteRenderer spriteRenderer;

    public override void Set()
    {
        spriteRenderer.color = newColor.Value;
    }
}
