using Harmony;
using System.Reflection;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(BaseSpotLight))]
    [HarmonyPatch("Start")]
    class BaseSpotLight_Start_Patch
    {
        public static void Prefix(BaseSpotLight __instance)
        {
            typeof(BaseSpotLight).GetField("powerPerSecond", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).SetValue(__instance, QMultiModSettings.Instance.SpotlightPowerPerSecond);
            typeof(BaseSpotLight).GetField("updateInterval", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).SetValue(__instance, QMultiModSettings.Instance.SpotlightUpdateInterval);
        }
    }
}
