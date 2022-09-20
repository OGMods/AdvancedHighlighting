using HarmonyLib;
using QModManager.API.ModLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedHighlighting
{
    [QModCore]
    public static class HighlightingMod
    {
        [QModPatch]
        public static void InitMod()
        {
            Console.WriteLine("[AdvancedHighlighting] Start Patching...");
            Harmony harmony = new Harmony("net.ogmods.highlighting");
            harmony.PatchAll();
        }
    }
}
