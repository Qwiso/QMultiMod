using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Harmony;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Awake")]
    class Player_Awake_Patch
    {
        private static readonly MethodInfo UnlockItems =
            typeof(SteamEconomy).GetMethod("UnlockItems", BindingFlags.Instance | BindingFlags.NonPublic);
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            var ret = codes[codes.Count - 1];
            codes.Remove(ret);
            codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
            codes.Add(new CodeInstruction(OpCodes.Call, UnlockItems));
            codes.Add(ret);
            return codes.AsEnumerable();
        }
    }
}