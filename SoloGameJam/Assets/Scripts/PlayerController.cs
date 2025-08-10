using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Vector2 inputVector;
    [SerializeField] Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputVector.x * speed * Time.deltaTime, inputVector.y * speed * Time.deltaTime);
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
