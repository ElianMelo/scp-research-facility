using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour, IClickable
{
    private bool canClick = true;

    private void OnDisable()
    {
        StopAllCoroutines();
        transform.DOScale(Vector3.one, 0f);
        canClick = true;
    }

    public void OnClick()
    {
        if (!canClick) return;
        canClick = false;
        StartCoroutine(ClickRoutine());
    }

    private IEnumerator ClickRoutine()
    {
        var scale = 1.5f;
        var targetScale = new Vector3(scale, scale, scale);
        transform.DOScale(targetScale, 0.2f);
        GlobalValuesManager.Instance.AddKnowledge(10);
        yield return new WaitForSeconds(0.2f);
        transform.DOScale(Vector3.one, 0.2f);
        canClick = true;
    }
}
