using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(NitrogenLevel))]
    [HarmonyPatch("Start")]
    class NitrogenLevel_Start_Patch
    {
        public static void Postfix(NitrogenLevel __instance)
        {
            typeof(NitrogenLevel).GetField("nitrogenEnabled", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(__instance, QMultiModSettings.Instance.NitrogenEnabled);
        }
    }
}
