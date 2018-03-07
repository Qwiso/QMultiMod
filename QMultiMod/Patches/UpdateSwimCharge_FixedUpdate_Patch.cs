using Harmony;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(UpdateSwimCharge))]
    [HarmonyPatch("FixedUpdate")]
    class UpdateSwimCharge_FixedUpdate_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_R4) && (float)instruction.operand == 0.005f)
                {
                    yield return new CodeInstruction(OpCodes.Ldc_R4, QMultiModSettings.Instance.SwimChargeFinsModifier);
                    continue;
                }
                yield return instruction;
            }
        }
    }
}
