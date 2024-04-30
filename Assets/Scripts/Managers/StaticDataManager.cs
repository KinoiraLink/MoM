using DataSO;
using UnityEngine;

namespace Managers
{
    public class StaticDataManager : Manager<PlayerData>
    {
        public override void Init()
        {
            base.Init();
            Debug.Log("AssetTestManager 已初始化,PlayerData 已加载");
        }

        public PlayerData GetPlayerData()
        {
            return gameAsset;
        }
    }
}