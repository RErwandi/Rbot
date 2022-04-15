using System;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

public class DialogueSystem : Singleton<DialogueSystem>
{
    public LineView lineView;
    public OptionListView optionListView;

    private int iData;
    private DialogueData currentData;
    private Action dialogueCallback;
    private Question currentQuestion;
    private Action questionCallback;
    
    public void Show(DialogueData data, Action callback = null)
    {
        currentData = data;
        iData = 0;
        dialogueCallback = callback;
        
        ShowCurrentDialogue();
    }

    public void Show(Question question, Action callback = null)
    {
        currentQuestion = question;
        questionCallback = callback;
        lineView.Show(question.questionName, ShowAnswers);
    }

    private void ShowAnswers()
    {
        optionListView.Show(currentQuestion.answers, OnAnswered);
    }

    private void OnAnswered()
    {
        lineView.Hide();
        optionListView.Hide();
        questionCallback?.Invoke();
    }

    private void ShowCurrentDialogue()
    {
        lineView.Show(currentData.dialogues[iData].text, CheckNext);
    }

    private void CheckNext()
    {
        iData++;

        if (iData >= currentData.dialogues.Count)
        {
            FinishCurrentDialogue();
        }
        else
        {
            ShowCurrentDialogue();
        }
    }

    private void FinishCurrentDialogue()
    {
        lineView.Hide();
        dialogueCallback?.Invoke();
    }
}
