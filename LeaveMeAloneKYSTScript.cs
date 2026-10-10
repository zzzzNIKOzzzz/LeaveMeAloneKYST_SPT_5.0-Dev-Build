using EFT.Interactive;
using Il2CppInterop.Runtime.Attributes;
using UnityEngine;

namespace LeaveMeAloneKYST
{
    public class LeaveMeAloneKYSTScript : MonoBehaviour
    {
        private static readonly BepInEx.Logging.ManualLogSource Log =
            BepInEx.Logging.Logger.CreateLogSource("LeaveMeAloneKYST");

        [HideFromIl2Cpp]
        public static void ProcessObstacles()
        {
            var obstacles = Object.FindObjectsByType<ObstacleCollider>(FindObjectsSortMode.None);
            var swamps = Object.FindObjectsByType<BoxCollider>(FindObjectsSortMode.None);

            int bushes = 0;
            int swampsCount = 0;

            var disabled = !LeaveMeAloneKYSTConfig.Enabled.Value;

            // --- Кусты: ObstacleCollider по именам ---
            if (obstacles != null)
            {
                foreach (var obstacle in obstacles)
                {
                    if (obstacle == null) continue;

                    var parentName = obstacle.transform?.parent?.gameObject?.name?.ToLower();
                    var selfName = obstacle.transform?.name?.ToLower();

                    var parentMatch = parentName != null &&
                        (parentName.Contains("filbert") || parentName.Contains("fibert"));
                    var selfMatch = selfName != null &&
                        (selfName.Contains("filbert") || selfName.Contains("fibert") || selfName.Contains("swamp"));

                    if (parentMatch || selfMatch)
                    {
                        bushes++;
                        obstacle.SetEnabledUniversal(disabled);
                        if (selfMatch)
                        {
                            obstacle.gameObject.SetActive(disabled);
                        }
                    }
                }
            }

            // --- Болота: BoxCollider с именем "Swamp_collider" ---
            if (swamps != null)
            {
                foreach (var swamp in swamps)
                {
                    if (swamp == null) continue;
                    if (swamp.name != "Swamp_collider") continue;

                    swampsCount++;
                    swamp.SetEnabledUniversal(disabled);
                }
            }

            Log.LogInfo($"[LeaveMeAloneKYST] Кустов: {bushes}, Болот: {swampsCount}");
        }
    }
}