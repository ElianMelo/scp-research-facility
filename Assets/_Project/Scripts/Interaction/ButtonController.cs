using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour, IClickable
{
    [SerializeField] private float initialScale = 1f;
    [SerializeField] private float targetScale = 1.5f;
    private bool canClick = true;

    public Action OnClickPerformed;

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
        var targetScaleVector = new Vector3(targetScale, targetScale, targetScale);
        transform.DOScale(targetScaleVector, 0.2f);
        OnClickPerformed?.Invoke();
        yield return new WaitForSeconds(0.2f);
        transform.DOScale(new Vector3(initialScale, initialScale, initialScale), 0.2f);
        canClick = true;
    }
}
