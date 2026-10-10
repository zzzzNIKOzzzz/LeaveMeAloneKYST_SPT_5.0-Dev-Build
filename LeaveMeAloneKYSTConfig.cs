using BepInEx.Configuration;

namespace LeaveMeAloneKYST
{
    internal static class LeaveMeAloneKYSTConfig
    {
        internal static ConfigEntry<bool> Enabled;

        internal static void Init(ConfigFile config)
        {
            Enabled = config.Bind(
                "Общие",
                "Включено",
                true,
                "Отключает замедление от кустов и болот.");
        }
    }
}