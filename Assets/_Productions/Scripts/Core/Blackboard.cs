using GameLokal.Toolkit;

public class Blackboard : Singleton<Blackboard>
{
    public PlayerPersistence playerPersistence;
    public static PlayerPersistence Player => Instance.playerPersistence;
    
    private void Start()
    {
        InitializeAllPersistence();
        SaveLoadManager.Instance.Load();
        
        GameEvent.Trigger(Constants.EVENT_GAME_INITIALIZED);
    }

    private void InitializeAllPersistence()
    {
        var persitences = GetComponentsInChildren<BasePersistence>();
        foreach (var persistence in persitences)
        {
            persistence.Initialize();
        }
    }
}
