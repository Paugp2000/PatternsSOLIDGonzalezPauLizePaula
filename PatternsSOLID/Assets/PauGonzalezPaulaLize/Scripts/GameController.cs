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
    public CoinController coinController;
    public GameObject coin;
    private static GameController gameController;
    public static GameController instance
    {
        get { return RequestInstance(); }
    }
    private static GameController RequestInstance()
    {
        if (gameController == null)
        {
            GameObject gameControllerObject = new GameObject("GameController");
            gameController = gameControllerObject.AddComponent<GameController>();
        }
        return gameController;
    }
    private void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }else if(gameController != this){
            Destroy(gameController.gameObject);
        }
    }
    public void instantiateEnemy()
    {
        enemyList = enemyInstance.returnList();
        enemyList[enemyCount].SetActive(true);
        enemyCount++;
        Debug.Log("Enemigo instanciado : " + enemyCount + "\n");
    }
    public void instanciateCoin()
    {
        Vector3 firstEnemyPosition = new Vector3 (2.89f, -3.16f, 0f);
        if (enemyCount-2 < 0)
        {
            coinController.CreateCoin(firstEnemyPosition);
        }
        else
        {
            coinController.CreateCoin(enemyInstance.returnList()[enemyCount-2].transform.position);
        }
       
    }
}
