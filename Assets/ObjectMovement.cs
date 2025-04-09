using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float raycastDistance = 1f;
    public float force = 100f;
    public float jumpForce = 150f;
    private Rigidbody rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.left * force); // Двигаемся по оси Х вниз
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.right * force); // Двигаемся по оси Х вверх
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.back * force); // Двигаемся по оси Z вниз
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.forward * force); // Двигаемся по оси Z вверх
        }

        // Проверяем, стоит ли объект на земле
        isGrounded = IsGrounded();

        // Если нажата клавиша пробела и объект стоит на земле, то подбрасываем его вверх
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    bool IsGrounded()
    {
        // Проверяем, есть ли что-то под объектом на расстоянии raycastDistance
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
    }
}
