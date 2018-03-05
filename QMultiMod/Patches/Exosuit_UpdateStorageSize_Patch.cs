using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    [HarmonyPatch("UpdateStorageSize")]
    class Exosuit_UpdateStorageSize_Patch
    {
        public static bool Prefix(Exosuit __instance)
        {
            int count = __instance.modules.GetCount(TechType.VehicleStorageModule);

            int width = QMultiModSettings.Instance.ExosuitBaseWidth + 
                        count * QMultiModSettings.Instance.ExosuitWidthPerModule;

            int height = QMultiModSettings.Instance.ExosuitBaseHeight +
                         count * QMultiModSettings.Instance.ExosuitHeightPerModule;

            __instance.storageContainer.Resize(width, height);
            return false;
        }
    }
}
