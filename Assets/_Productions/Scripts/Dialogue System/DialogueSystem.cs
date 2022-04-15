using System;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

public class DialogueSystem : Singleton<DialogueSystem>
{
    public LineView lineView;

    private int iData;
    private DialogueData currentData;
    private Action dialogueCallback;
    
    public void Show(DialogueData data, Action callback = null)
    {
        currentData = data;
        iData = 0;
        dialogueCallback = callback;
        
        ShowCurrentDialogue();
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
