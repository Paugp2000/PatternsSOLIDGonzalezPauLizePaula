using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NotificationManager : MonoBehaviour {
    public class Notification {
        public string message;//Text del missatge
        public float duration;//Duracio del misstage
        /// <summary>
        /// Constructor de la clase notificacio
        /// </summary>
        /// <param name="message"></param>
        /// <param name="duration"></param>
        public Notification(string message, float duration) {
            this.duration = duration;
            this.message = message;
        }
    }

    public Notification currentNotification;//Instancia de la clase notificació
    public Queue<Notification> notificationQueue = new Queue<Notification>(); //Declara una cua (queue) que contindrà objectes del tipus Notification. Una cua és una estructura de dades FIFO (First In, First Out), on el primer element que entra és el primer que surt.



    [SerializeField] TMPro.TextMeshProUGUI textToShow;//Text que mostra en la notificacio
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float defaultNotificationFadeInDuration = 0.5f; //Configuren la durada de l’animació d’entrada i sortida d’una notificació
    [SerializeField] float defaultNotificationFadeOutDuration = 0.5f;
    [SerializeField] float timeBetweenNotifications = 0.5f; //Configura el temps entre notificacions

    float timeRemainingForNextNotification = 0.0f;
    /// <summary>
    /// Crea una nova notificació
    /// </summary>
    /// <param name="message"></param>
    /// <param name="duration"></param>
    public void AddNotification(string message, float duration) {
        notificationQueue.Enqueue(new Notification(message, duration));
    }

    public void Update() {
        if (currentNotification == null) {//Si no hi han notificacions
            timeRemainingForNextNotification = Mathf.Clamp(timeRemainingForNextNotification - Time.deltaTime, 0, timeBetweenNotifications);//Actualitza un temporitzador que controla quan es pot mostrar la següent notificació, assegurant-se que el valor es manté dins d’un rang vàlid.
        }
        if (notificationQueue.Count == 0) return;

        if (currentNotification == null) {
            currentNotification = notificationQueue.Dequeue();
            StartCoroutine(_InitializeNewNotification(currentNotification));
        }//Gestiona la visualització de notificacions en cua, assegurant que només s’inicia una nova notificació si no n’hi ha cap activa.

    }

    IEnumerator _InitializeNewNotification(Notification n) {//Inicia una corrutina que gestiona les notificacions
        float timer = 0;
        textToShow.text = n.message;

        //TODO FADE IN
        while (timer < defaultNotificationFadeInDuration) {

            canvasGroup.alpha = Mathf.Lerp(0, 1, timer / defaultNotificationFadeInDuration);

            yield return null;
            timer += Time.deltaTime;
        }
        timer = 0;

        //TODO SHOW FOR SECONDS
        while (timer < n.duration) {
            yield return null;
            timer += Time.deltaTime;
        }

        timer = 0;

        //TODO HIDE 
        while (timer < defaultNotificationFadeOutDuration) {

            canvasGroup.alpha = Mathf.Lerp(1, 0, timer / defaultNotificationFadeInDuration);

            yield return null;
            timer += Time.deltaTime;
        }
        timeRemainingForNextNotification = timeBetweenNotifications;
        currentNotification = null;
    }

}
