using UnityEngine;
using UnityEngine.UI;

public class ControladorFase : MonoBehaviour
{
    internal float TempoRestante;

    public GameObject telaGanhou, telaPerdeuErrou, telaPerdeuTempo, telaPause;

    public Image imagemTacaSelecionada;
    public Text TextoTempoRestante, textoFaseAtual;

    public Sprite[] bebidas;
    public string[] tipos;


    public GameObject personagem;
    public SpriteRenderer bebidaNaTela;

    internal int faseAtual, numBebidaAtual;
    internal string nomeBebidaAtual, nomeTacaAtual;
    internal Vector3 posInicialPersonagem;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInicialPersonagem = personagem.transform.localPosition;
        TempoRestante = 60;
        faseAtual = 1;
        nomeTacaAtual = "";
        EscolherUmaBebida();


        imagemTacaSelecionada.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        TempoRestante -= Time.deltaTime;

        TextoTempoRestante.text = "Tempo restante:" + TempoRestante.ToString("00");
        textoFaseAtual.text = "fase: " + faseAtual;


        if (TempoRestante <= 0)
        {
            telaPerdeuTempo.SetActive(true);
            Time.timeScale = 0;
            TempoRestante = 0;

        }





    }


    public void PegarTaca(GameObject taca)
    {
        imagemTacaSelecionada.sprite = taca.GetComponent<SpriteRenderer>().sprite;
        imagemTacaSelecionada.preserveAspect = true;
        nomeTacaAtual = taca.GetComponent<Controladortaca>().tipo;
    }


    public void Comparar()
    {
        if (nomeTacaAtual == nomeBebidaAtual)
        {
            telaGanhou.SetActive(true);
            Time.timeScale = 0;
        }
        else if (nomeTacaAtual != "")
        {
            telaPerdeuErrou.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void EscolherUmaBebida()
    {
        int valorAleatorio = (int)(Random.value * bebidas.Length);

        if (numBebidaAtual == valorAleatorio)
            valorAleatorio++;

        bebidaNaTela.sprite = bebidas[valorAleatorio];
        nomeBebidaAtual = tipos[valorAleatorio];

    }

    public void Pausar()
    {
        telaPause.SetActive(true);
        Time.timeScale = 0;

    }
    public void Despausar()
    {
        telaPause.SetActive(false);
        Time.timeScale = 1;

    }

    public void AvancarFase()
    {
        faseAtual += 1;

        personagem.transform.localPosition = posInicialPersonagem;
        TempoRestante += 10;

        nomeTacaAtual = "";
        EscolherUmaBebida();
        imagemTacaSelecionada.sprite = null;

        telaGanhou.SetActive(false);
        Time.timeScale = 1;



    }

    public void RecomecarFase()
    { 

        faseAtual = 1;

        personagem.transform.localPosition = posInicialPersonagem;
        TempoRestante = 60;

        nomeTacaAtual = "";
        EscolherUmaBebida();
    imagemTacaSelecionada.sprite = null;

        telaPerdeuErrou.SetActive(false);
        telaPerdeuTempo.SetActive(false);
        Time.timeScale = 1;
    }

}


   

   
   
