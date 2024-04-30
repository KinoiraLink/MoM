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
        float speed = GameManager.Instance.LoadAssetManager<StaticDataManager,PlayerData>(playerData).GetPlayerData().speed;
        GameManager.Instance.GetManager<DynamicManager>().GetString(out string str);
        int enduranceDuration = GameManager.Instance.LoadAssetManager<StaticDataManager,PlayerData>(playerData).GetPlayerData().enduranceDuration;
        Debug.Log(speed);
        Debug.Log(str);
        Debug.Log(enduranceDuration);
    }
    
    
}

