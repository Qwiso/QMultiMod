//using System.Reflection;
//using Harmony;

//namespace QMultiMod.Patches
//{
//    [HarmonyPatch(typeof(CoffeeVendingMachine))]
//    [HarmonyPatch("OnMachineUse")]
//    class CoffeeVendingMachine_OnMachineUse_Patch
//    {
//        private static readonly FieldInfo _powerRelay =
//            typeof(CoffeeVendingMachine).GetField("powerRelay",BindingFlags.NonPublic | BindingFlags.Instance);

//        private static readonly FieldInfo _enableElectonicsTime =
//            typeof(PowerRelay).GetField("enableElectonicsTime",BindingFlags.NonPublic | BindingFlags.Instance);

//        public static bool Prefix(CoffeeVendingMachine __instance)
//        {
//            BasePowerRelay powerRelay = (BasePowerRelay)_powerRelay.GetValue(__instance);

//            if (powerRelay != null)
//            {
//                PowerSystem.Status powerStatus = powerRelay.GetPowerStatus();

//                switch (powerStatus)
//                {
//                    case PowerSystem.Status.Offline:
//                        _enableElectonicsTime.SetValue(powerRelay, 1f);
//                        break;
//                    case PowerSystem.Status.Normal:
//                        powerRelay.DisableElectronicsForTime(9999999f);
//                        break;
//                }
//            }

//            return false;
//        }
//    }
//}
