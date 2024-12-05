using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        //Questa formula ci permette di ricavare la lunghezza del collider (asse x) e di conseguenza la lunghezza del background. Dato che l'interruzione grafica è a metà, divideremo poi quel valore per 2
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Quando la posizione attuale sull'asse x ha un valore più basso di quella iniziale (più correttore), resetto le posizioni
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
