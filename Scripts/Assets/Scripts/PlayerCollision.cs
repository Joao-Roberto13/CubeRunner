using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public float leftMotorSpeed = 0.5f;
    public float rightMotorSpeed = 0.5f;
    public float duration = 1.0f;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Será chamado quando o jogador colidir...
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle") 
        {
            audioManager.Stop();
            
            // Verifica se o gamepad está conectado
            if (Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(leftMotorSpeed, rightMotorSpeed);
            } else Debug.Log("Nenhum GamePad Conectado");
            
            audioManager.PlaySFX(audioManager.death);
            movement.enabled = false;
            Invoke("StopVibration", duration);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void StopVibration()
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(0, 0);
        }
    }
}
