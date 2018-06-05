using UnityEngine;
using UnityEngine.UI;

using UniRx;

namespace Manager.GameScene
{
    public class UIManager_PC : UIBehaviour
    {
        private Button settingsButton;
        private Canvas settingsCanvas;

        private Button surrenderButton;
        private Slider masterVolumeSlider;
        private Button applyButton;
        private Button applyAndCloseButton;


        private void Start()
        {
            FindObjects();
            SetOnclick();

            settingsCanvas.enabled = false;
        }

        private void FindObjects()
        {
            settingsButton = FindComponent<Button>("SettingsButton");
            settingsCanvas = FindComponent<Canvas>("SettingsCanvas");

            surrenderButton = FindComponent<Button>("SurrenderButton");
            masterVolumeSlider = FindComponent<Slider>("VolumeSlider");
            applyButton = FindComponent<Button>("ApplyButton");
            applyAndCloseButton = FindComponent<Button>("ApplyAndCloseButton");
    }
        
        private void SetOnclick()
        {
            settingsButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    OpenOrClose();
                });

            surrenderButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    throw new System.NotImplementedException();
                });

            applyButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    Apply();
                });

            applyAndCloseButton.onClick
                .AsObservable()
                .Subscribe((x) =>
                {
                    Apply();
                    OpenOrClose();
                });
        }

        private void OpenOrClose()
        {
            settingsCanvas.enabled = !settingsCanvas.enabled;
        }

        private void Apply()
        {
            // mastervolume 적용
            // todo
            masterVolumeSlider.value = 1;
            throw new System.NotImplementedException();
        }
    }
}