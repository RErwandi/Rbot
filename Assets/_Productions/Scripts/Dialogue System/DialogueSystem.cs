using System;
using GameLokal.Toolkit;

public class DialogueSystem : Singleton<DialogueSystem>
{
    public LineView lineView;
    public OptionListView optionListView;

    private int iData;
    private DialogueData currentData;
    private Action dialogueCallback;
    private QuestionData currentQuestion;
    private Action questionCallback;
    
    public void Show(DialogueData data, Action callback = null)
    {
        currentData = data;
        iData = 0;
        dialogueCallback = callback;
        
        ShowCurrentDialogue();
    }

    public void Show(QuestionData question, Action callback = null)
    {
        currentQuestion = question;
        questionCallback = callback;
        lineView.Show(question.question, ShowAnswers);
    }

    private void ShowAnswers()
    {
        optionListView.Show(currentQuestion, OnAnswered);
    }

    private void OnAnswered()
    {
        lineView.Hide();
        optionListView.Hide();
        questionCallback?.Invoke();
    }

    private void ShowCurrentDialogue()
    {
        var dialogue = currentData.dialogues[iData];
        lineView.Show(dialogue.text, CheckNext);

        if (dialogue.useEvent && !string.IsNullOrEmpty(dialogue.eventName))
        {
            GameEvent.Trigger(dialogue.eventName);
        }
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
