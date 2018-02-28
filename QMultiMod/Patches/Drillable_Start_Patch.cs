using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Drillable))]
    [HarmonyPatch("Start")]
    class Drillable_Start_Patch
    {
        public static void Postfix(Drillable __instance)
        {
            __instance.minResourcesToSpawn = QMultiModSettings.MinDrillableAmount;
            __instance.maxResourcesToSpawn = QMultiModSettings.MaxDrillableAmount;
            __instance.kChanceToSpawnResources = QMultiModSettings.DrillableSpawnChanceMultiplier;
        }
    }
}
