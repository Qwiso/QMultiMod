using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Gravsphere))]
    [HarmonyPatch("OnTriggerEnter")]
    class Gravsphere_OnTriggerEnter_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool injected = false;

            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_I4) && instruction.operand.Equals(12) && !injected)
                {
                    injected = true;
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.GravsphereMaxTrapped);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
