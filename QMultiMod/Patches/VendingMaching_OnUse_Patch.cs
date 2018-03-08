using Harmony;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(VendingMachine))]
    [HarmonyPatch("OnUse")]
    class VendingMaching_OnUse_Patch
    {
        //public static void Postfix(VendingMachine __instance)
        //{
        //    if (QMultiModSettings.Instance.VendingMachineAlsoGivesCoffee)
        //        CraftData.AddToInventory(TechType.Coffee, 1, false, false);
        //}
        private static readonly MethodInfo AddToInventory =
            typeof(CraftData).GetMethod("AddToInventory",BindingFlags.Public | BindingFlags.Static);
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool founded = false;
            foreach (var instruction in instructions)
            {
                if (founded)
                {
                    yield return new CodeInstruction(OpCodes.Ldc_I4,(int)TechType.Coffee);
                    yield return new CodeInstruction(OpCodes.Ldc_I4_1);
                    yield return new CodeInstruction(OpCodes.Ldc_I4_0);
                    yield return new CodeInstruction(OpCodes.Ldc_I4_0);
                    yield return new CodeInstruction(OpCodes.Call, AddToInventory);
                    yield return new CodeInstruction(OpCodes.Pop);
                    founded = false;
                }
                if (instruction.opcode.Equals(OpCodes.Pop))
                {
                    founded = true;
                }
                yield return instruction;
            }
        }
    }
}
