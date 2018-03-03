using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(SwimToMeat))]
    [HarmonyPatch("Start")]
    class SwimToMeat_Start_Patch
    {
        public static void Postfix(SwimToMeat __instance)
        {
            __instance.swimVelocity = QMultiModSettings.Instance.SwimToMeatVelocity;
        }
    }
}
