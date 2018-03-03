using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Vehicle))]
    [HarmonyPatch("ApplyPhysicsMove")]
    class Vehicle_ApplyPhysicsMove_Patch
    {
        public static readonly object target = typeof(Vehicle).GetField("forwardForce", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool injected = false;

            foreach (var instruction in instructions)
            {
                yield return instruction;

                if (instruction.opcode.Equals(OpCodes.Ldfld) && instruction.operand.Equals(target) && !injected)
                {
                    injected = true;
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.VehicleForwardForceMultiplier);
                    yield return new CodeInstruction(OpCodes.Mul);
                }
            }
        }
    }
}
