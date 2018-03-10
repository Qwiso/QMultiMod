using Harmony;
using UnityEngine;

namespace QMultiMod.CustomClasses
{
    class FireExtinguisherCharger : MonoBehaviour
    {
        private FireExtinguisherHolder holder;

        void Start()
        {
            holder = GetComponent<FireExtinguisherHolder>();
        }

        void FixedUpdate()
        {
            if (holder == null || !holder.hasTank)
                return;
            if (holder.fuel < 100)
                holder.fuel += QMultiModSettings.Instance.ExtinguisherCharge;
            else
                holder.fuel = 100f;
        }
    }
}
