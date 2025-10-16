using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public HealthController healthController;
    [SerializeField] GameObject enemySpawned;
    public Vector3 getRandomLocation()
    {
        Vector3 location = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 0);

        return location;
    }
    public GameObject spawnEnemyAtLocation(Vector3 location)
    { 
            Instantiate(enemySpawned,location,Quaternion.identity);
            return enemySpawned;
    }
}
class EnemyPool
{
    public GameObject Enemy;
    public int maxPoolSize = 100;
    private List<GameObject> pool;
     public void Start()
    {
        pool = new List<GameObject>();
    }

}
