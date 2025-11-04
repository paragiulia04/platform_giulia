using UnityEngine;

public class playerInventory : MonoBehaviour
{
    public CoinManager coinManager;


    int coins = 0; // soldi che fa il player


    public void AddCoins(int amount)  //amount dice quanti soldi aggiugere
    {
        coins += amount; // quando qualcuno chiama il metodo AddCoins aggiuge l'amount a i soldi che fa il giocatore

        coinManager.UpdateCoinUI(coins);   // ilgiocatore richiama il metodo


    }
}
