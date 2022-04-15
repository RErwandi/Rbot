using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionListView : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public RectTransform container;
    public OptionView optionView;
    private Action answeredCallback;
    
    private void Awake()
    {
        Hide();
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
    }

    public void Show(List<Answer> answers, Action callback = null)
    {
        ResetOptions();
        Show();
        answeredCallback = callback;

        foreach (var answer in answers)
        {
            var option = Instantiate(optionView, container);
            option.Setup(answer, OnAnswered);
        }
    }

    private void ResetOptions()
    {
        foreach (var option in container.GetComponentsInChildren<OptionView>())
        {
            Destroy(option.gameObject);
        }
    }

    private void OnAnswered()
    {
        answeredCallback?.Invoke();
    }
}
