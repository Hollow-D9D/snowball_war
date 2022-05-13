using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Vector3 startScale;
    private Vector3 targetScale;
    float t = 0;
    private float shrinkDuration = 2f;
    private Vector3 pushDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        t += Time.deltaTime / shrinkDuration;
        transform.localScale = Vector3.Lerp(startScale, targetScale, t);
        if (t > 1)
            Destroy(gameObject);
    }

    public void Setup(Vector3 shootDir)
    {
        /* making snowball smaller */
        startScale = transform.localScale;
        targetScale = new Vector3(0, 0, 0);
        
        /* Giving snowball direction and speed */
        Rigidbody Rbody = GetComponent<Rigidbody>();
        float moveSpeed = 20f;
        pushDir = shootDir;
        Rbody.AddForce(shootDir * moveSpeed, ForceMode.Impulse); 
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyAi target = other.GetComponent<EnemyAi>();
        if (target != null)
        {
            Rigidbody ri = other.GetComponent<Rigidbody>();
            ri.AddForce(pushDir * 2, ForceMode.Impulse);
           // Debug.Log("Valod" + transform.localScale.z * 50f);
            target.Damage((int)(transform.localScale.z * 50f));
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
