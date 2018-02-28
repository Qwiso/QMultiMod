using Harmony;
using System.Reflection;

namespace QMultiMod
{
    class QPatch
    {
        public static void Patch()
        {
            HarmonyInstance harmony = HarmonyInstance.Create("qmultimod.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
