using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerControllerScript;
    public float leftBound = - 20;

    // Start is called before the first frame update
    void Start()
    {
        //In questo modo diciamo di cercare nel gioco l'oggetto "Player", e di recuperare il suo componente "PlayerController", che è lo script che abbiamo fatto per gestire il suo movimento.
        //Questa cosa è fondamentale perché a noi serve capire se fermare o meno l'avanzamento degli oggetti nel gioco in caso di Game Over, e questa informazione la detta un altro script (PlayerController). In questo modo ne abbiamo accesso.
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Questo è anche un altro modo per bloccare il movimento del player se si muove nei dialoghi del mio progetto?
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
                Destroy(gameObject);
        }

    }
}
