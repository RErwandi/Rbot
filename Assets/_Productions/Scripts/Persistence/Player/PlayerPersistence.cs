using System;

public class PlayerPersistence : BasePersistence
{
    public PlayerState state;

    public override string GetUniqueName()
    {
        return name;
    }

    public override object GetSaveData()
    {
        return state;
    }

    public override Type GetSaveDataType()
    {
        return typeof(PlayerState);
    }

    public override void ResetData()
    {
        
    }

    public override void OnLoad(object generic)
    {
        state = (PlayerState)generic;
    }
}
