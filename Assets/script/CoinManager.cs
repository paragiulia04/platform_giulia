using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public TextMeshProUGUI coinText; //riferimento per il cointext a schermo
    

    public void UpdateCoinUI(int coin) //ci passa dentro i soldi che abbiamo, il metodosi occupa di aggiornare i soldi che passiamo
    {
        coinText.text = coin.ToString();  //converte i soldi in stringa al contatore sullo schermo
    }


    


}
