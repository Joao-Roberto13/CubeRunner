using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private Rigidbody rb; // Referência ao Rigidbody
    public float speed = 50f; // Velocidade do movimento
    public Material BlackMaterial;
    public Material BlueMaterial;
    public Material GreenMaterial;
    public Material PinkMaterial;
    public Material RedMaterial;
    public Material WhiteMaterial;
    public Material YellowMaterial;
    public Button button;
    public GameObject PausePanel;


    void Awake()  // Alteração de Start() para Awake() para garantir inicialização imediata
    {
        rb = GetComponent<Rigidbody>();

        actions.Add("right", MoveRight);
        actions.Add("left", MoveLeft);
        actions.Add("up", MoveUp);
        actions.Add("jump", MoveUp);
        actions.Add("pause", pause);
        actions.Add("reset", resetG);

        // Comandos para mudar cores
        actions.Add("black", SetBlackColor);
        actions.Add("blue", SetBlueColor);
        actions.Add("green", SetGreenColor);
        actions.Add("pink", SetPinkColor);
        actions.Add("red", SetRedColor);
        actions.Add("white", SetWhiteColor);
        actions.Add("yellow", SetYellowColor);

        // Configura o KeywordRecognizer com as palavras do dicionário
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        // Adiciona logs de depuração para confirmar inicialização
        Debug.Log("Tentando iniciar reconhecimento de voz...");
        try
        {
            keywordRecognizer.Start();
            Debug.Log("Reconhecimento de voz iniciado com sucesso.");
        }
        catch (Exception e)
        {
            Debug.LogError("Erro ao iniciar o reconhecimento de voz: " + e.Message);
        }

    }

    public void resetG()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

    private void pause(){
        Debug.Log("Jogo Pausado");
        PausePanel.SetActive(true);  // Ativa o painel de pausa 
        button.gameObject.SetActive(false);    //Para desativar o botão de pause
        Time.timeScale = 0f;         // Pausa o tempo do jogo
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log($"Comando reconhecido: {speech.text}");
        if (actions.ContainsKey(speech.text))
        {
            actions[speech.text].Invoke();  // Executa a ação associada
        }
    }

    private void MoveRight()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
    }

    private void MoveLeft()
    {
        rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
    }

    private void MoveUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, speed, rb.velocity.z);
    }

    private void SetBlackColor() { GetComponent<Renderer>().material = BlackMaterial; }
    private void SetBlueColor() { GetComponent<Renderer>().material = BlueMaterial; }
    private void SetGreenColor() { GetComponent<Renderer>().material = GreenMaterial; }
    private void SetPinkColor() { GetComponent<Renderer>().material = PinkMaterial; }
    private void SetRedColor() { GetComponent<Renderer>().material = RedMaterial; }
    private void SetWhiteColor() { GetComponent<Renderer>().material = WhiteMaterial; }
    private void SetYellowColor() { GetComponent<Renderer>().material = YellowMaterial; }

    private void OnDestroy()
    {
        // Limpeza quando o objeto é destruído
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }
}


/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private Rigidbody rb; // Referência ao Rigidbody
    public float speed = 5f; // Velocidade do movimento
    public Material BlackMaterial;
    public Material BlueMaterial;
    public Material GreenMaterial;
    public Material PinkMaterial;
    public Material RedMaterial;
    public Material WhiteMaterial;
    public Material YellowMaterial;

    void Start()
    {
        // Obtém o componente Rigidbody do GameObject
        rb = GetComponent<Rigidbody>();

        // Cria um dicionário com as palavras e ações associadas
        actions.Add("right", MoveRight);
        actions.Add("left", MoveLeft);
        actions.Add("up", MoveUp);
        actions.Add("jump", MoveUp);
        

        // Adiciona comandos para mudar as cores
        actions.Add("black", SetBlackColor);
        actions.Add("blue", SetBlueColor);
        actions.Add("green", SetGreenColor);
        actions.Add("pink", SetPinkColor);
        actions.Add("red", SetRedColor);
        actions.Add("white", SetWhiteColor);
        actions.Add("yellow", SetYellowColor);

        // Configura o KeywordRecognizer com as palavras do dicionário
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log($"Recognized command: {speech.text}");
        actions[speech.text].Invoke();  // Executa a ação associada ao comando de voz
    }

    private void MoveRight()
    {
        // Aplica uma força suave para a direita
        rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
    }

    private void MoveLeft()
    {
        // Aplica uma força suave para a esquerda
        rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
    }

    private void MoveUp()
    {
        // Aplica uma força para cima, definindo a velocidade no eixo Y
        rb.velocity = new Vector3(rb.velocity.x, speed, rb.velocity.z);
    }

    // Métodos para mudar as cores
    private void SetBlackColor(){
        GetComponent<Renderer>().material = BlackMaterial;
    }
    private void SetBlueColor(){
        GetComponent<Renderer>().material = BlueMaterial;
    }
    private void SetGreenColor(){
        GetComponent<Renderer>().material = GreenMaterial;
    }
    private void SetPinkColor(){
        GetComponent<Renderer>().material = PinkMaterial;
    }
    private void SetRedColor(){
        GetComponent<Renderer>().material = RedMaterial;
    }
    private void SetWhiteColor(){
        GetComponent<Renderer>().material = WhiteMaterial;
    }
    private void SetYellowColor(){
        GetComponent<Renderer>().material = YellowMaterial;
    }
}*/

