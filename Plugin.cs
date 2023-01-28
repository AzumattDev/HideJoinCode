using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace HideJoinCode
{
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class HideJoinCodePlugin : BaseUnityPlugin
    {
        internal const string ModName = "HideJoinCode";
        internal const string ModVersion = "1.0.0";
        internal const string Author = "Azumatt";
        private const string ModGUID = Author + "." + ModName;

        private readonly Harmony _harmony = new(ModGUID);

        public void Awake()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            _harmony.PatchAll(assembly);
        }
    }
}