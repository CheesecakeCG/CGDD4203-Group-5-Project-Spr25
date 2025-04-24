using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class OtherGraphicsSettings : MonoBehaviour
{


    public UIDocument ui;
    public UIDocument hudUI;
    public Toggle postProcessingToggle;
    public Toggle hdrToggle;
    public DropdownField targetFPSField;
    static OtherGraphicsSettings current;
    // void OnEnable()
    // {
    //     if (current == null)
    //     {
    //         OtherGraphicsSettings.current = this;
    //         DontDestroyOnLoad(gameObject);
    //         hudUI.rootVisualElement.Q<Button>("SettingsButton").clicked += () =>
    //         {
    //             ShowSettingsUI();
    //             RefreshUIValues();
    //         };
    //         return;
    //     }
    //     if (current != this)
    //     {
    //         current.hudUI = hudUI;
    //         // ui = current.ui;

    //         Destroy(current.gameObject);
    //     }
    // }
    void Start()
    {

        HideSettingsUI();

        hudUI.rootVisualElement.Q<Button>("SettingsButton").clicked += () =>
        {
            ShowSettingsUI();
            RefreshUIValues();
        };

        ui.rootVisualElement.Q<Button>("BackButton").clicked += () =>
        {
            HideSettingsUI();
        };

        targetFPSField = ui.rootVisualElement.Q<DropdownField>("FPSTarget");
        targetFPSField.RegisterValueChangedCallback((evt) =>
        {
            ApplyFPSTargetValue();
        });

        hdrToggle = ui.rootVisualElement.Q<Toggle>("HDRToggle");
        hdrToggle.RegisterValueChangedCallback((evt) =>
        {
            ApplyHDRModeValue();
        });

        postProcessingToggle = ui.rootVisualElement.Q<Toggle>("PostProcessingToggle");
        postProcessingToggle.RegisterValueChangedCallback((evt) =>
        {
            ApplyPostProcessingValue();
        });


        ApplyFPSTargetValue();
        ApplyHDRModeValue();
        ApplyPostProcessingValue();
    }

    private void ShowSettingsUI()
    {
        ui.rootVisualElement.pickingMode = PickingMode.Position;
        ui.rootVisualElement.style.visibility = Visibility.Visible;
    }

    private void HideSettingsUI()
    {
        ui.rootVisualElement.pickingMode = PickingMode.Ignore;
        ui.rootVisualElement.style.visibility = Visibility.Hidden;
    }

    private void ApplyPostProcessingValue()
    {
        Camera.main.GetUniversalAdditionalCameraData().renderPostProcessing = postProcessingToggle.value;
    }

    private void ApplyHDRModeValue()
    {
        if (HDROutputSettings.main.available)
            HDROutputSettings.main.RequestHDRModeChange(hdrToggle.value);
    }

    private void ApplyFPSTargetValue()
    {
        Application.targetFrameRate = int.Parse(targetFPSField.value);
    }

    void RefreshUIValues()
    {
        hdrToggle.value = HDROutputSettings.main.active;
        hdrToggle.SetEnabled(HDROutputSettings.main.available);
        // TODO: Sync the rest of the options
    }



}
