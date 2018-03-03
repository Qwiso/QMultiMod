using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(uGUI_ResourceTracker))]
    [HarmonyPatch("GatherScanned")]
    class uGUI_ResourceTracker_GatherScanned_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && instruction.operand.Equals(500f))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.ScannerBlipRange);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
