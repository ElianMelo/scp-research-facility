using UnityEngine;

public class SkillItem : MonoBehaviour
{
    [SerializeField] private SkillType skillType;
    [SerializeField] private SkillTarget skillTarget;
    [SerializeField] private float amount;
    [SerializeField] private bool isPercentage;
    [SerializeField] private float cost;
    [SerializeField] private int phases = 1;
    private int currentPhase = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
