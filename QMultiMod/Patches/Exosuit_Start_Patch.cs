using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    [HarmonyPatch("Start")]
    class Exosuit_Start_Patch
    {
        public static void Postfix(Exosuit __instance)
        {
            __instance.GetType().GetField("thrustConsumption", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(__instance, QMultiModSettings.ExosuitThrustConsumption);
        }
    }
}
