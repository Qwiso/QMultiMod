//using Harmony;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Reflection.Emit;

//namespace QMultiMod.Patches
//{
//    [HarmonyPatch(typeof(Player))]
//    [HarmonyPatch("OnTakeDamage")]
//    class Player_OnTakeDamage_Patch
//    {
//        public static readonly object target = typeof(LiveMixin).GetField("shielded", BindingFlags.Public | BindingFlags.Instance);

//        public static IEnumerable<CodeInstruction> Transpiler(ILGenerator generator, IEnumerable<CodeInstruction> instructions)
//        {
//            bool pointReached = false;
//            bool injected = false;

//            foreach (CodeInstruction instruction in instructions)
//            {
//                yield return instruction;

//                if (instruction.opcode.Equals(OpCodes.Ldfld) && instruction.operand.Equals(target) && !pointReached)
//                {
//                    pointReached = true;
//                }

//                if (instruction.opcode.Equals(OpCodes.Stloc_2) && pointReached && !injected)
//                {
//                    injected = true;
//                    Label notEqual = generator.DefineLabel();
//                    yield return new CodeInstruction(OpCodes.Ldarg_0);
//                    yield return new CodeInstruction(OpCodes.Ldfld, typeof(LiveMixin).GetField("player", BindingFlags.NonPublic | BindingFlags.Instance));
//                    yield return new CodeInstruction(OpCodes.Call, typeof(UnityEngine.Object).GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Instance));
//                    yield return new CodeInstruction(OpCodes.Brfalse_S, notEqual);
//                    yield return new CodeInstruction(OpCodes.Ldloc_2);
//                    yield return new CodeInstruction(OpCodes.Ldc_R4, 5f);
//                    yield return new CodeInstruction(OpCodes.Mul);
//                    yield return new CodeInstruction(OpCodes.Stloc_2);
//                    generator.MarkLabel(notEqual);
//                }
//            }
//        }
//    }
//}
