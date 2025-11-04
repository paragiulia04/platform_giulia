using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)  // per avvisare quando entra in contatto con il trigger
    {
        

        if (collision.CompareTag("Player"))  //  comparetag = se entra in contatto con il tag ad esempio player fa quello che c'è scritto nel if
        {

           playerInventory inventory = collision.gameObject.GetComponent<playerInventory>(); //gameobject è il playere getcomponent dice quale componente prendere e lo prende dallo scriptplayerInventory
            inventory.AddCoins(1);  //aggiuge 1 moneta al inventario del coin


            Destroy(gameObject);  //serve per far sparire la moneta, quando l'aggiuge al conteggio e poi la distrugge
           

        }
    }


















}