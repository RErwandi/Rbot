using System;
using System.Collections.Generic;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public DialogueData intro;
    public DialogueData afterIntro;
    
    [AssetList(Path = "_Productions/Database/Questions/", AutoPopulate = true)]
    public List<Question> questions = new List<Question>();
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
        
    }

    private void AfterIntro()
    {
        
    }

    private void FinishIntro()
    {
        Blackboard.Player.state.isDoneWithIntro = true;
    }

    private void Questioning()
    {
        
    }
}
