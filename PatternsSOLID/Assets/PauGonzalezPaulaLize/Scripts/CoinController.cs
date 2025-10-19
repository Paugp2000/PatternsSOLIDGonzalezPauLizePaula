using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

public class CoinController : MonoBehaviour {
    /// <summary>
    /// Metode que si el gameobject amb tag player entra en contacte amb la moneda crida al metode de afegir moneda i destrueix la moneda
    /// </summary>
    /// <param name="collision"></param>
    public GameObject coin;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().PickUpCoin();
            Destroy(gameObject);
        }
    }
    public GameObject CreateCoin(Vector3 position)
    {
        if (coin == null)
        {
            Debug.LogWarning("El prefab de moneda es nulo. No se pudo crear la moneda.");
            return null;
        }
        else
        {
            Debug.Log("Creacion de moneda");
            return Instantiate(coin, position, Quaternion.identity);
        }
      
    }
}
