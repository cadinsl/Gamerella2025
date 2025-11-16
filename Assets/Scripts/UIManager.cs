using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager audioManagerInstance;
    public AK.Wwise.Bank soundBank;
    public AK.Wwise.Event playHoverOn;
    public AK.Wwise.Event playHoverOff;
    public AK.Wwise.Event playToggleLeft;
    public AK.Wwise.Event playToggleRight;
    public AK.Wwise.Event playCreate;
    public AK.Wwise.Event playOverview;
    public AK.Wwise.Event playOverviewBack;


    public void Awake()
    {
        if (audioManagerInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            audioManagerInstance = this;
        }

        soundBank.Load();

    }

    void Start()
    {
        //    AkSoundEngine.PostEvent("Play_SFX_Debug", gameObject);
    }

    public void OnPointerEnterSound()
    {
        playHoverOn.Post(gameObject);
    }

    public void OnPointerExitSound()
    {
        playHoverOff.Post(gameObject);
    }

    public void ToggleLeft()
    {
        playToggleLeft.Post(gameObject);
    }

    public void ToggleRight()
    {
        playToggleRight.Post(gameObject);
    }

    public void Create()
    {
        playCreate.Post(gameObject);
    }

    public void Overview()
    {
        playOverview.Post(gameObject);
    }

    public void OverviewBack()
    {
        playOverviewBack.Post(gameObject);
    }
}
