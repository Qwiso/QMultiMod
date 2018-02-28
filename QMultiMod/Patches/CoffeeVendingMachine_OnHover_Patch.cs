using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(CoffeeVendingMachine))]
    [HarmonyPatch("OnHover")]
    class CoffeeVendingMachine_OnHover_Patch
    {
        public static bool Prefix(CoffeeVendingMachine __instance)
        {
            HandReticle.main.SetInteractText(__instance.hoverText);
            HandReticle.main.SetIcon(HandReticle.IconType.Interact, 1f);
            return false;
        }
    }
}
