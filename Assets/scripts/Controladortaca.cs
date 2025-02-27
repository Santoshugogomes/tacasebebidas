using UnityEngine;

public class Controladortaca : MonoBehaviour
{
    public string tipo;
    public ControladorFase geral;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "player")
        {
            geral.PegarTaca(gameObject);
            
            Debug.Log(tipo);
        }
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
