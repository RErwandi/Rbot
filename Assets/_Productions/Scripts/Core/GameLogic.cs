using GameLokal.Toolkit;
using Unity.VisualScripting;
using UnityEngine;
using ProgressBar = Michsky.UI.ModernUIPack.ProgressBar;

public class GameLogic : MonoBehaviour
{
    public DialogueData intro;
    public DialogueData afterIntro;
    public QuestionClass friendship;
    public QuestionClass personality;
    public ProgressBar progressBar;
    public int TotalQuestion => friendship.data.Length + personality.data.Length;
    private int iQuestion;
    private int iQuestion2 => iQuestion - friendship.data.Length;
    public void Start()
    {
        if (!Blackboard.Player.state.isDoneWithIntro)
        {
            Intro();
        }
        else
        {
            Questioning();
        }
    }

    private void Intro()
    {
        DialogueSystem.Instance.Show(intro, AskForPermission);
    }

    private void AskForPermission()
    {
        AfterIntro();
    }

    private void AfterIntro()
    {
        DialogueSystem.Instance.Show(afterIntro, FinishIntro);
    }

    private void FinishIntro()
    {
        Blackboard.Player.state.isDoneWithIntro = true;
        Questioning();
    }

    private void Questioning()
    {
        UpdateProgressBar();
        
        if (Blackboard.Player.state.answeredQuestion.Contains(friendship.data[iQuestion].id))
        {
            NextQuestion();
        }
        else
        {
            DialogueSystem.Instance.Show(friendship.data[iQuestion], NextQuestion);
        }
    }

    private void NextQuestion()
    {
        iQuestion++;
        if (iQuestion < friendship.data.Length)
        {
            Questioning(); 
        }
        else
        {
            Questioning2();
        }
    }
    
    private void Questioning2()
    {
        UpdateProgressBar();
        
        if (Blackboard.Player.state.answeredQuestion.Contains(personality.data[iQuestion2].id))
        {
            NextQuestion2();
        }
        else
        {
            DialogueSystem.Instance.Show(personality.data[iQuestion2], NextQuestion2);
        }
    }
    
    private void NextQuestion2()
    {
        iQuestion++;
        if (iQuestion2 < personality.data.Length)
        {
            Questioning2(); 
        }
        else
        {
            FinishQuestion();
        }
    }

    private void FinishQuestion()
    {
        UpdateProgressBar();
        Debug.Log("Finish question");
    }

    private void UpdateProgressBar()
    {
        var percentValue = (float)iQuestion / (TotalQuestion) * 100f;
        progressBar.currentPercent = percentValue;
    }
}
