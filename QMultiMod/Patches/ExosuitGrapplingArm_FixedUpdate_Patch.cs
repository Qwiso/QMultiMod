using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(ExosuitGrapplingArm))]
    [HarmonyPatch("FixedUpdate")]
    class ExosuitGrapplingArm_FixedUpdate_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool injected = false;

            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(35f) && !injected)
                {
                    injected = true;
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.ExosuitGrapplingArmRange);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
