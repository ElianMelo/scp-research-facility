using UnityEngine;

public class GlobalValuesManager : MonoBehaviour
{
    public static GlobalValuesManager Instance;

    private float knowledge = 0f;
    private float battery = 0f;
    private float maxBattery = 10f;

    public float Knowledge => knowledge;
    public float Battery => battery;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetBattery();
    }

    public void AddKnowledge(float amount)
    {
        knowledge += amount;
        InterfaceManager.Instance.UpdateKnowledge(knowledge);
    }

    public bool AttemptRemoveKnowledge(float amount)
    {
        if (amount > knowledge)
        {
            //SoundManager.Instance.UINoFounds();
            return false;
        }
        knowledge -= amount;
        InterfaceManager.Instance.UpdateKnowledge(knowledge);
        return true;
    }

    public void AddBattery(float amount)
    {
        battery += amount;
        InterfaceManager.Instance.UpdateBattery(knowledge);
    }

    public void ResetBattery()
    {
        battery = maxBattery;
        InterfaceManager.Instance.UpdateBattery(battery);
    }

    public bool RemoveBattery(float amount)
    {
        battery -= amount;
        if(battery <= 0) battery = 0;
        InterfaceManager.Instance.UpdateBattery(battery);
        return true;
    }
}
