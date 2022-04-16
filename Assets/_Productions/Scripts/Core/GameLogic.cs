using System;
using System.Collections;
using DG.Tweening;
using GameLokal.Toolkit;
using Kino;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ProgressBar = Michsky.UI.ModernUIPack.ProgressBar;

public class GameLogic : MonoBehaviour, IEventListener<GameEvent>
{
    public DialogueData intro;
    public DialogueData afterIntro;
    public QuestionClass friendship;
    public QuestionClass personality;
    public ProgressBar progressBar;
    public AnalogGlitch glitch;
    public Animator animator;
    public GameObject monikaOverlay;
    public GameObject monikaEyes;
    public int TotalQuestion => friendship.data.Length + personality.data.Length;
    private int iQuestion;
    private int iQuestion2 => iQuestion - friendship.data.Length;

    private void OnEnable()
    {
        EventManager.AddListener(this);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(this);
    }

    public void Start()
    {
        if (!Blackboard.Player.state.isDoneWithIntro)
        {
            Intro();
        }
        else
        {
            animator.SetBool("Troubled", true);
            Questioning();
        }
    }

    private void Update()
    {
        glitch.colorDrift = glitchValue;
        glitch.verticalJump = glitchValue;
        glitch.scanLineJitter = glitchValue;
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

    private float glitchValue;
    [Button]
    private void StartGlitch()
    {
        DOTween.To(() => glitchValue, x => glitchValue = x, 0.5f, 3f);
        animator.SetBool("Troubled", true);
        StartCoroutine(MonikaSequence());
    }

    [Button]
    private void EndGlitch()
    {
        DOTween.To(() => glitchValue, x => glitchValue = x, 0f, 1.5f);
    }

    private IEnumerator MonikaSequence()
    {
        monikaOverlay.GetComponent<Image>().DOFade(1f, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        monikaEyes.transform.DOScale(Vector3.one * 4f, 1f);
        monikaEyes.gameObject.SetActive(true);
        monikaOverlay.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        monikaEyes.gameObject.SetActive(false);
        monikaOverlay.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        monikaEyes.gameObject.SetActive(true);
        monikaOverlay.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        monikaEyes.gameObject.SetActive(false);
        monikaOverlay.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        monikaEyes.gameObject.SetActive(true);
        monikaOverlay.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        monikaEyes.gameObject.SetActive(false);
        monikaOverlay.GetComponent<Image>().DOFade(0f, 0.5f).SetEase(Ease.Linear);
    }

    public void OnEvent(GameEvent e)
    {
        if (e.EventName == "START_GLITCH")
        {
            StartGlitch();
        }

        if (e.EventName == "END_GLITCH")
        {
            EndGlitch();
        }
    }
}
