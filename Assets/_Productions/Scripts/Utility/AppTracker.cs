using GameLokal.Toolkit;
using UnityEngine;

public class AppTracker : MonoBehaviour, IEventListener<GameEvent>
{
    private bool isInit;

    private void OnEnable()
    {
        EventManager.AddListener(this);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(this);
    }

    private void Initialize()
    {
        isInit = true;
    }
        
    private void OnApplicationFocus(bool focus)
    {
        if (isInit)
        {
            if (focus)
            {
                OnApp();
            }
            else
            {
                OnBackground();
            }
        }
    }
        
    private void OnApp()
    {
        GameEvent.Trigger(Constants.ON_APPLICATION_FOCUS);
    }

    private void OnBackground()
    {
        GameEvent.Trigger(Constants.ON_APPLICATION_BACKGROUND);
    }

    private void OnApplicationQuit()
    {
        GameEvent.Trigger(Constants.ON_APPLICATION_QUIT);
    }

    public void OnEvent(GameEvent e)
    {
        if (e.EventName == Constants.EVENT_GAME_INITIALIZED)
        {
            Initialize();   
        }
    }
}
