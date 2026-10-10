using EFT;
using HarmonyLib;

namespace LeaveMeAloneKYST
{
    [HarmonyPatch(typeof(GameWorld), nameof(GameWorld.OnGameStarted))]
    internal static class GameWorldOnGameStartedPatch
    {
        [HarmonyPostfix]
        private static void Postfix()
        {
            BepInEx.Logging.Logger
                .CreateLogSource("LeaveMeAloneKYST")
                .LogInfo("[LeaveMeAloneKYST] GameWorld.OnGameStarted — обрабатываю кусты и болота.");

            LeaveMeAloneKYSTScript.ProcessObstacles();
        }
    }
}