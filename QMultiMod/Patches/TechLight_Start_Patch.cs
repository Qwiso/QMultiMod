using Harmony;
using System.Reflection;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(TechLight))]
    [HarmonyPatch("Start")]
    class TechLight_STart_Patch
    {
        public static void Prefix(TechLight __instance)
        {
            typeof(TechLight).GetField("powerPerSecond", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).SetValue(__instance, QMultiModSettings.Instance.SpotlightPowerPerSecond);
            typeof(TechLight).GetField("updateInterval", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).SetValue(__instance, QMultiModSettings.Instance.SpotlightUpdateInterval);
        }
    }
}
