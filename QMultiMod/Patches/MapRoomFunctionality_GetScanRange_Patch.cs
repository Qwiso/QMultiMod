using Harmony;
using UnityEngine;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(MapRoomFunctionality))]
    [HarmonyPatch("GetScanRange")]
    class MapRoomFunctionality_GetScanRange_Patch
    {
        public static bool Prefix(MapRoomFunctionality __instance, ref float __result)
        {
            __result = Mathf.Min(QMultiModSettings.Instance.ScannerBlipRange,
                QMultiModSettings.Instance.ScannerMinRange +
                (float) __instance.storageContainer.container.GetCount(TechType.MapRoomUpgradeScanRange) *
                QMultiModSettings.Instance.ScannerUpgradeAddedRange);
            return false;
        }
    }
}
