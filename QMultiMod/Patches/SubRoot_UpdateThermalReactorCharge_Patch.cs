using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(SubRoot))]
    [HarmonyPatch("UpdateThermalReactorCharge")]
    class SubRoot_UpdateThermalReactorCharge_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(1.5f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.CyclopsThermalReactorEfficiency);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}