using UnityEngine;

namespace DataSO
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float speed;
        public int enduranceDuration;
    }
}


