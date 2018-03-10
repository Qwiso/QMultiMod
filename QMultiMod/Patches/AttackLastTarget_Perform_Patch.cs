using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(AttackLastTarget))]
    [HarmonyPatch("Perform")]
    class AttackLastTarget_Perform_Patch
    {
        public static readonly object TARGET_FIELD = typeof(AttackLastTarget).GetField("swimVelocity");

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                bool injected = false;

                if (instruction.opcode.Equals(OpCodes.Ldfld) && instruction.operand.Equals(TARGET_FIELD) && !injected)
                {
                    injected = true;
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.AttackLastTargetSwimVelocity);
                    yield return new CodeInstruction(OpCodes.Mul);
                }

                yield return instruction;
            }
        }
    }
}
