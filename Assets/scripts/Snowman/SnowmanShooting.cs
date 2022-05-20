using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanShooting : MonoBehaviour
{
    [Header("Some Variable for snowball")]
    [SerializeField] private GameObject projectile;

    [Header("for Auto Target")]
    [SerializeField] private EnemyManager enemy;

    [Header("Cooldown for shooting")]
    public bool isAvailable = true;
    [SerializeField] private float CooldownDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAvailable)
        {
            GameObject closest = enemy.getClosest(transform.position);
            if (closest)
            {
                Vector3 shootDir = closest.transform.position - transform.position;

                /* Summoning Snowball. */
                GameObject Snowball = Instantiate(projectile, transform.position, transform.rotation);
                Snowball.transform.tag = "PlayerSpawned";
                Snowball.GetComponent<ProjectileMovement>().Setup(shootDir.normalized);

                /* Cooldown Coroutine */
                StartCoroutine(StartCooldown());
            }
        }
    }
    public IEnumerator StartCooldown()
    {
        isAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        isAvailable = true;
    }
}
