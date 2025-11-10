using UnityEngine;

public class SCRIGNO : MonoBehaviour
{                                             //abbiamo incollato lo script della chiave

    private void OnTriggerEnter2D(Collider2D collision)  // per avvisare quando entra in contatto con il trigger
    {


        if (collision.CompareTag("Player"))  //  comparetag = se entra in contatto con il tag ad esempio player fa quello che c'è scritto nel if
        {
            playerInventory Inventory = collision.gameObject.GetComponent<playerInventory>();
            if (Inventory.HasKey())
                Debug.Log("aperto!");
            else
                Debug.Log("non hai la chiave!");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
