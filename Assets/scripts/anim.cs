using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    private Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))

        {
            Debug.Log("anim");
            bool info = animation.GetBool("run");
            if (info != true)
            {
                animation.SetBool("run", true);

            }
            else
            
            {

                animation.SetBool("run", false);
            
            
            }
        }
    }
}
