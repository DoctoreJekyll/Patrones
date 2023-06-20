using System;
using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Facade
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private PlayerSpawner playerSpawner;
        private DataStore dataStore;

        private void Awake()
        {
            dataStore = new PlayerPrefsDataStoreAdapter();
        }

        public void SaveGame()
        {
            var saveData = new SaveData(enemySpawner.enemies, playerSpawner.Player);
            dataStore.SetData(saveData, "SaveData");
        }

        public void LoadGame()
        {
            var saveData = dataStore.GetData<SaveData>("SaveData");
            enemySpawner.enemies = saveData.Enemies;
            playerSpawner.Player = saveData.Player;
        }
    }
}
