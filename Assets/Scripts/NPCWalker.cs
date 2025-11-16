using UnityEngine;
using UnityEngine.AI;

public class NPCWalker : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private bool _isStopTimerActive;
    [SerializeField] private bool _isWalkTimerActive;

    [SerializeField] private float _stopCurrentTime;
    [SerializeField] private float _walkCurrentTime;

    [SerializeField] private float stopTimerTime = 3;
    [SerializeField] private float walkTimerTime = 10;

    private float stopTimerTimeMax = 10;
    private float walkTimerTimeMax = 40;
    private float stopTimerTimeMin = 3;
    private float walkTimerTimeMin = 15;


    [SerializeField] private Transform currentDestinationPoint;

    public float stoppingThreshold = 0.5f; // Adjust this value as needed

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentDestinationPoint = WalkerGlobal.Instance.getRandomDestinationPoint();
        agent.SetDestination(currentDestinationPoint.position);
        startWalkTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStopTimerActive)
        {
            _stopCurrentTime -= Time.deltaTime;
            if(_stopCurrentTime <= 0)
            {
                stopTimerEnd();
                endStopTimer();
            }
        }

        if (_isWalkTimerActive)
        {
            _walkCurrentTime -= Time.deltaTime;

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + stoppingThreshold)
            {
                currentDestinationPoint = WalkerGlobal.Instance.getRandomDestinationPoint();
                agent.SetDestination(currentDestinationPoint.position);

            }

            if (_walkCurrentTime <= 0)
            {
                walkTimerEnd();
                endWalkTimer();
            }
        }
    }

    public void walkTimerEnd()
    {
        agent.isStopped = true;
        startStopTimer();
    }

    public void stopTimerEnd()
    {
        currentDestinationPoint = WalkerGlobal.Instance.getRandomDestinationPoint();
        agent.SetDestination(currentDestinationPoint.position);
        agent.isStopped = false;
        startWalkTimer();
    }

    public void startStopTimer()
    {
        stopTimerTime = Random.Range(stopTimerTimeMin, stopTimerTimeMax);
        _stopCurrentTime = stopTimerTime;
        _isStopTimerActive = true;
    }

    public void startWalkTimer()
    {
        walkTimerTime = Random.Range(walkTimerTimeMin, walkTimerTimeMax);
        _walkCurrentTime = walkTimerTime;
        _isWalkTimerActive = true;
    }

    public void endStopTimer()
    {
        _isStopTimerActive = false;
    }

    public void endWalkTimer()
    {
        _isWalkTimerActive = false;
    }

}
