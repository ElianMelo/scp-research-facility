using System.Collections;
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

    float minTemperature = -40f;
    float maxTemperature = 80f;
    float currentTemperature = 20f;
    float targetTemperature = 20f;
    float targetSwitchRate = 0.003f;
    float clickAmount = 10f;

    Coroutine moveToTargetTemperatureRoutine;

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
        if (currentTemperature - clickAmount < minTemperature) targetTemperature = minTemperature;
        targetTemperature = currentTemperature - clickAmount;
        HandleTargetCoroutine();
    }

    private void OnHotClickPerformed() {
        if (currentTemperature + clickAmount > maxTemperature) targetTemperature = maxTemperature;
        targetTemperature = currentTemperature + clickAmount;
        HandleTargetCoroutine();
    }

    private void HandleTargetCoroutine()
    {
        if (moveToTargetTemperatureRoutine != null) StopCoroutine(moveToTargetTemperatureRoutine);
        moveToTargetTemperatureRoutine = StartCoroutine(MoveToTargetTemperature());
    }

    private IEnumerator MoveToTargetTemperature()
    {
        while (currentTemperature != targetTemperature)
        {
            currentTemperature = Mathf.Lerp(currentTemperature, targetTemperature, targetSwitchRate);
            UpdateVisuals();
            yield return null;
        }
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
