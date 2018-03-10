using Harmony;
using QMultiMod.CustomClasses;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(FireExtinguisherHolder))]
    [HarmonyPatch("Start")]
    class FireExtinguisherHolder_Start_Patch
    {
        public static void Postfix(FireExtinguisherHolder __instance)
        {
            __instance.gameObject.AddComponent<FireExtinguisherCharger>();
        }
    }
}
