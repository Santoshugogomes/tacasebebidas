using UnityEngine;

public class ControladoreGarrafa : MonoBehaviour
{

    public ControladorFase geral;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
            geral.Comparar();

    }


}
        
