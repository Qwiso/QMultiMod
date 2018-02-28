using Harmony;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(SeaMoth))]
    [HarmonyPatch("OnUpgradeModuleChange")]
    class SeaMoth_OnUpgradeModuleChange_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(800f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.SeaMothReinforcementModuleDepth);
                    continue;
                }

                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(100f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.SeaMothHullMarkOneDepth);
                    continue;
                }

                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(300f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.SeaMothHullMarkTwoDepth);
                    continue;
                }


                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(700f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.SeaMothHullMarkThreeDepth);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
