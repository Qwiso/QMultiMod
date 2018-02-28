using System;
using Harmony;
using Oculus.Newtonsoft.Json;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(CoffeeVendingMachine))]
    [HarmonyPatch("OnMachineUse")]
    class CoffeeVendingMachine_OnMachineUse_Patch
    {
        public static bool Prefix(CoffeeVendingMachine __instance)
        {
            Console.WriteLine("[QMultiMod] CoffeeMachine Used");
            BasePowerRelay powerRelay = (BasePowerRelay)__instance.GetType().GetField("powerRelay", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(__instance);

            if (!(powerRelay == null))
            {
                PowerSystem.Status powerStatus = powerRelay.GetPowerStatus();

                switch (powerStatus)
                {
                    case PowerSystem.Status.Offline:
                        Console.WriteLine("[QMultiMod] Turning on the lights ...");
                        typeof(PowerRelay).GetField("enableElectonicsTime", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(powerRelay, 1f);
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
