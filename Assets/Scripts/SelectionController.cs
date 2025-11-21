using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionController : MonoBehaviour
{
	public InputSystem inputSystem;
	private InputAction actionInput;
    public Camera camera;
    public PersonalManager currentMiiManager;
    public bool isActive = true;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

	private void Awake()
	{
		inputSystem = new InputSystem();
	}

	private void OnEnable()
	{
		actionInput = inputSystem.Player.Click;
		actionInput.Enable();
		actionInput.performed += Fire;
	}

    private void OnDisable()
    {
        if (currentMiiManager != null)
        {
            currentMiiManager.disableHover();
            currentMiiManager = null;
        }
    }

    // Update is called once per frame
    public void enableSelectionController()
    {
        currentMiiManager.enableNpc();
        isActive = true;
        currentMiiManager = null;
        GameManager.Instance.goToOverview();
    }

    private void Update()
    {
        if (isActive)
        {
            handleHoverEffect();
        }
    }

    private void handleHoverEffect()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hitInfo);
        if (hit)
        {
            if (hitInfo.transform.gameObject.tag == "Mii")
            {
                PersonalManager personalManager = hitInfo.transform.gameObject.GetComponent<PersonalManager>();
                if (personalManager != currentMiiManager && currentMiiManager != null)
                {
                    currentMiiManager.disableHover();
                }
                currentMiiManager = personalManager;
                currentMiiManager.enableHover();
            }
            else
            {
                if (currentMiiManager != null)
                {
                    currentMiiManager.disableHover();
                    currentMiiManager = null;
                }
            }
        }
        else
        {
            if (currentMiiManager != null)
            {
                currentMiiManager.disableHover();
                currentMiiManager = null;
            }
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        if(!isActive)
        {
            return;
        }
        //Debug.Log("CLICK");
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hitInfo);
        if (hit)
        {
            Debug.Log("Hit " + hitInfo.transform.gameObject.name);
            if (hitInfo.transform.gameObject.tag == "Mii")
            {
                currentMiiManager = hitInfo.transform.gameObject.GetComponent<PersonalManager>();
                currentMiiManager.enableControl();
                isActive = false;
                GameManager.Instance.goToControl(currentMiiManager.gameObject);
            }
        }
    }
}
