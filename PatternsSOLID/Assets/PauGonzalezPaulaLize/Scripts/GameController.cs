using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemySpawnController enemySpawnController;
    public HealthController healthController;
    void Update()
    {
        if (healthController.getLive() == 0)
        {
            Vector3 location = enemySpawnController.getRandomLocation();
            enemySpawnController.spawnEnemyAtLocation(location);
            healthController.setLives();
            
        }
    }
}
