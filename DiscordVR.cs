using FrooxEngine;
using HarmonyLib;
using NeosModLoader;

namespace ShutTheFuckUp {
    public class DiscordVR : NeosMod {
        public override string Name => "DiscordVR";
        public override string Author => "Psychpsyo";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/Psychpsyo/DiscordVR";

        public override void OnEngineInit() {
            Harmony harmony = new Harmony("Psychpsyo.DiscordVR");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(UserspaceScreensManager))]
        class ActivateDiscord {
            [HarmonyPostfix]
            [HarmonyPatch("SetupDefaults")]
            [HarmonyPatch("OnLoading")]
            static void Postfix(UserspaceScreensManager __instance) {
                Slot discordScreenSlot = (Slot)typeof(UserspaceScreensManager).GetMethod("DiscordJoke", AccessTools.all).Invoke(__instance, new object[] { });
                discordScreenSlot.OrderOffset = 11;
            }
        }
    }
}
