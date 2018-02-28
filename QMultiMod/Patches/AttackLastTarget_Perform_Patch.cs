using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(AttackLastTarget))]
    [HarmonyPatch("Perform")]
    class AttackLastTarget_Perform_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                bool injected = false;

                if (instruction.opcode.Equals(OpCodes.Ldfld) && instruction.operand.Equals("float32 AttackLastTarget::swimVelocity") && !injected)
                {
                    injected = true;
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.AttackLastTargetSwimVelocity);
                    yield return new CodeInstruction(OpCodes.Mul);
                }

                yield return instruction;
            }
        }
    }
}
