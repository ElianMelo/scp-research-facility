using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color unlockedColor;
    [SerializeField] Color lockedColor;
    [SerializeField] Color hoverColor;

    [SerializeField] TMP_Text phaseText;
    [SerializeField] Button selfButton;

    [SerializeField] Image background;
    [SerializeField] UpgradeType upgradeType;
    [SerializeField] UpgradeTarget upgradeTarget;
    [SerializeField] float amount;
    [SerializeField] bool isPercentage;
    [SerializeField] int cost;
    [SerializeField] int phases = 1;

    [SerializeField] UnityEvent OnUpgradeProgress;
    [SerializeField] UnityEvent OnUpgradeUnlock;
    [SerializeField] UnityEvent OnMouseEnter;
    [SerializeField] UnityEvent OnMouseExit;


    private bool isUnlocked;
    private int currentPhase = 0;


    void Start()
    {
        selfButton.onClick.AddListener(AttempBuyUpgrade);
        background.gameObject.SetActive(false);
        phaseText.text = $"{currentPhase} / {phases}";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnMouseEnter?.Invoke();
        //SoundManager.Instance.UIHover();
        TooltipManager.Show($"{ConvertUpgradeTypeToText(upgradeType)} \n Amount: {amount} \n Cost: {cost}");
        if (isUnlocked) return;
        background.color = hoverColor;
        background.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseExit?.Invoke();
        TooltipManager.Hide();
        if (isUnlocked) return;
        background.gameObject.SetActive(false);
    }

    private string ConvertUpgradeTypeToText(UpgradeType upgradeType)
    {
        return upgradeType.ToString();
    }

    private void AttempBuyUpgrade()
    {
        if (isUnlocked) return;
        bool brought = GameManager.Instance.AttemptRemoveKnowledge(cost);
        if (!brought) return;
        //SoundManager.Instance.UIBuy();
        currentPhase += 1;
        phaseText.text = $"{currentPhase} / {phases}";
        ApplyUpgradeEffect();
        OnUpgradeProgress?.Invoke();
        if (currentPhase == phases)
            UnlockUpgrade();
    }

    private void ApplyUpgradeEffect()
    {
        UpgradeManager.Instance.BuyUpgrade(upgradeType, upgradeTarget, amount);
    }


    private void UnlockUpgrade()
    {
        isUnlocked = true;
        OnUpgradeUnlock?.Invoke();
        background.color = unlockedColor;
    }
}
