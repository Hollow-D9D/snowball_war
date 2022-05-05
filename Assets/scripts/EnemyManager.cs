using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyArr;
    // Start is called before the first frame update
    void Start()
    {
        // Fill the array with the existing enemy members;
        enemyArr = GameObject.FindGameObjectsWithTag("enemy");
    }

    //Get the closest at the moment
    public GameObject getClosest(Vector3 position)
    {
        GameObject closest = null;
        for (int i = 0; i < enemyArr.Length; i++)
        {
            if (!closest)
            {
                closest = enemyArr[i++];
                continue;
            }
            if (!enemyArr[i])
            {
                enemyArr = GameObject.FindGameObjectsWithTag("enemy");
                return (getClosest(position));
            }
            if (Vector3.Distance(position, enemyArr[i].transform.position) < Vector3.Distance(position, closest.transform.position))
                    closest = enemyArr[i];
            i++;
        }
        return closest;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
