using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace HPScaler
{
    public class Scaler : MelonMod
    {
        private MelonPreferences_Category? mainSettings;
        private MelonPreferences_Entry<float>? ChestSizeMin;
        private MelonPreferences_Entry<float>? ChestSizeMax;
        private MelonPreferences_Entry<float>? ButtSizeMin;
        private MelonPreferences_Entry<float>? ButtSizeMax;

        public override void OnInitializeMelon()
        {
            mainSettings = MelonPreferences.CreateCategory("Butt/Chest slider settings");

            ChestSizeMin = mainSettings.CreateEntry<float>("ChestSizeMin", 0.5f);
            ChestSizeMax = mainSettings.CreateEntry<float>("ChestSizeMax", 2f);
            ButtSizeMin = mainSettings.CreateEntry<float>("ButtSizeMin", 0.0f);
            ButtSizeMax = mainSettings.CreateEntry<float>("ButtSizeMax", 5f);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName != "MainMenu")
                return;

            var buttSlider = GameObject.FindObjectsOfType<GameObject>(true).First(p => p.name == "ButtSlider")!.GetComponentInChildren<Slider>();
            var chestSlider = GameObject.FindObjectsOfType<GameObject>(true).First(p => p.name == "ChestSlider").GetComponentInChildren<Slider>();
            buttSlider.minValue = ButtSizeMin!.Value;
            buttSlider.maxValue = ButtSizeMax!.Value;
            chestSlider.minValue = ChestSizeMin!.Value;
            chestSlider.maxValue = ChestSizeMax!.Value;
            MelonLogger.Msg($"Set new slider limits to [Chest: {ChestSizeMin.Value} <> {ChestSizeMax.Value}] and [Butt: {ButtSizeMin.Value} <> {ButtSizeMax.Value}]");
        }
    }
}
