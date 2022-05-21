using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyAi check = gameObject.GetComponent<EnemyAi>();
        if (check)
            check.player = GameObject.FindGameObjectWithTag("sled");
        else
            gameObject.GetComponent<EnemyShooting>().player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

 
}
