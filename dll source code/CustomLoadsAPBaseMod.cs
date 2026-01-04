using HarmonyLib;
using Verse;

namespace CustomLoadsAPBase
{
    public class CustomLoadsAPBaseMod : Mod
    {
        public CustomLoadsAPBaseMod(ModContentPack content)
            : base(content)
        {
            Log.Warning("[CustomLoadsAPBase] Mod constructor");

            var harmony = new Harmony("gmm89m.customloads.apbase");
            harmony.PatchAll();

            Log.Warning("[CustomLoadsAPBase] Harmony pwned (patched)");
        }
    }
}
