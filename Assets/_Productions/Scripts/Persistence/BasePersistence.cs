using System;
using System.Collections;
using System.Collections.Generic;
using GameLokal.Toolkit;
using UnityEngine;

public class BasePersistence : MonoBehaviour, IGameSave
{
    public void Initialize()
    {
        SaveLoadManager.Instance.Initialize(this);
    }
    public virtual string GetUniqueName()
    {
        throw new NotImplementedException();
    }

    public virtual object GetSaveData()
    {
        throw new NotImplementedException();
    }

    public virtual Type GetSaveDataType()
    {
        throw new NotImplementedException();
    }

    public virtual void ResetData()
    {
        throw new NotImplementedException();
    }

    public virtual void OnLoad(object generic)
    {
        throw new NotImplementedException();
    }
}