using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public LineView lineView;

    private int iData;
    private DialogueData currentData;

    [Button]
    public void Show(DialogueData data)
    {
        currentData = data;
        iData = 0;
        
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
    }
}
