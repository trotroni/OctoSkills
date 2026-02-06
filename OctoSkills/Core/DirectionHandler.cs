// Gestion 8-way
using UnityEngine;

namespace OctoSkills.Core
{
    public static class DirectionHandler
    {
        // Retourne le vecteur directionnel 8-way
        public static Vector2 GetDirection()
        {
            float x = 0f;
            float y = 0f;

            if (HeroActions.left.IsPressed)  x -= 1f;
            if (HeroActions.right.IsPressed) x += 1f;
            if (HeroActions.up.IsPressed)    y += 1f;
            if (HeroActions.down.IsPressed)  y -= 1f;

            Vector2 dir = new Vector2(x, y);
            return dir.sqrMagnitude > 0 ? dir.normalized : Vector2.zero;
        }
    }
}
