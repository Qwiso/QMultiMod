using System;
using System.Reflection;
using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(CoffeeVendingMachine))]
    [HarmonyPatch("OnMachineUse")]
    class CoffeeVendingMachine_OnMachineUse_Patch
    {
        private static readonly FieldInfo _powerRelay =
            typeof(CoffeeVendingMachine).GetField("powerRelay",BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo _enableElectonicsTime =
            typeof(PowerRelay).GetField("enableElectonicsTime",BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool Prefix(CoffeeVendingMachine __instance)
        {
            Console.WriteLine("[QMultiMod] CoffeeMachine Used");
            BasePowerRelay powerRelay = (BasePowerRelay)_powerRelay.GetValue(__instance);

            if (powerRelay != null)
            {
                PowerSystem.Status powerStatus = powerRelay.GetPowerStatus();

                switch (powerStatus)
                {
                    case PowerSystem.Status.Offline:
                        Console.WriteLine("[QMultiMod] Turning on the lights ...");
                        _enableElectonicsTime.SetValue(powerRelay, 1f);
                        break;
                    case PowerSystem.Status.Normal:
                        Console.WriteLine("[QMultiMod] Turning off the lights ...");
                        powerRelay.DisableElectronicsForTime(9999999f);
                        break;
                }
            }

            return false;
        }
    }
}
