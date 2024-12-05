using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float  jumpForce = 10.0f;
    public float gravityModifier = 0.0f;
    public bool isOnGround = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //*= ha la stessa logica di +=, una semplificazione di Physics.gravity = Physics.gravity * gravityModifier;
        Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //ForceMode forza l'applicazione della formula, Impulse fa in modo che la cosa sia immediata
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
