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
        private static readonly MethodInfo UnlockItems = typeof(SteamEconomy).GetMethod("UnlockItems", BindingFlags.Instance | BindingFlags.NonPublic);

        public static void Postfix()
        {
            if (QMultiModSettings.Instance.UnlockHullPlates)
            {
                KnownTech.Add(TechType.SpecialHullPlate, false);
                KnownTech.Add(TechType.DevTestItem, false);
                KnownTech.Add(TechType.BikemanHullPlate, false);
                KnownTech.Add(TechType.EatMyDictionHullPlate, false);
                KnownTech.Add(TechType.DioramaHullPlate, false);
                KnownTech.Add(TechType.MarkiplierHullPlate, false);
                KnownTech.Add(TechType.MuyskermHullPlate, false);
                KnownTech.Add(TechType.LordMinionHullPlate, false);
                KnownTech.Add(TechType.JackSepticEyeHullPlate, false);
                KnownTech.Add(TechType.IGPHullPlate, false);
                KnownTech.Add(TechType.GilathissHullPlate, false);
                KnownTech.Add(TechType.Marki1, false);
                KnownTech.Add(TechType.Marki2, false);
                KnownTech.Add(TechType.JackSepticEye, false);
            }
        }
    }
}