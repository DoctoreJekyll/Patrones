using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Facade
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<Enemy> enemies = new List<Enemy>{
                                                          new Enemy(50, 50),
                                                          new Enemy(50, 50)
                                                      };
    }
}
