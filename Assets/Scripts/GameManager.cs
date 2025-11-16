using UnityEngine;
using Unity.Cinemachine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private GameObject CustomizationUI;
    [SerializeField] private GameObject CustomizationObject;
    [SerializeField] private GameObject OverviewUI;
    [SerializeField] private GameObject ControlUI;
    [SerializeField] private GameObject OverviewCamera;
    [SerializeField] private GameObject CustomizationCamera;
    [SerializeField] private GameObject ControlCamera;
    [SerializeField] private GameObject SelectionController;

    public void goToOverview()
    {
        CustomizationUI.SetActive(false);
        CustomizationObject.SetActive(false);
        OverviewUI.SetActive(true);
        OverviewCamera.SetActive(true);
        CustomizationCamera.SetActive(false);
        ControlCamera.SetActive(false);
        ControlUI.SetActive(false);
        SelectionController.SetActive(true);
        SelectionController.GetComponent<SelectionController>().isActive = true;
        Camera.main.orthographic = false;
    }

    public void goToCustomization()
    {
        CustomizationUI.SetActive(true);
        CustomizationObject.SetActive(true);
        OverviewUI.SetActive(false);
        OverviewCamera.SetActive(false);
        CustomizationCamera.SetActive(true);
        SelectionController.GetComponent<SelectionController>().isActive = false;
        SelectionController.SetActive(false);
    }

    public void goToControl(GameObject character)
    {
        OverviewUI.SetActive(false);
        OverviewCamera.SetActive(false);
        ControlUI.SetActive(true);
        ControlCamera.SetActive(true);
        OverviewCamera.SetActive(false);
        SelectionController.SetActive(false);
        SelectionController.GetComponent<SelectionController>().isActive = false;
        ControlCamera.GetComponent<CinemachineCamera>().Follow = character.transform;
        Camera.main.orthographic = true;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
