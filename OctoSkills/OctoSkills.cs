// Entrée du mod
using UnityEngine;
using Satchel;

namespace OctoSkills
{
    public class OctoSkills : Mod
    {
        public override void Initialize()
        {
            Log("OctoSkills Loaded!");
            Hooks.DashHook.Apply();
        }

        public override void Update()
        {
            // Juste pour tester le vecteur directionnel
            Vector2 dir = Core.DirectionHandler.GetDirection();
            if (dir != Vector2.zero)
                Log($"Direction: {dir}");
        }
    }
}
