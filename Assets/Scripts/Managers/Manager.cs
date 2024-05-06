using UnityEngine;

namespace Managers
{
    public abstract class Manager
    {
        protected Manager()
        {
            Init();
        }

        protected abstract void Init();
    }

    public abstract class Manager<T> : Manager where T : ScriptableObject
    {
        protected T gameAsset;

        protected Manager(T gameAsset)
        {
            this.gameAsset = gameAsset;
        }
        
    }
}