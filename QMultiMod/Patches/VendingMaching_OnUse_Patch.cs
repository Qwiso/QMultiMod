using Harmony;
using System.Reflection;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(VendingMachine))]
    [HarmonyPatch("OnUse")]
    class VendingMaching_OnUse_Patch
    {
        private static readonly MethodInfo CanBeUsed = typeof(VendingMachine).GetMethod("GetCanBeUsed", BindingFlags.NonPublic | BindingFlags.Instance);

        public static void Prefix(VendingMachine __instance)
        {
            if (QMultiModSettings.Instance.VendingMachineAlsoGivesCoffee)
            {
                var canBeUsed = (bool)CanBeUsed.Invoke(__instance, null);
                if (canBeUsed)
                    CraftData.AddToInventory(TechType.Coffee, 1, false, false);
            }
        }
    }
}
