using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControl : MonoBehaviour
{
    public InputSystem inputSystem;
    public bool isActive = false;
    public float movementSpeed;
    private InputAction moveInput;
    private CharacterController characterController;
    private void Awake()
    {
        inputSystem = new InputSystem();
    }

    private void OnEnable()
    {
        moveInput = inputSystem.Player.Move;
        moveInput.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Vector3 move = new Vector3(moveInput.ReadValue<Vector2>().x, 0, moveInput.ReadValue<Vector2>().y);
            move = Vector3.ClampMagnitude(move, 1);
            characterController.SimpleMove(move * movementSpeed);
        }
    }

    public void enableControl()
    {
        isActive = true;
        characterController.enabled = true;
    }

    public void disableControl()
    {
        isActive = false;
        characterController.enabled = false;
    }
}
