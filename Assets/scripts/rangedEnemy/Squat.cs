using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squat : MonoBehaviour
{
    private bool squatTimer;
    public float CooldownDuration;
    // Start is called before the first frame update
    void Start()
    {
        squatTimer = false;
        InvokeRepeating("squat", CooldownDuration, CooldownDuration);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        if (squatTimer)
            scale.y = 1;
        else
            scale.y = 2;
        transform.localScale = scale;
    }

    public void squat()
    {
        squatTimer = !squatTimer;
    }
}


