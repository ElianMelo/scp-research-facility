using IngameDebugConsole;
using UnityEngine;

public class CommandsManager : MonoBehaviour
{
    void Start()
    {
        DebugLogConsole.AddCommand<int>("coin-add", "Add Coin", CoinAdd);
        DebugLogConsole.AddCommand<int>("coin-remove", "Remove Coin", CoinRemove);
    }

    private void CoinAdd(int amount)
    {
        GameManager.Instance.AddKnowledge(amount);
    }

    private void CoinRemove(int amount)
    {
        GameManager.Instance.AttemptRemoveKnowledge(amount);
    }
}
