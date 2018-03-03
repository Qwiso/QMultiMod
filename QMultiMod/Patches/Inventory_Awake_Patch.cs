using Harmony;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Inventory))]
    [HarmonyPatch("Awake")]
    class Inventory_Awake_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction.opcode.Equals(OpCodes.Ldc_I4_6))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_I4, QMultiModSettings.Instance.PlayerInventoryWidth);
                    continue;
                }

                if (instruction.opcode.Equals(OpCodes.Ldc_I4_8))
                {
                    yield return new CodeInstruction(OpCodes.Ldc_I4, QMultiModSettings.Instance.PlayerInventoryHeight);
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
