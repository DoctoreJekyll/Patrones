using Inputs;
using UnityEngine;

namespace Ships.Enemys
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private LevelConfiguration levelConfiguration;
        [SerializeField] private ShipConfiguration shipsConfiguration;
        private ShipFactory shipFactory;

        private float currentTimeInSeconds;
        private int currentConfigurationIndex;

        private void Awake()
        {
            shipFactory = new ShipFactory(Instantiate(shipsConfiguration));
        }

        private void Update()
        {
            if (currentConfigurationIndex >= levelConfiguration.SpawnConfigurations.Length)
            {
                return;
            }
            
            currentTimeInSeconds += Time.deltaTime;

            SpawnConfiguration spawnConfiguration = levelConfiguration.SpawnConfigurations[currentConfigurationIndex];
            if (spawnConfiguration.TimeToSpawn > currentTimeInSeconds)
            {
                return;
            }

            SpawnShips(spawnConfiguration);
            currentConfigurationIndex += 1;
        }

        private void SpawnShips(SpawnConfiguration spawnConfiguration)
        {
            for (int i = 0; i < spawnConfiguration.ShipToSpawnConfigurations.Length; i++)
            {
                ShipToSpawnConfiguration shipConfiguration = spawnConfiguration.ShipToSpawnConfigurations[i];
                Transform spawnPosition = spawnPositions[i % spawnPositions.Length];
                ShipMediator ship = shipFactory.Create(shipConfiguration.ShipId.Id,
                                               spawnPosition,
                                               spawnPosition.rotation);
                ship.Configure(new AIInputAdapter(ship), 
                               new InitialPosCheckLimits(ship.transform, 10f),
                               shipConfiguration.Speed,
                               shipConfiguration.FireRate,
                               shipConfiguration.DefaultProjectileId);
            }
        }
    }
}
