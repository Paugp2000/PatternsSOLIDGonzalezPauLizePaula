using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    private int enemyCount = 0;
    public Enemy enemyInstance;
    protected List<GameObject> enemyList;
    public HealthController healthController;
    public GameObject coin;
    public void instantiateEnemy()
    {
        enemyList = enemyInstance.returnList();
        enemyList[enemyCount].SetActive(true);
        enemyCount++;
        Debug.Log("Enemigo instanciado : " + enemyCount + "\n");
    }
    public void instanciateCoin()
    {
        Instantiate(coin, enemyList[enemyCount-1].transform.position, Quaternion.identity);
    }
}
