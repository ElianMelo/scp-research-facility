using UnityEngine;
using UnityEngine.UI;

public class ResearchController : MonoBehaviour
{
    [SerializeField] Button addKnowledgeButton;
    [SerializeField] Button startResearchButton;

    void Awake()
    {
        GameManager.OnGameStateChanged += OnGameStateChanged;
        addKnowledgeButton.onClick.AddListener(AddKnowledge);
        startResearchButton.onClick.AddListener(StartResearch);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
        addKnowledgeButton.onClick.RemoveAllListeners();
        startResearchButton.onClick.RemoveAllListeners();
    }

    private void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)  
        {
            case GameState.Upgrade:
                addKnowledgeButton.gameObject.SetActive(false);
                startResearchButton.gameObject.SetActive(true);
                break;
            case GameState.Research:
                addKnowledgeButton.gameObject.SetActive(true);
                startResearchButton.gameObject.SetActive(false);
                break;
            case GameState.Pause:
                addKnowledgeButton.gameObject.SetActive(false);
                startResearchButton.gameObject.SetActive(true);
                break;
        }
    }

    private void AddKnowledge()
    {
        GlobalValuesManager.Instance.AddKnowledge(10);
    }

    private void StartResearch()
    {
        GameManager.Instance.TriggerResearchPhase();
    }
}
