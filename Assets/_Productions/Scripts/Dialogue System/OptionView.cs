using System;
using Michsky.UI.ModernUIPack;
using UnityEngine;

public class OptionView : MonoBehaviour
{
    public ButtonManagerBasic button;
    private string answer;
    private QuestionData questionData;
    private Action onClick;
    
    public void Setup(string answer, QuestionData questionData, Action callback)
    {
        this.questionData = questionData;
        button.buttonText = answer;
        onClick = callback;
    }

    public void OnClick()
    {
        Blackboard.Player.state.answeredQuestion.Add(questionData.id);
        onClick?.Invoke();
    }
}
