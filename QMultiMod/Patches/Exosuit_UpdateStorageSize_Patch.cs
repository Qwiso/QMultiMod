using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Exosuit))]
    [HarmonyPatch("UpdateStorageSize")]
    class Exosuit_UpdateStorageSize_Patch
    {
        public static bool Prefix(Exosuit __instance)
        {
            int width = QMultiModSettings.Instance.ExosuitStorageWidth;
            int height = QMultiModSettings.Instance.ExosuitStorageHeight;
            int numStorageModules = __instance.modules.GetCount(TechType.VehicleStorageModule);

            width += numStorageModules * QMultiModSettings.Instance.ExosuitWidthPerStorageModule;
            height += numStorageModules * QMultiModSettings.Instance.ExosuitHeightPerStorageModule;

            __instance.storageContainer.Resize(width, height);
            return false;
        }
    }
}
