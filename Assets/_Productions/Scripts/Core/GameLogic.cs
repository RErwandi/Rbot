using GameLokal.Toolkit;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public DialogueData intro;
    public DialogueData afterIntro;
    public QuestionClass question;
    private int iQuestion;
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
        DialogueSystem.Instance.Show(question.data[iQuestion], NextQuestion);
    }

    private void NextQuestion()
    {
        iQuestion++;
        if (iQuestion < question.data.Length)
        {
            Questioning(); 
        }
        else
        {
            FinishQuestion();
        }
    }

    private void FinishQuestion()
    {
        
    }
}
