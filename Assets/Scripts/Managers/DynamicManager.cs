using UnityEngine;
using UnityEngine.Pool;

namespace Managers
{
    public class DynamicManager : Manager
    {
        private ObjectPool<Transform> _players;
        public override void Init()
        {
            base.Init();
            Debug.Log("TestManager 已初始化");

        }

        public DynamicManager GetString(out string str)
        {
            str = "TestManager";
            return this;
        }

        public DynamicManager PushPlayer(out Transform poolObject)
        {
            poolObject =  _players.Get();
            return this;
        }

        public DynamicManager PopPlayer(Transform player)
        {
            _players.Release(player);
            return this;
        }
    }
}