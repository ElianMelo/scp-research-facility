using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance;
    [SerializeField] private TMP_Text textKnowledge;
    [SerializeField] private TMP_Text textBattery;
    [SerializeField] private TMP_Text textSecurity;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateKnowledge(float amount)
    {
        textKnowledge.text = amount.ToString();
    }
    public void UpdateBattery(float amount)
    {
        textBattery.text = amount.ToString();
    }
    public void UpdateSecurity(float amount)
    {
        textSecurity.text = amount.ToString();
    }
}
