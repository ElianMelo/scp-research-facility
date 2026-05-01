using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    private static TooltipManager Instance;
    public Tooltip tooltip;

    private void Awake()
    {
        Instance = this;
    }

    public static void Show(string cardData)
    {
        Instance.tooltip.SetText(cardData);
        Instance.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        Instance.tooltip.gameObject.SetActive(false);
    }
}
