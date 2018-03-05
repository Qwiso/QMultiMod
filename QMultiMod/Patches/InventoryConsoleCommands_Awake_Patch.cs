using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(InventoryConsoleCommands))]
    [HarmonyPatch("Awake")]
    class InventoryConsoleCommands_Awake_Patch
    {
        public static void Postfix(InventoryConsoleCommands __instance)
        {
            DevConsole.RegisterConsoleCommand(__instance, "resizestorage"); ;
        }
    }
}
