using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(DayNightCycle))]
    [HarmonyPatch("deltaTime", PropertyMethod.Getter)]
    class DayNightCycle_Update_Patch
    {
        public static bool Prefix(ref DayNightCycle __instance, ref float __result)
        {
            __result = UnityEngine.Time.deltaTime * QMultiModSettings.Instance.DayNightSpeed;
            return false;
        }
    }
}
