using DataSO;
using UnityEngine;

namespace Managers
{
    public class StaticDataManager : Manager<PlayerData>
    {
        protected override void Init()
        {
            Debug.Log("StaticDataManager 已初始化");

        }

        public PlayerData GetPlayerData()
        {
            return gameAsset;
        }

        public StaticDataManager(PlayerData gameAsset) : base(gameAsset)
        {
            
        }
        
        
        
    }
}