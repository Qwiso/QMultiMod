using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Drillable))]
    [HarmonyPatch("Start")]
    class Drillable_Start_Patch
    {
        public static void Postfix(Drillable __instance)
        {
            __instance.minResourcesToSpawn = QMultiModSettings.Instance.MinDrillableAmount;
            __instance.maxResourcesToSpawn = QMultiModSettings.Instance.MaxDrillableAmount;
            __instance.kChanceToSpawnResources = QMultiModSettings.Instance.DrillableSpawnChanceMultiplier;
        }
    }
}
