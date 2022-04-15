using System;
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
        canvasGroup.interactable = false;
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
    }

    public void Show(QuestionData questionData, Action callback = null)
    {
        ResetOptions();
        Show();
        answeredCallback = callback;

        foreach (var answer in questionData.answers)
        {
            var option = Instantiate(optionView, container);
            option.Setup(answer, questionData, OnAnswered);
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
