using UnityEngine;
static class Border
{
    static Vector3 minBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 7.05f));
    static Vector3 maxBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 7.05f));
    public static Vector3 minPos = new Vector3(minBorder.x + 0.5f, minBorder.y, minBorder.z + 0.5f);
    public static Vector3 maxPos = new Vector3(maxBorder.x - 0.5f, maxBorder.y, maxBorder.z - 0.5f);
}
