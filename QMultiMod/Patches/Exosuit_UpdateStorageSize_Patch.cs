using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    [HarmonyPatch("UpdateStorageSize")]
    class Exosuit_UpdateStorageSize_Patch
    {
        public static bool Prefix(Exosuit __instance)
        {
            int width = 6;
            int height = 4;

            if (__instance.modules.GetCount(TechType.VehicleStorageModule) >= 1)
            {
                width = 7;
                height = 7;
            }

            __instance.storageContainer.Resize(width, height);
            return false;
        }
    }
}
