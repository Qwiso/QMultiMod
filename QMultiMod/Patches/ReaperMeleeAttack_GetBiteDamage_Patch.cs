using Harmony;
using UnityEngine;

namespace QMultiMod.Patches
{
    //[HarmonyPatch(typeof(ReaperMeleeAttack))]
    //[HarmonyPatch("GetBiteDamage")]
    //class ReaperMeleeAttack_GetBiteDamage_Patch
    //{
    //    public static bool Prefix(ReaperMeleeAttack __instance, float __result, GameObject target)
    //    {
    //        if (target.GetComponent<SubControl>() != null)
    //        {
    //            __result = __instance.cyclopsDamage / QMultiModSettings.CyclopsDamageFromReaperMeleeDivisor;
    //            return false;
    //        }

    //        return true;
    //    }
    //}
}
