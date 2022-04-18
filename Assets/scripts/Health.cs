using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public static Health health;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score= 100;
    }

    // Update is called once per frame



    public void Damege(int a)
    {

        score -= a;
        Debug.Log(score);
    }
}
