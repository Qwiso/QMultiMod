using Harmony;
using System.Reflection;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(DevConsole))]
    [HarmonyPatch("HasUsedConsole")]
    class DevConsole_HasUsedConsole_Patch
    {
        public static bool Prefix(ref bool __result)
        {
            __result = QMultiModSettings.Instance.AllowAchievements;
            return false;
        }
    }
}
