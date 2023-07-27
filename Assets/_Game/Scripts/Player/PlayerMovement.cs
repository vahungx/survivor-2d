using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    [HideInInspector] public Vector2 moveDirection;

    [HideInInspector] public float lastHorizontal;
    [HideInInspector] public float lastVertical;
    // Start is called before the first frame update
    #region Singleton
    public static PlayerMovement instance;
    private void Awake()
    {
        if (instance == null) instance = this; 
        else Destroy(instance);
    }
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagment();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void InputManagment()
    {
        // cái này cần chỉnh lại để điều khiển joystick

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection.x != 0)
        {
            lastHorizontal = moveDirection.x;
        }
        else if (moveDirection.y != 0)
        {
            lastVertical = moveDirection.y;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
