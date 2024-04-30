# 使用
1. 创建：管理器类需要继承 `Manager` 抽象类，含静态数据的继承 `Manager<T>` 抽象类
```Csharp
public class QuestManager : Manager
{
    //code
}

public class ResourceManager : Manager<AssetData>
{
    //code
}
```
2. 注册：管理器需要在 `GameManager` 类 `RegisterAllManagers()` 方法中注册
```Csharp
public class GameManager : MonoBehaviour
{
    private void RegisterAllManagers()
    {
        Register<QuestManager>();
        Register<ResourceManager, AssetData>(assetData);
    }
}
```
3. 调用：通过 `GameManager.Instance.GetManager<T>()` 调用
```Csharp
public class Player : MonoBehaviour
{
    private void Start()
    {
        //如果含静态数据的管理器没有注册，可以通过`LoadAssetManager`动态的注册调用
        float speed = GameManager.Instance.LoadAssetManager<PlayerManager,PlayerData>(playerData).GetPlayerData().speed;
        //如果不含静态数据的管理器没有注册，可以通过`GetManager`动态的注册调用
        GameManager.Instance.GetManager<ItemManager>().GetItemName(out string itemName);
        //如果两种管理器均已注册，均可通过`GetManager`调用
        int enduranceDuration = GameManager.Instance.GetManager<PlayerManager>().GetPlayerData().enduranceDuration;
        Debug.Log(speed);
        Debug.Log(str);
        Debug.Log(enduranceDuration);
    }
}
```
4. 静态数据存储在可编程对象中存储，在 GameManager 中关联，在具体的管理器中引用
```Csharp
[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float speed;
    public int enduranceDuration;
}
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;
}
```

思考来源 ：[UNITE －Unity项目架构设计与开发管理](https://www.bilibili.com/video/BV1zs411F7Zv/?spm_id_from=333.337.search-card.all.click)
