using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SledMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public NavMeshAgent agent;
    public GameObject dest;
    private bool destReached;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        destReached = false;
        rb = GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
       // agent.destination = dest.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dest == null && EnemyManager.enemyArr.Count == 0)
            StartCoroutine(move());

        if (!destReached)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    private IEnumerator move()
    {
        yield return new WaitForSeconds(1);
        startMovement();
    }

    private void    startMovement()
    {
        dest = GameObject.FindGameObjectWithTag("HalfWay");
        destReached = false;
        rb.isKinematic = false;
    }

    private void preventMovement()
    {
        destReached = true;

        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("mta");
        if (other.gameObject.tag == "HalfWay")
            preventMovement();
    }
}
