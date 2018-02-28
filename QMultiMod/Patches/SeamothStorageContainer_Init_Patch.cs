using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(SeamothStorageContainer))]
    [HarmonyPatch("Init")]
    class SeamothStorageContainer_Init_Patch
    {
        public static void Postfix(SeamothStorageContainer __instance)
        {
            __instance.container.Resize(QMultiModSettings.SeamothStorageContainerWidth, QMultiModSettings.SeamothStorageContainerHeight);
        }
    }
}
