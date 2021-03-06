using System;
using System.Collections;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class LineView : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI lineText;
    public TextAnimatorPlayer textPlayer;

    private Action completeShowCallback;
    private void Awake()
    {
        Hide();
        
        textPlayer.onTextShowed.AddListener(TextShowed);
    }

    private void OnDestroy()
    {
        textPlayer.onTextShowed.RemoveListener(TextShowed);
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
    }

    public void Show(string text, Action callback = null)
    {
        completeShowCallback = callback;
        lineText.text = text;
        Show();
    }

    private void TextShowed()
    {
        StartCoroutine(RunCallback());
    }

    private IEnumerator RunCallback()
    {
        yield return new WaitForSeconds(1f);
        completeShowCallback?.Invoke();
    }
}
