using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance;
    [SerializeField] private TMP_Text textKnowledge;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateKnowledge(float amount)
    {
        textKnowledge.text = amount.ToString();
    }
}
