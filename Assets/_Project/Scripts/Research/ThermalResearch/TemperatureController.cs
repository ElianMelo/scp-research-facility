using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureController : MonoBehaviour
{
    [SerializeField] ThermalResearchButtonsController controller;
    [SerializeField] ButtonController coldButton;
    [SerializeField] ButtonController hotButton;
    [SerializeField] TMP_Text minTemperatureMesh;
    [SerializeField] TMP_Text maxTemperatureMesh;
    [SerializeField] TMP_Text currentTemperatureMesh;
    [SerializeField] Image indicatorImage;
    [SerializeField] Gradient lightGradient;

    private float minTemperature = -40;
    private float maxTemperature = 80;
    private float currentTemperature = 20;

    void Start()
    {
        coldButton.OnClickPerformed += OnColdClickPerformed;
        hotButton.OnClickPerformed += OnHotClickPerformed;
    }

    private float ConvertCurrentValueToPercentage(float value)
    {
        return Mathf.InverseLerp(minTemperature, maxTemperature, value);
    }

    private void OnColdClickPerformed() {
        if (currentTemperature - 10f < minTemperature) return;
        currentTemperature -= 10f;
        UpdateVisuals();
    }

    private void OnHotClickPerformed() {
        if (currentTemperature + 10f > maxTemperature) return;
        currentTemperature += 10f;
        UpdateVisuals();
    }

    private Color CalculateCurrentLightBasedOnGradient(float percentage)
    {
        return lightGradient.Evaluate(percentage);
    }

    private void UpdateVisuals()
    {
        currentTemperatureMesh.text = currentTemperature.ToString("F0");
        var percentage = ConvertCurrentValueToPercentage(currentTemperature);
        indicatorImage.fillAmount = percentage;
        controller.UpdateRoomLight(CalculateCurrentLightBasedOnGradient(percentage));
    }
}
