using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class randomWalk : MonoBehaviour
{
    public float L_Range = 25.0f;
    NavMeshAgent L_agent;

    // Start is called before the first frame update
    void Start()
    {
        L_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (L_agent.pathPending || L_agent.remainingDistance > 0.1f)
            return;

        Vector2 randomPos = Random.insideUnitCircle;
        L_agent.destination = L_Range * new Vector3(randomPos.x, 0, randomPos.y);
    }
}
