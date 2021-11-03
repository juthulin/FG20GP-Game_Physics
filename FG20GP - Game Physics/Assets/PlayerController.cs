using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private int movementAcceleration = 10;
    [SerializeField] private int jumpAcceleration = 10;
    
    private Rigidbody2D rb;
    private bool moveRight = false;
    private bool moveLeft = false;
    private bool _jump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveRight = Input.GetKey(KeyCode.D);
        moveLeft = Input.GetKey(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.Space)) _jump = true;
    }

    private void FixedUpdate()
    {
        float x = ((movementAcceleration * rb.mass) * Convert.ToInt16(moveRight)) + ((-movementAcceleration * rb.mass) * Convert.ToInt16(moveLeft));
        
        rb.AddForce(new Vector2(x, 0f));

        if (_jump)
        {
            _jump = false;
            rb.AddForce(new Vector2(0f, jumpAcceleration * rb.mass), ForceMode2D.Impulse);
        }
    }
}
