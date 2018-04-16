using UnityEngine;

public static class ColorExtensions
{
    public static Color WithAlpha(this Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }

    public static void Randomize(this Color color)
    {
        color.r = Random.Range(0, 1f);
        color.g = Random.Range(0, 1f);
        color.b = Random.Range(0, 1f);
    }

    public static void RandomizeWithRandomAlpha(this Color color)
    {
        color.r = Random.Range(0, 1f);
        color.g = Random.Range(0, 1f);
        color.b = Random.Range(0, 1f);
        color.a = Random.Range(0, 1f);
    }

    public static void RandomizeR(this Color color)
    {
        color.r = Random.Range(0, 1f);
    }

    public static void RandomizeG(this Color color)
    {
        color.g = Random.Range(0, 1f);
    }

    public static void RandomizeB(this Color color)
    {
        color.b = Random.Range(0, 1f);
    }
}
