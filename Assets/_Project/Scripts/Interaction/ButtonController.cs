using DG.Tweening;
using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private bool canClick = true;

    public void Click()
    {
        Debug.Log("Click Received!");
        if (!canClick) return;
        canClick = false;
        StartCoroutine(ClickRoutine());
    }

    private IEnumerator ClickRoutine()
    {
        var scale = 1.5f;
        var targetScale = new Vector3(scale, scale, scale);
        transform.DOScale(targetScale, 0.2f);
        yield return new WaitForSeconds(0.2f);
        transform.DOScale(Vector3.one, 0.2f);
        canClick = true;
    }
}
