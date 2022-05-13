using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    //private Health health;
    public NavMeshAgent agent;
    public GameObject player;
    float score = 100;

    //public bool ismot = true;
    void Start()
    {
       // Health health = new Health();
        //player = GameObject.Find("FPSController");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
       /* if (Vector3.Distance(transform.position, player.transform.position) < 10f)
        {
            Damage(5);    
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            Damage(10);
            Debug.Log("Yellow");
        }*/
        if (score <= 0)
        {
            score = 0;
            EnemyManager.enemyArr.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
    /* Damage part is done via snowball */
    public void Damage(int a) 
    { 
        score -= a;
       
        Debug.Log(a);
        DamagePopup.Create(transform.position, a);
    }
}

