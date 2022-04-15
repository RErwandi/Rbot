using System;
using GameLokal.Toolkit;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public DialogueData intro;
    public void Start()
    {
        if (!Blackboard.Player.state.isDoneWithIntro)
        {
            Intro();
        }
    }

    private void Intro()
    {
        DialogueSystem.Instance.Show(intro, FinishIntro);
    }

    private void FinishIntro()
    {
        //Blackboard.Player.state.isDoneWithIntro = true;
    }
}
