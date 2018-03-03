using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(VFXGrapplingRope))]
    [HarmonyPatch("Start")]
    class VFXGrapplingRope_Start_Patch
    {
        public static void Postfix(VFXGrapplingRope __instance)
        {
            __instance.GetType().GetField("maxDistance", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(__instance, QMultiModSettings.Instance.ExosuitGrapplingArmRange);
        }
    }
}
