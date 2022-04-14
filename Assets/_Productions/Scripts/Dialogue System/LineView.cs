using System;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class LineView : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI lineText;
    public TextAnimatorPlayer textPlayer;

    private Action completeShowCallback;
    private void Start()
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
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
    }

    public void Show(string text, Action callback = null)
    {
        completeShowCallback = callback;
        lineText.text = text;
        Show();
    }

    private void TextShowed()
    {
        completeShowCallback?.Invoke();
    }
}
