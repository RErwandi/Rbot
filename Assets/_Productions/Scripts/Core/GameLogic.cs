using System;
using System.Collections.Generic;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public DialogueData intro;
    public DialogueData afterIntro;
    public List<Question> questions = new List<Question>();
    private int iQuestion = 0;
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
        DialogueSystem.Instance.Show(questions[iQuestion], NextQuestion);
    }

    private void NextQuestion()
    {
        iQuestion++;
        if (iQuestion < questions.Count)
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
