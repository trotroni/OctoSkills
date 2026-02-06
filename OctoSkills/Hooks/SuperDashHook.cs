using UnityEngine;
using On;

namespace OctoSkills.Hooks
{
    public static class SuperDashHook
    {
        public static void Apply()
        {
            HeroController.SuperDash += HeroController_SuperDash;
        }

        private static void HeroController_SuperDash(HeroController.orig_SuperDash orig, HeroController self)
        {
            Vector2 dir = Core.DirectionHandler.GetDirection();

            if (dir != Vector2.zero)
            {
                float superDashSpeed = 30f; // Ajustable
                self.rb2d.velocity = dir * superDashSpeed;

                // Rotation du joueur vers la direction
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                self.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                orig(self);
            }
        }
    }
}