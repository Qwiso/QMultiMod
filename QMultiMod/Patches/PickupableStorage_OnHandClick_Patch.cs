using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(PickupableStorage))]
    [HarmonyPatch("OnHandClick")]
    class PickupableStorage_OnHandClick_Patch
    {
        public static bool Prefix(PickupableStorage __instance, GUIHand hand)
        {
            if (QMultiModSettings.StorageContainersStack)
            {
                __instance.pickupable.OnHandClick(hand);
                return false;
            }

            return true;
        }
    }
}
