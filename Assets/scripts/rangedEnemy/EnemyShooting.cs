using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Some Variable for snowball")]
    [SerializeField] private GameObject projectile;

    [Header("Cooldown for shooting")]
    public bool isAvailable = true;
    [SerializeField] private float CooldownDuration = 0.5f;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvailable)
        {
           
                Vector3 shootDir = player.transform.position - transform.position;

                /* Summoning Snowball. */
                GameObject Snowball = Instantiate(projectile, transform.position, transform.rotation);
                Snowball.transform.tag = "EnemySpawned";
                Snowball.GetComponent<ProjectileMovement>().Setup(shootDir.normalized);

                /* Cooldown Coroutine */
                StartCoroutine(StartCooldown());
        }
    }

    public IEnumerator StartCooldown()
    {
        isAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        isAvailable = true;
    }
}
