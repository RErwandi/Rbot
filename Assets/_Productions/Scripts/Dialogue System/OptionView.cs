using System;
using Michsky.UI.ModernUIPack;
using UnityEngine;

public class OptionView : MonoBehaviour
{
    public ButtonManagerBasic button;
    private Answer answer;
    private Action onClick;
    
    public void Setup(Answer answer, Action callback)
    {
        this.answer = answer;
        button.buttonText = answer.answerName;
        onClick = callback;
    }

    public void OnClick()
    {
        Blackboard.Player.state.answeredQuestion.Add(answer.name);
        onClick?.Invoke();
    }
}
