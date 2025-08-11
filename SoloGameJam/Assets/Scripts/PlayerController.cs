using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public float speed;


    private Vector2 inputVector;
    private Vector2 mousePos;
    [SerializeField] Rigidbody2D rb;
    //[SerializeField] Rigidbody2D swordRb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //swordRb = GetComponentInChildren<Rigidbody2D>();
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime); //player movement

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        inputVector.Normalize();
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Attack" + context.phase);
        }

    }
    
}
