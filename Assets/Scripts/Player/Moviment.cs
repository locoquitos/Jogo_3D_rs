using UnityEngine;

public class Moviment : MonoBehaviour
{
    public float speed = 5f;
    public float Fulo = 7f;

    private bool IsGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        Vector3 position = new Vector3(Horizontal, 0f, Vertical).normalized; //normalized mantem a velocidade constante

        rb.linearVelocity = new Vector3( //move o objeto e mantem a gravidade 
            position.x * speed,
            rb.linearVelocity.y,
            position.z * speed
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded) // se apertar espaço e estiver no chao vai pular
        {
            rb.AddForce(Vector3.up * Fulo, ForceMode.Impulse);

            IsGrounded = false;
        }
    }

    void OnCollisionStay(Collision collision) //verifica se o colisor esta no chao
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision) //outra verificaçao de garantia
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }
}
