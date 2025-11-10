using UnityEngine;

public class KEY : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)  // per avvisare quando entra in contatto con il trigger
    {


        if (collision.CompareTag("Player"))  //  comparetag = se entra in contatto con il tag ad esempio player fa quello che c'è scritto nel if
        {
            playerInventory Inventory = collision.gameObject.GetComponent<playerInventory>();
            Inventory.TakeKey();
            Destroy(gameObject);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }




}