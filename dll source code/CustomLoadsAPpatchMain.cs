using HarmonyLib;
using CombatExtended;
using Verse;
using System.Linq;

namespace CustomLoadsAPBase
{
    [HarmonyPatch(typeof(CustomLoads.Bullet.CustomLoad))]
    [HarmonyPatch(nameof(CustomLoads.Bullet.CustomLoad.GenerateDefs))]
    public static class Patch_CustomLoad_GenerateDefs
    {
        static void Prefix(
            ref AmmoDef ammoTemplate,
            ref ThingDef bulletTemplate,
            bool register,
            CustomLoads.Bullet.CustomLoad __instance)
        {
            Log.Warning("[CustomLoadsAPBase] Patch applied... should be");

            if (ammoTemplate?.ammoClass?.defName != "FullMetalJacket")
                return;

            var ammoSet = ammoTemplate.AmmoSetDefs?.FirstOrDefault();
            if (ammoSet == null)
                return;

            var ap = ammoSet.ammoTypes
                .Select(x => x.ammo)
                .FirstOrDefault(a => a.ammoClass?.defName == "ArmorPiercing");

            if (ap == null)
                return;

            ammoTemplate = ap;
            bulletTemplate = ap.cookOffProjectile;

            Log.Warning($"[CustomLoadsAPBase] FMJ → AP ({ap.defName})");
        }
    }
}


