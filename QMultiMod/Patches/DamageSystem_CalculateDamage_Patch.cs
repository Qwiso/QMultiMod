using Harmony;
using UnityEngine;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(DamageSystem))]
    [HarmonyPatch("CalculateDamage")]
    class DamageSystem_CalculateDamage_Patch
    {
        public static void Postfix(float __result, GameObject target, GameObject dealer)
        {
            if (target.GetComponent<Player>() != null)
            {
                if (QMultiModSettings.Instance.PlayerAvoidDamageMultiplier)
                    return;

                var newDamage = __result * QMultiModSettings.Instance.PlayerDamageTakenMultiplier;
                __result = newDamage;
            }
            else
            {
                if (target.GetComponent<Vehicle>() != null && QMultiModSettings.Instance.PlayerVehicleAvoidDamageMultiplier)
                {
                    var newDamage = __result * QMultiModSettings.Instance.VehicleDamageTakenMultiplier;
                    __result = newDamage;
                }

                if (target.GetComponent<SubRoot>() != null && QMultiModSettings.Instance.PlayerSubAvoidDamageMultiplier)
                {
                    var newDamage = __result * QMultiModSettings.Instance.SubDamageTakenMultiplier;
                    __result = newDamage;
                }

                if (target.GetComponent<BaseRoot>() != null)
                {
                    System.Console.WriteLine("[QMultiMod] target has a BaseRoot, cool!");
                }
            }
        }
    }
}
