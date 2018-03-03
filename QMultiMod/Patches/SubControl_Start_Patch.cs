using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(SubControl))]
    [HarmonyPatch("Start")]
    class SubControl_Start_Patch
    {
        public static void Postfix(SubControl __instance)
        {
            __instance.BaseTurningTorque *= QMultiModSettings.Instance.CyclopsTurningTorqueMultiplier;
            __instance.BaseForwardAccel *= QMultiModSettings.Instance.CyclopsForwardAccelMultiplier;
            __instance.BaseVerticalAccel *= QMultiModSettings.Instance.CyclopsVerticalAccelMultiplier;
        }
    }
}
