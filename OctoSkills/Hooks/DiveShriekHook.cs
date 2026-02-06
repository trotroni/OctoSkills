using UnityEngine;
using On;

namespace OctoSkills.Hooks
{
    public static class DiveShriekHook
    {
        public static void Apply()
        {
            PlayMakerFSM.On.PlayMakerFSM.OnEnable += OnDiveShriekFSM;
        }

        private static void OnDiveShriekFSM(PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            // Dive
            if (self.FsmName == "Desolate Dive" || self.FsmName == "Descending Dark")
            {
                self.GetAction<PlayMakerFSM>("Start Dive", 0).FinishedEvent = "DIRECTION_OVERRIDE";
            }

            // Shriek
            if (self.FsmName == "Howling Wraiths" || self.FsmName == "Abyss Shriek")
            {
                Vector2 dir = Core.DirectionHandler.GetDirection();
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                self.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}