using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AK.Wwise.Event footstepSound;
    public void playFootsteps()
    {
        AkUnitySoundEngine.PostEvent(footstepSound.Id, this.gameObject);
    }
}
