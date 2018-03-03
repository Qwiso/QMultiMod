using Harmony;
using System.Reflection;

namespace QMultiMod
{
    class QPatch
    {
        public static void Patch()
        {
            QMultiModSettings.Load();

            HarmonyInstance harmony = HarmonyInstance.Create("qmultimod.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
