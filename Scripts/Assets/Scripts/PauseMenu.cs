using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Pause")) // Verifica se o botao pause foi pressionado, sendo que foi configurado no input system..
        {
            Debug.Log("ESC Pressionado");
            Debug.Log($"{Time.timeScale}");
            if (Time.timeScale == 1) //jogo nao esta pausado...
                Pause();
            else
                Continue();
        }

    }

    public void Pause()
    {
        Debug.Log("Jogo Pausado");
        PausePanel.SetActive(true);  // Ativa o painel de pausa 
        //button.gameObject.SetActive(false);    //Para desativar o botão de pause
        Time.timeScale = 0;         // Pausa o tempo do jogo
    }

    public void Continue()
    {
        Debug.Log("Jogo Retomado");
        PausePanel.SetActive(false); // Desativa o painel de pausa
        //button.gameObject.SetActive(true);    //Para ativar o botão de pause
        Time.timeScale = 1;         // Retoma o tempo do jogo
    }
    public void sairJogor(string sceneName)
    {
        Debug.Log("Menu Principal!");
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;         // Retoma o tempo do jogo
    }

}
