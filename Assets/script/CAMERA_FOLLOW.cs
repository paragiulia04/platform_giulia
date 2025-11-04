using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("settings")]   //header sono dei titoli che si usano per fare ordine nel codice e su unity (se inserita come public), tra virgolette mettiamo il titolo che vogliamo dargli.

    public Vector3 followOffest;  // per spostare l'offset della camera  (se magari segue il giocatore più da destra, sopra, sotto o come voglia io)

    public float smoothSpeed = 0.2f;





    [Header("components")]
    public Transform playerTransform;

    // vector sono i valori, con vector vorrò solo 1 valore, con vector2 mi servono 2 valori e con vector3 avrò tutti e tre i valori x,y,z.

    float zPosition;  //posizione della camera
    Vector3 currentVelocity = Vector3.zero;


    private void Awake()
    {
        zPosition = transform.position.z;   // nella variabile zPosiition viene salvata la posizione all'avvio
    }

    public void LateUpdate()   // per far seguire la camera al giocatore   
    {
        Vector3 targetPosition = playerTransform.position + followOffest;
        targetPosition.z = zPosition;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothSpeed);
    }                                  //transform.position è la posizione attuale


     //mettiamo lateUpdate al posto di Update perchè sennò con fixed e update non vengono coincise le tempistiche, ed evita di are andare il player a scatti
}
