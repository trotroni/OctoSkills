// Extensions utiles sur Vector2
using UnityEngine;

namespace OctoSkills.Utils
{
    public static class VectorExtensions
    {
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float rad = degrees * Mathf.Deg2Rad;
            float sin = Mathf.Sin(rad);
            float cos = Mathf.Cos(rad);

            float x = v.x * cos - v.y * sin;
            float y = v.x * sin + v.y * cos;
            return new Vector2(x, y);
        }
    }
}
