using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    List<GameObject> enemies;
    public GameObject enemy;
    public int poolSize = 50; 
    public  HealthController healthController;
    private void Start()
    {

        enemies = new List<GameObject>();
        GameObject clon;
        for (int i = 0; i < poolSize; i++)
        {
            clon = Instantiate(enemy, getRandomLocation(), Quaternion.identity);
            clon.SetActive(false);
            enemies.Add(clon);
        }
    }
    public Vector3 getRandomLocation()
    {
        Vector3 location = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 0);
        return location;
    }
    public List<GameObject> returnList()
    {
        return enemies;
    }

}
