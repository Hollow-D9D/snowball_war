using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SledMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject dest;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = dest.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
