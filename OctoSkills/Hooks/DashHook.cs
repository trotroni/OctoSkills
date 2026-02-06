using UnityEngine;
using On;

namespace OctoSkills.Hooks
{
    public static class DashHook
    {
        public static void Apply()
        {
            HeroController.Dash += HeroController_Dash;
        }

        private static void HeroController_Dash(HeroController.orig_Dash orig, HeroController self)
        {
            Vector2 dir = Core.DirectionHandler.GetDirection();

            // Si vecteur non nul, on applique la direction 8-way
            if (dir != Vector2.zero)
            {
                float dashSpeed = 20f; // tu peux ajuster selon ton besoin
                self.rb2d.velocity = dir * dashSpeed;
            }
            else
            {
                // fallback sur le dash vanilla
                orig(self);
            }
        }
    }
}