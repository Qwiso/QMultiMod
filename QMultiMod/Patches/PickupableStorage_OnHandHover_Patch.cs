using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(PickupableStorage))]
    [HarmonyPatch("OnHandHover")]
    class PickupableStorage_OnHandHover_Patch
    {
        public static bool Prefix(PickupableStorage __instance, GUIHand hand)
        {
            if (QMultiModSettings.Instance.StorageContainersStack)
            {
                __instance.pickupable.OnHandHover(hand);
                return false;
            }

            return true;
        }
    }
}