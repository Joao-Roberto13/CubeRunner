using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Level2")//para terminar no level 2 ee voltar ao menu principal...
        {
            Debug.Log("END OF THE GAME");
            SceneManager.LoadScene("Menu");
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
