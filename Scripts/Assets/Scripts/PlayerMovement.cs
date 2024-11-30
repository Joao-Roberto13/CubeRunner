using UnityEngine;
using UnityEngine.UI; // Para manipular elementos de UI
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 50f;         // Velocidade para movimento lateral
    public float jump = 5f;           // Força do salto
    public float jumpTime = 5f;       // Tempo de cooldown do salto
    public float fowardForce = 1000f; // Força para mover para frente
    public float sidewaysForce = 500f; // Força para mover para os lados
    private bool isGrounded = true;   // Verifica se está no chão

    public Text countdownText;        // Texto para exibir a contagem regressiva
    public Image jumpImage;           // Imagem para indicar que o salto está disponível

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countdownText.text = ""; // Oculta a contagem no início
        jumpImage.enabled = true; // Exibe a imagem de salto no início
    }

    void FixedUpdate()
    {
        // Movimento para frente
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        // Movimento lateral
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 joystickMovement = new Vector3(horizontal * speed, 0, 0) * Time.deltaTime;
        rb.AddForce(joystickMovement, ForceMode.VelocityChange);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(0, jump, 0, ForceMode.Impulse);
            isGrounded = false; // Impede outro salto
            jumpImage.enabled = false; // Desabilita a imagem de salto
            StartCoroutine(EnableJumpAfterDelay(jumpTime));
        }

        if (Input.GetButtonDown("Reset"))
            FindObjectOfType<GameManager>().EndGame();

        // Verifica se o jogador caiu
        if (rb.position.y <= -10f || Input.GetKey("r"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private IEnumerator EnableJumpAfterDelay(float delay)
    {
        // Contagem regressiva
        for (float timeLeft = delay; timeLeft > 0; timeLeft -= 1)
        {
            countdownText.text = $"{Mathf.Ceil(timeLeft)}"; // Mostra a contagem regressiva
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = ""; // Limpa o texto
        jumpImage.enabled = true; // Reabilita a imagem de salto
        isGrounded = true;       // Permite o próximo salto
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Ground"))
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
