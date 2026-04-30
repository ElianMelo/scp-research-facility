using System;
using UnityEngine;

public enum GameState
{
    Upgrade,
    Research,
    Pause
}

public class GameManager : MonoBehaviour
{
    public float timerMaxAmount;
    public float timerCurrentAmount;
    public int knowledge;
    public int troopDamage;

    public bool shouldEndGame = false;

    public GameState currentState;

    public static GameManager Instance;

    public static Action<GameState> OnGameStateChanged;
    public GameState CurrentState => currentState;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentState = GameState.Pause;
        timerCurrentAmount = timerMaxAmount;
    }

    void Update()
    {
        UpdateGameTimer();
        // InterfaceManager.Instance.UpdateTimer(timerCurrentAmount);
    }

    public void FlagToEndGame()
    {
        shouldEndGame = true;
    }

    public void AddKnowledge(int amount)
    {
        knowledge += amount;
        //InterfaceManager.Instance.UpdateKaijuKnowledge(kaijuuKnowledge);
    }

    public bool AttemptRemoveKnowledge(int amount)
    {
        if (amount > knowledge)
        {
            //SoundManager.Instance.UINoFounds();
            return false;
        }
        knowledge -= amount;
        //InterfaceManager.Instance.UpdateKaijuKnowledge(kaijuuKnowledge);
        return true;
    }

    public void AddTroopDamage(int amount)
    {
        troopDamage += amount;
        //InterfaceManager.Instance.UpdateTroopDamage(troopDamage);
    }

    public bool AttemptRemoveTroopDamage(int amount)
    {
        if (amount > troopDamage)
        {
            //SoundManager.Instance.UINoFounds();
            return false;
        }
        troopDamage -= amount;
        //InterfaceManager.Instance.UpdateTroopDamage(troopDamage);
        return true;
    }

    private void UpdateGameTimer()
    {
        if (CurrentState != GameState.Research) return;
        timerCurrentAmount -= Time.deltaTime;
        if (timerCurrentAmount <= 0)
        {
            timerCurrentAmount = 0;
            if (shouldEndGame)
            {
                ChangeGameState(GameState.Upgrade);
                //InterfaceManager.Instance.ShowEndGameScreen();
                return;
            }
            ChangeGameState(GameState.Upgrade);
        }
    }

    public void EndUpgradePhase()
    {
        timerCurrentAmount = timerMaxAmount;
        ChangeGameState(GameState.Research);
    }

    public void ChangeGameState(GameState newState)
    {
        currentState = newState;
        OnGameStateChanged?.Invoke(currentState);
        TooltipManager.Hide();
    }
}
