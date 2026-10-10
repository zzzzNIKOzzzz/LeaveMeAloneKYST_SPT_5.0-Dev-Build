using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;

namespace LeaveMeAloneKYST
{
    [BepInPlugin("com.zzzNIKOzzz.leavemealonekyst", "LeaveMeAloneKYST", "1.0.0")]
    public class LeaveMeAloneKYSTPlugin : BasePlugin
    {
        internal static LeaveMeAloneKYSTPlugin Instance;
        internal static ConfigFile ConfigRef;

        public override void Load()
        {
            Instance = this;
            ConfigRef = Config;

            Log.LogInfo("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
            Log.LogInfo("LeaveMeAloneKYST by zzzNIKOzzz загружается... ... ... ... ...");
            Log.LogInfo("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");

            LeaveMeAloneKYSTConfig.Init(Config);

            // Регистрируем MonoBehaviour в IL2CPP-домене и создаём компонент.
            ClassInjector.RegisterTypeInIl2Cpp<LeaveMeAloneKYSTScript>();
            AddComponent<LeaveMeAloneKYSTScript>();

            // Патчим GameWorld.OnGameStarted постфиксом.
            var harmony = new Harmony("com.hazelify.leavemealonekyst");
            harmony.PatchAll(typeof(GameWorldOnGameStartedPatch).Assembly);

            Log.LogInfo("LeaveMeAloneKYST: патч GameWorld.OnGameStarted применён. ЧТД!");
            Log.LogInfo("zzzNIKOzzz: Кусты и болота идут нахуй! Я - СКОРОСТЬ.....Кчау!");
            Log.LogInfo("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz");
        }
    }
}