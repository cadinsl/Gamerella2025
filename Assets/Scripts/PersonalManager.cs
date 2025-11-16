using UnityEngine;
using UnityEngine.AI;
public class PersonalManager : MonoBehaviour
{

    public CharacterControl characterControl;
    public NavMeshAgent agent;
    public NPCWalker npcWalker;
    public GameObject[] hairs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        characterControl = GetComponent<CharacterControl>();
        npcWalker = GetComponent<NPCWalker>();
        npcWalker.enabled = true;
        characterControl.disableControl();
    }

    public void setHairs(int hairID)
    {
        hairs[hairID].SetActive(true);
    }

    public void enableControl()
    {
        agent.enabled = false;
        npcWalker.enabled = false;
        characterControl.enableControl();
    }

    public void enableNpc()
    {
        agent.enabled = true;
        npcWalker.enabled = true;
        characterControl.disableControl();
    }

}
