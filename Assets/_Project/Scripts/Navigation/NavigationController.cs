using UnityEngine;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    [SerializeField] private Button researchButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private GameObject researchArea;
    [SerializeField] private GameObject upgradeArea;

    private enum NavigationTabs { 
        Research,
        Upgrade
    }

    private void Start()
    {
        researchButton.onClick.AddListener(() => { ShowNavigationByType(NavigationTabs.Research); });
        upgradeButton.onClick.AddListener(() => { ShowNavigationByType(NavigationTabs.Upgrade); });
    }

    private void OnDestroy()
    {
        researchButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.RemoveAllListeners();
    }

    private void ShowNavigationByType(NavigationTabs tab)
    {
        HideAll();
        switch (tab)    
        {
            case NavigationTabs.Research: researchArea.SetActive(true); return;
            case NavigationTabs.Upgrade: upgradeArea.SetActive(true); return;
        }
    }

    private void HideAll()
    {
        researchArea.SetActive(false);
        upgradeArea.SetActive(false);
    }
}
