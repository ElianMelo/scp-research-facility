using UnityEngine;

public enum UpgradeType
{
    None,
    Capacity,
    Recharge,
    Eficiency,
    Speed,
    Cooldown,
    Range,
}

public enum UpgradeTarget
{
    None,
    Battery,
    Security,
    SCP01,
    SCP02,
    SCP03,
    SCP04,
    Radioactive,
    Chemical,
    Thermic,
    Phonetic
}

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void BuyUpgrade(UpgradeType upgradeType, UpgradeTarget upgradeTarget, float amount)
    {
        // do something
    }
}

