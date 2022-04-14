using GameLokal.Toolkit;
using UnityEngine;

public class Persistence : MonoBehaviour, IEventListener<GameEvent>
{
    private void OnEnable()
    {
        EventManager.AddListener(this);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(this);
    }

    private void SaveGame()
    {
        SaveLoadManager.Instance.Save();
    }

    public void OnEvent(GameEvent e)
    {
        if (e.EventName == Constants.ON_APPLICATION_BACKGROUND || e.EventName == Constants.ON_APPLICATION_QUIT)
        {
            SaveGame();
        }
    }
}
