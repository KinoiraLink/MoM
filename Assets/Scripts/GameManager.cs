using System;
using System.Collections.Generic;
using DataSO;
using Managers;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    //配置静态资源、数据、事件
    [SerializeField]
    private PlayerData playerData;
    
    //动态数据由各个管理器自己管理，配合对象池管理，比如动态的创建的 Character，
    
    //单例，唯一静态访问
    public static GameManager Instance { get; private set; }
    
    //管理器管理
    private readonly Dictionary<Type, Manager> _managers = new(); 
    
    public void Awake()
    {
        
        //保证唯一
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        RegisterAllManagers();
    }

    /// <summary>
    /// 注册管理器
    /// </summary>
    private void RegisterAllManagers()
    {
        Register<DynamicManager>();
        Register<StaticDataManager, PlayerData>(playerData);
    }

    /// <summary>
    /// 获取管理器
    /// </summary>
    /// <typeparam name="T">管理器类型</typeparam>
    /// <returns>管理器对象</returns>
    public T GetManager<T>() where T : Manager, new()
    {
        //便于延迟加载或者动态加载
        if (!_managers.ContainsKey(typeof(T)))
            Register<T>();
        /*
        {
            T t = Activator.CreateInstance<T>();
            _managers.Add(typeof(T),t);
            return t;
        }    
        */
        
        return (T)_managers[typeof(T)];
    }
    
    /// <summary>
    /// 加载资源管理器
    /// 如果管理器已经注册，使用GetManage
    /// </summary>
    /// <param name="gameAsset">数据</param>
    /// <typeparam name="T">管理器类型</typeparam>
    /// <typeparam name="TH">数据类型</typeparam>
    /// <returns>管理器</returns>
    public T LoadAssetManager<T,TH>(TH gameAsset) 
        where T : Manager<TH>, new()
        where TH : ScriptableObject
    {
        //便于延迟加载或者动态加载
        if (!_managers.ContainsKey(typeof(T)))
            Register<T,TH>(gameAsset) ;
        return (T)_managers[typeof(T)];
    }
    
    
    /// <summary>
    /// 注册管理器
    /// </summary>
    /// <param name="gameAsset">数据</param>
    /// <typeparam name="T">管理器类型</typeparam>
    /// <typeparam name="TH">数据类型</typeparam>
    private void Register<T,TH>(TH gameAsset) 
        where T : Manager<TH>,new()
        where TH : ScriptableObject
    {
        T t = new T();
        t.Init(gameAsset);
        _managers.Add(typeof(T),t);
    }
    /// <summary>
    /// 注册管理器
    /// </summary>
    /// <typeparam name="T">管理器类型</typeparam>
    private void Register<T>() 
        where T : Manager,new()
    {
        T t = new T();
        t.Init();
        _managers.Add(typeof(T), t);
    }
}



