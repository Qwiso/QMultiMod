using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(DevConsole))]
    [HarmonyPatch("HasUsedConsole")]
    class DevConsole_HasUsedConsole_Patch
    {
        public static bool Prefix(ref bool __result)
        {
            if (QMultiModSettings.Instance.AllowAchievementsWithConsole)
            {
                __result = true;
                return false;
            }

            return true;
        }
    }
}
