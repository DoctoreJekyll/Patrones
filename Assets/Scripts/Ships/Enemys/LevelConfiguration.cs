using UnityEngine;

namespace Ships.Enemys
{
    [CreateAssetMenu(menuName = "Create LevelConfiguration", fileName = "LevelConfiguration", order = 0)]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private SpawnConfiguration[] spawnConfigurations;

        public SpawnConfiguration[] SpawnConfigurations => spawnConfigurations;
    }
}
