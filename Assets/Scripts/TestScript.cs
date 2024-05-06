using System;
using DataSO;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    public PlayerData playerData;
    

    private void Start()
    {
        GameManager.Proxy.LoadManager<StaticDataManager,PlayerData>(playerData);
        GameManager.Proxy.LoadManager<DynamicManager>();
        GameManager.Proxy.GetManager<DynamicManager>().GetString(out string str);
        int enduranceDuration = GameManager.Proxy.GetManager<StaticDataManager>().GetPlayerData().enduranceDuration;
        Debug.Log(str);
        Debug.Log(enduranceDuration);
    }
    
    
}

