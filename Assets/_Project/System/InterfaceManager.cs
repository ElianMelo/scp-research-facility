using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance;
    [SerializeField] private Button buttonCoin;
    [SerializeField] private TMP_Text textCoin;
    private int coin = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        buttonCoin.onClick.AddListener(UpdateCoin);
    }

    private void OnDestroy()
    {
        buttonCoin.onClick.RemoveAllListeners();
    }

    private void UpdateCoin()
    {
        coin++;
        textCoin.text = coin.ToString();
    }
}
