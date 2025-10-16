using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    /// <summary>
    /// Metode que si el gameobject amb tag player entra en contacte amb la moneda crida al metode de afegir moneda i destrueix la moneda
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerController>().PickUpCoin();
            Destroy(gameObject);
        }
    }
}
