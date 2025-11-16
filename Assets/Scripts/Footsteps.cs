using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AK.Wwise.Event footstepSound;
    public bool isActive = false;
    public void playFootsteps()
    {
        if (isActive)
        {
            AkUnitySoundEngine.PostEvent(footstepSound.Id, this.gameObject);
        }
    }
}
