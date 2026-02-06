using UnityEngine;
using On;

namespace OctoSkills.Hooks
{
    public static class FireballHook
    {
        public static void Apply()
        {
            PlayMakerFSM.On.PlayMakerFSM.OnEnable += OnFireballFSM;
        }

        private static void OnFireballFSM(PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            // Vérifie que c'est le FSM Fireball Cast
            if (self.FsmName == "Cast Vengeful Spirit" || self.FsmName == "Cast Shade Soul")
            {
                // On injecte un changement de direction sur le projectile
                self.GetAction<PlayMakerFSM>("Spawn Fireball", 0).FinishedEvent = "DIRECTION_OVERRIDE";
            }
        }

        public static Vector2 GetFireballVelocity(float speed)
        {
            Vector2 dir = Core.DirectionHandler.GetDirection();
            return dir != Vector2.zero ? dir * speed : Vector2.right * speed; // fallback
        }
    }
}