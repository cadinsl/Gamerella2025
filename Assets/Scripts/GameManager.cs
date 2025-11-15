using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private GameObject CustomizationUI;
    [SerializeField] private GameObject CustomizationObject;
    [SerializeField] private GameObject OverviewUI;
    [SerializeField] private GameObject OverviewCamera;
    [SerializeField] private GameObject CustomizationCamera;

    public void goToOverview()
    {
        CustomizationUI.SetActive(false);
        CustomizationObject.SetActive(false);
        OverviewUI.SetActive(true);
        OverviewCamera.SetActive(true);
        CustomizationCamera.SetActive(false);
    }

    public void goToCustomization()
    {
        CustomizationUI.SetActive(true);
        CustomizationObject.SetActive(true);
        OverviewUI.SetActive(false);
        OverviewCamera.SetActive(false);
        CustomizationCamera.SetActive(true);
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
