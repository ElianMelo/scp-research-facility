using IngameDebugConsole;
using UnityEngine;

public class CommandsManager : MonoBehaviour
{
    void Start()
    {
        DebugLogConsole.AddCommand<int>("add-coin", "Add Coin", AddCoin);
        DebugLogConsole.AddCommand<int>("remove-coin", "Remove Coin", RemoveCoin);
    }

    private void AddCoin(int amount)
    {
        GameManager.Instance.AddKnowledge(amount);
    }

    private void RemoveCoin(int amount)
    {
        GameManager.Instance.AttemptRemoveKnowledge(amount);
    }
}
