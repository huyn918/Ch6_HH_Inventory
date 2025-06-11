using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float maxSpeed;
    [SerializeField]
    public float jumpPower;

    
    private Rigidbody2D player_Rigidbody;
    private Collider2D player_Collider;
    private Vector2 moveInput;

    private bool isInventoryOpened;
    [SerializeField]
    public GameObject InventoryCanvas;


    private void Start()
    {
        InventoryCanvas.SetActive(false);
    }

    public void OnInventoryButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isInventoryOpened)
        {
            InventoryCanvas.SetActive(false);
            isInventoryOpened = !isInventoryOpened;
        }
        else if (context.phase == InputActionPhase.Started && !isInventoryOpened)
        {
            InventoryCanvas.SetActive(true);
            isInventoryOpened = !isInventoryOpened;
        }
    }

    private void Awake()
    {
        player_Collider = GetComponent<Collider2D>();
        player_Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(moveInput != Vector2.zero)
    {
            player_Rigidbody.velocity = new Vector2(moveInput.x * speed, player_Rigidbody.velocity.y);
        }
    else
        {
            player_Rigidbody.velocity = new Vector2(0f, player_Rigidbody.velocity.y);
        }
    }
}
