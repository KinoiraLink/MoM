using UnityEngine;

namespace Managers
{
    public abstract class Manager
    {
        public virtual void Init() { }
    }

    public abstract class Manager<T> : Manager where T : ScriptableObject
    {
        protected T gameAsset;

        /// <summary>
        /// 初始化管理器数据
        /// </summary>
        /// <param name="gameAsset">数据</param>
        public virtual void Init(T gameAsset)
        {
            this.gameAsset = gameAsset;
            Init();
        }
    }
}