using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuPrinciparManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevel;
    [SerializeField] private GameObject painelDoMenuInicial;
    [SerializeField] private GameObject painelDeOpcoes;
    public Text loadingText;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevel);
    }

    public void abrirOpcoes()
    {
        painelDoMenuInicial.SetActive(false);
        painelDeOpcoes.SetActive(true);
    }
    public void fecharOpcoes()
    {
        painelDeOpcoes.SetActive(false);
        painelDoMenuInicial.SetActive(true);        
    }

    public void sairJogor()
    {
        Debug.Log("Jogo encerrado!");
        Application.Quit();
    }
}

