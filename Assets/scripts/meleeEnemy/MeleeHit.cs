using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    private bool isAvailable;
    // Start is called before the first frame update
    void Start()
    {
        isAvailable = true;
    }

    private void OnTriggerStay (Collider collision)
    {
        if (collision.gameObject.tag == "sled" && isAvailable)
        {
        Debug.Log("Mta");
            collision.gameObject.GetComponent<Health>().Damage(20);
            StartCoroutine(hitCooldown());
        }
    }

    public IEnumerator hitCooldown()
    {
        isAvailable = false;
        yield return new WaitForSeconds(3);
        isAvailable = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
