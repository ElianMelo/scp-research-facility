using UnityEngine;
using UnityEngine.UI;

public class ResearchController : MonoBehaviour
{
    [SerializeField] GameObject addKnowledgeButton;
    [SerializeField] Button startResearchButton;

    void Awake()
    {
        GameManager.OnGameStateChanged += OnGameStateChanged;
        startResearchButton.onClick.AddListener(StartResearch);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
        startResearchButton.onClick.RemoveAllListeners();
    }

    private void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)  
        {
            case GameState.Upgrade:
                addKnowledgeButton.SetActive(false);
                startResearchButton.gameObject.SetActive(true);
                break;
            case GameState.Research:
                addKnowledgeButton.SetActive(true);
                startResearchButton.gameObject.SetActive(false);
                break;
            case GameState.Pause:
                addKnowledgeButton.SetActive(false);
                startResearchButton.gameObject.SetActive(true);
                break;
        }
    }

    private void StartResearch()
    {
        GameManager.Instance.TriggerResearchPhase();
    }
}
