using GameLokal.Toolkit;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public DialogueData intro;
    public DialogueData afterIntro;
    public QuestionClass friendship;
    public QuestionClass personality;
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
            FinishQuestion();
        }
    }

    private void FinishQuestion()
    {
        
    }
}
