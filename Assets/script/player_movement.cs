using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class player_movement : MonoBehaviour  //monobehaviour è associato agli oggetti di unity
{


    [Header("General Setting")]
    public float playerSpeed = 10;
    public float jumpForce = 10;
    public Rigidbody2D body;


    // per il salto:
    bool isGrounded; // variabile per verificare che il player salti solo quando tocca la terra


    [Header("Gravity Settings")]
    public float baseGravity = 2;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultipler = 2f;

    [Header("GroundCheck")]
    public Transform groundCheckTransform;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f); // con il transfor possiamo sapere direttamente le dimensioni del groundCheck
    public LayerMask groundLayer; // maschera di livello, i livelli in unity si usano per le collisioni

    [Header("Components")]
    public Animator playerAnimator;  //peril passaggio dall'animazione  da idle a run
    public SpriteRenderer playerRenderer;






    float HorizontalMovement = 0;








    // update viene chiamato ad ogni frame, serve per il rendering
    // fixedUpdate serve per ciò che riguarda la fisica di gioco, unity ci gestisce la fisica li dentro, va a intervalli fissi e non ha bisogno di deltaTime essendo a intervalli fissi

    public void FixedUpdate()
    {
        body.linearVelocityX = HorizontalMovement * playerSpeed; // ora diamo al rigidbody una velocità che gestisce lui con la fisica di 10
        GroundCheck();
        SetGravity();  
    }


    public void Update()
    {
        playerAnimator.SetFloat("Xspeed", Mathf.Abs(body.linearVelocityX));  // a ogni frame nella variabile xspeed inserisce il valoreassoluto  attuale del giocatore
                                                                             // quando la velocità del giocatore è maggiore di 0 passa dall'animazione dell'aidle alla run    

        playerAnimator.SetFloat("Yspeed", body.linearVelocityY);   // non usiamo il valore assoluto perchè a noi importa sapere se il valore va in negativo o positivo

        if (Mathf.Abs( body.linearVelocityX) > 0.01f )
        {


            bool needFlip = body.linearVelocityX < 0;    // se la velocità è maggiore di 0 flippa a sinistra  la sprite del personaggio
            playerRenderer.flipX = needFlip;


        }





    }



    





    private void SetGravity()  //per incrementare la velocità quando scende
    {
        if(body.linearVelocityY < 0)
        {
            body.gravityScale = baseGravity * fallSpeedMultipler;
            body.linearVelocityY = Mathf.Max(body.linearVelocityY, -maxFallSpeed);
        }
        else
        {
            body.gravityScale = baseGravity;
        }
    }




    public void GroundCheck()  //per verificare che il groundcheck collida con la piattaforma
    {
       if(Physics2D.OverlapBox(groundCheckTransform.position, groundCheckSize, 0, groundLayer)) // ci permette di vedere che un punto collida con qualcosa,  e ci restituisce un collider2d che ci dice con cosa ha colliso
            isGrounded = true; // se collide con la pittaforma è a terra
       else
            isGrounded = false;  //  altrimenti non collide ed è in aria   
    
    }


    public void PlayerInput_Move(CallbackContext context)  
    {
        Debug.Log("MoveInput");

        HorizontalMovement = context.ReadValue<Vector2>().x;

    }

    public void PlayerInput_Jump(CallbackContext context) //per far saltare il player
    {
        if (isGrounded)
        {

            if (context.performed) //se la barra spaziatrice è premuta fa qualcosa
            {
                body.linearVelocityY = jumpForce; // ogni volta che premiamo la barra spaziatrice inserisce nella velocità Y inserisce la JumpForce
            }
          

        }

        if (context.canceled && body.linearVelocityY > 0) // se la barra spaziatrice è rilasciata fa altro, è fuori dall'if perchè in base a con che forza si preme la barra va più in alto anche in aria e non solo quando è a terra(dentro l'if) && e quando è in salita dimezza la velocità
        {
            body.linearVelocityY = body.linearVelocityY / 2; // per diminuire la velocità quando smettiamo di schiacciare la barra spaziatrice 
        }

    }


    public void OnDrawGizmos()  //gizmos sono tutti i simboli di unity
    {
        Gizmos.DrawCube(groundCheckTransform.position, groundCheckSize); 
    }








}
