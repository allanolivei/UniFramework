using UnityEngine;

public static class VectorExtensions
{
    /// <summary>
    /// Returns the direction from this Vector3 to another Vector3 (target)
    /// </summary>
    /// <param name="from"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Vector3 DirectionTo(this Vector3 from, Vector3 target)
    {
        return target - from;
    }

    /// <summary>
    /// Returns this Vector3 with the given magnitude
    /// </summary>
    /// <param name="v"></param>
    /// <param name="magnitude"></param>
    /// <returns></returns>
    public static Vector3 WithMagnitude(this Vector3 v, float magnitude)
    {
        return v.normalized * magnitude;
    }

    /// <summary>
    /// Returns this Vector3 with the given X value
    /// </summary>
    /// <param name="v"></param>
    /// <param name="newX"></param>
    /// <returns></returns>
    public static Vector3 WithX(this Vector3 v, float newX)
    {
        return new Vector3(newX, v.y, v.z);
    }

    /// <summary>
    /// Returns this Vector3 with the given Y value
    /// </summary>
    /// <param name="v"></param>
    /// <param name="newY"></param>
    /// <returns></returns>
    public static Vector3 WithY(this Vector3 v, float newY)
    {
        return new Vector3(v.x, newY, v.z);
    }

    /// <summary>
    /// Returns this Vector3 with the given Z value
    /// </summary>
    /// <param name="v"></param>
    /// <param name="newZ"></param>
    /// <returns></returns>
    public static Vector3 WithZ(this Vector3 v, float newZ)
    {
        return new Vector3(v.x, v.y, newZ);
    }

    /// <summary>
    /// Returns this Vector3 converted into a Vector2 (ignoring the Z axis)
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vector2 AsVector2(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }
}
