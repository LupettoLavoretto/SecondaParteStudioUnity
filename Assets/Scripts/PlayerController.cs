using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim; 
    public float  jumpForce = 10.0f;
    public float gravityModifier = 0.0f;
    public bool isOnGround = true;
    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        //*= ha la stessa logica di +=, una semplificazione di Physics.gravity = Physics.gravity * gravityModifier;
        Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //ForceMode forza l'applicazione della formula, Impulse fa in modo che la cosa sia immediata
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Per vedere dov'è jump_trig: lo troviamo in animator -> parameters
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Ground"))
            {
            
            isOnGround = true;

            }
        
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            //Queste sono tutte condizioni che troviamo sempre su Animator -> Layers -> Conditions.
            //Il primo è un booleano, per cui gli diciamo di selezionare la morte "b" come vera. Il secondo invece è un integrale, per cui dobbiamo dargli il valore numerico.
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }    
    }
}
