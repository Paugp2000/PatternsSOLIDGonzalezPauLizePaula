using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour {
    [SerializeField] int maxLives = 3;//Vida maxima
    [SerializeField] int lives = 3;//Vida inicia

    /// <summary>
    /// Metode que resta vida al cridarse desde altres scripts
    /// </summary>
    public void GetHit() {
        lives--;
        if (lives <= 0) {
            Destroy(gameObject);
        }
        
    }
    public int getLive()
    {
        return lives;
    }
    public void setLives()
    {
        lives = maxLives;
    }
}
