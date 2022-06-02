using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static ArrayList enemyArr;
    // Start is called before the first frame update
    void Start()
    {
        // Fill the array with the existing enemy members;
    }

    public void setup()
    {
        enemyArr = new ArrayList(GameObject.FindGameObjectsWithTag("enemy"));

    }

    //Get the closest at the moment
    public GameObject getClosest(Vector3 position)
    {
        GameObject closest = null;
        if(enemyArr != null)
        { 
            foreach (GameObject obj in enemyArr)
            {
                //if (obj == null)
                  //  enemyArr.Remove(obj);
                if (!closest)
                {
                    closest = obj;
                    continue;
                }
                if (Vector3.Distance(position, obj.transform.position) < Vector3.Distance(position, closest.transform.position))
                        closest = obj;
            }
        }
        return closest;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
