using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(VendingMachine))]
    [HarmonyPatch("OnUse")]
    class VendingMaching_OnUse_Patch
    {
        public static void Postfix()
        {
            if (QMultiModSettings.Instance.VendingMachineAlsoGivesCoffee)
                CraftData.AddToInventory(TechType.Coffee, 1, false, false);
        }
    }
}
