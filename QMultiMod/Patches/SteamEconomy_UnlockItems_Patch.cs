using Harmony;
using System.Reflection;

namespace QMultiMod.Patches
{
    [HarmonyPatch(typeof(SteamEconomy))]
    [HarmonyPatch("UnlockItems")]
    class SteamEconomy_UnlockItems_Patch
    {
        public static bool Prefix(SteamEconomy __instance)
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
            return false;
        }
    }
}
