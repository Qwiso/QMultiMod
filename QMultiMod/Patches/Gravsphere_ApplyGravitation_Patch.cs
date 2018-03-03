using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Gravsphere))]
    [HarmonyPatch("ApplyGravitation")]
    class Gravsphere_ApplyGravitation_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(15f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.GravsphereMaxForce);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
