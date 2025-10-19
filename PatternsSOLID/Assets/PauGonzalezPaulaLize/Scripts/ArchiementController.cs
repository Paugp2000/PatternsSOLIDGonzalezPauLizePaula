using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchiementController : MonoBehaviour
{
    private static ArchiementController archiementController;
    public PlayerController playerController;
    public GameController gameController; 
    [SerializeField] NotificationManager notificationManager;
    public static ArchiementController instance
    {
        get { return RequestInstance(); }
    }
    private static ArchiementController RequestInstance()
    {
        if (archiementController == null)
        {
            GameObject archiementControllerObject = new GameObject("ArchiementController");
            archiementController = archiementControllerObject.AddComponent<ArchiementController>();
        }
        return archiementController;
    }
    private void Awake()
    {
        if (archiementController == null)
        {
            archiementController = this;
        }
        else if (archiementController != this)
        {
            Destroy(archiementController.gameObject);
        }
    }
    public void playerMonedasArch()
    {
        notificationManager.AddNotification("Nuevo Logro : Has conseguido cinco monedas, felicidades.", 1.5f);
    }
    public void playerSaltosArch()
    {
        notificationManager.AddNotification("Nuevo Logro : Has saltado 10 veces, felicidades", 1.5f);
    }
    public void playerEnemiesArch()
    {
        notificationManager.AddNotification("Nuevo Logro : Has matado a tres enemigos, felicidades", 1.5f);
    }
}
