using Harmony;
using UnityEngine;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(MapRoomFunctionality))]
    [HarmonyPatch("GetScanInterval")]
    class MapRoomFunctionality_GetScanInterval_Patch
    {
        public static bool Prefix(MapRoomFunctionality __instance, ref float __result)
        {
            __result = Mathf.Max(QMultiModSettings.Instance.ScannerMinInterval,
                QMultiModSettings.Instance.ScannerMaxInterval -
                __instance.storageContainer.container.GetCount(TechType.MapRoomUpgradeScanSpeed) *
                QMultiModSettings.Instance.ScannerExtraInterval);
            return false;
        }
    }
}
