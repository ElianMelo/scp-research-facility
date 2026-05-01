using System;
using System.Collections;
using UnityEngine;

public enum GameState
{
    Upgrade,
    Research,
    Pause
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;
    public static Action<GameState> OnGameStateChanged;
    public GameState CurrentState => currentState;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeGameState(GameState.Pause);
    }

    public void TriggerResearchPhase()
    {
        ChangeGameState(GameState.Research);
        StartCoroutine(ResearchPhaseCoroutine());
        IEnumerator ResearchPhaseCoroutine()
        {
            while(GlobalValuesManager.Instance.Battery > 0)
            {
                yield return new WaitForSeconds(1f);
                GlobalValuesManager.Instance.RemoveBattery(1);
            }
            GlobalValuesManager.Instance.ResetBattery();
            ChangeGameState(GameState.Upgrade);
        }
    }

    public void ChangeGameState(GameState newState)
    {
        currentState = newState;
        OnGameStateChanged?.Invoke(currentState);
        TooltipManager.Hide();
    }
}
