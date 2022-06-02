using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    private bool isAvailable;
    [SerializeField] private int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        isAvailable = true;
    }

    private void OnTriggerStay (Collider collision)
    {
        if (collision.gameObject.tag == "sled" && isAvailable)
        {
            collision.gameObject.GetComponent<Health>().Damage(damage);
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
