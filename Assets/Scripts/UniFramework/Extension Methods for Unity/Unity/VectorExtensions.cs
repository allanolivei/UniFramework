using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 DirectionTo(this Vector3 from, Vector3 to)
    {
        return to - from;
    }

    public static Vector3 WithMagnitude(this Vector3 v, float magnitude)
    {
        return v.normalized * magnitude;
    }

    public static Vector3 WithX(this Vector3 v, float newX)
    {
        return new Vector3(newX, v.y, v.z);
    }

    public static Vector3 WithY(this Vector3 v, float newY)
    {
        return new Vector3(v.x, newY, v.z);
    }

    public static Vector3 WithZ(this Vector3 v, float newZ)
    {
        return new Vector3(v.x, v.y, newZ);
    }

    public static Vector2 AsVector2(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }
}
