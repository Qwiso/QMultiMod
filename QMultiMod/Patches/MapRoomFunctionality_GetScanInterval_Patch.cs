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
            __result = Mathf.Max(QMultiModSettings.Instance.ScannerSpeedMinimumInterval, QMultiModSettings.Instance.ScannerSpeedNormalInterval - __instance.storageContainer.container.GetCount(TechType.MapRoomUpgradeScanSpeed) * QMultiModSettings.Instance.ScannerSpeedIntervalPerModule);
            return false;
        }
    }
}
