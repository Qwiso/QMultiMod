using Harmony;
using UnityEngine;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(GrapplingHook))]
    [HarmonyPatch("OnCollisionEnter")]
    class GrapplingHook_OnCollisionEnter_Patch
    {
        public static void Postfix(GrapplingHook __instance, Collision collisionInfo)
        {
            var target = __instance.GetTargetRigidbody(collisionInfo.gameObject);
            if (target == null)
                return;

            var creature = target.GetComponent<Creature>();
            if (creature == null)
                return;
            
            var mixin = creature.GetComponent<LiveMixin>();
            if (mixin == null)
                return;

            if (QMultiModSettings.Instance.ExosuitGrapplingArmDamage != 0f) // to avoid potential event triggers
                mixin.TakeDamage(QMultiModSettings.Instance.ExosuitGrapplingArmDamage, creature.transform.position, DamageType.Collide, null);
        }
    }
}
