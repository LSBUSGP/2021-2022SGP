using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilTank : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public float Distance;

    public bool isAngnfry;

    public NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if (Distance <= 5)
        {
            isAngnfry = true;
        }
        if (Distance > 5f)
        {
            isAngnfry = false;
        }

        if (isAngnfry)
        {
            _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);
        }
        if (!isAngnfry)
        {
            _agent.isStopped = true;
        }
    }
}