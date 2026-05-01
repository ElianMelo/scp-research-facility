using UnityEngine;
using UnityEngine.UI;

public class ResearchController : MonoBehaviour
{
    [SerializeField] Button addCoinButton;

    void Start()
    {
        addCoinButton.onClick.AddListener(AddCoin);
    }

    private void OnDestroy()
    {
        addCoinButton.onClick.RemoveAllListeners();
    }

    private void AddCoin()
    {
        GameManager.Instance.AddKnowledge(10);
    }
}
