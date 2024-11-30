using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public float scoreMultiplier = 0.5f; // Fator para desacelerar a pontuação

    void Update()
    {
        // Reduz o ritmo dividindo por um multiplicador
        float score = player.position.z * scoreMultiplier; //divide pela metade
        scoreText.text = score.ToString("0");
    }
}
