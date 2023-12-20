using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine.Device;
using UnityEngine.Rendering;

namespace HideJoinCode
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class HideJoinCodePlugin : BaseUnityPlugin
    {
        internal const string ModName = "HideJoinCode";
        internal const string ModVersion = "1.0.1";
        internal const string Author = "Azumatt";
        private const string ModGUID = Author + "." + ModName;
        public static readonly ManualLogSource HideJoinCodeLogger = BepInEx.Logging.Logger.CreateLogSource(ModName);

        private readonly Harmony _harmony = new(ModGUID);

        public void Awake()
        {
            if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null)
            {
                HideJoinCodeLogger.LogWarning($"{ModName} does not work in headless mode as it's a client only mod. {ModName} will not be loaded.");
                return;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            _harmony.PatchAll(assembly);
        }
    }
}