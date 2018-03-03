using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(uGUI_CameraDrone))]
    [HarmonyPatch("LateUpdate")]
    class uGUI_CameraDrone_LateUpdate_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4))
                {
                    if (instruction.operand.Equals(250f))
                    {
                        yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.ScannerCameraRange);
                        continue;
                    }

                    if (instruction.operand.Equals(520f))
                    {
                        yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.ScannerCameraRange * 2.05f);
                        continue;
                    }
                }

                yield return instruction;
            }
        }
    }
}
