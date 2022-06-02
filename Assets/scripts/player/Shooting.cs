using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [Header("for Auto Target")]
    [SerializeField] private EnemyManager enemy;
    [SerializeField] private float range;


    [Header("Some Variable for snowball")]
    [SerializeField] private GameObject projectile;

    [Header("Cooldown for shooting")]
    private bool isAvailable = true;
    [SerializeField] private float CooldownDuration = 0.5f;

    [Header("UI related to Ammo")]
    [SerializeField] private Slider ammoIndicator;
    [SerializeField] private Image reloadCircle;

    [Header("Ammo Reload and stuff")]
    [SerializeField] private int ammo;
    private int ammoCount;

    [SerializeField] private float reloadTime;
    private bool canReload;
    private float reloadTimer;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = ammo;
        canReload = false;
    }

    // Update is called once per frame
    void Update()
    {
        ammoIndicator.value = ammoCount;
        reloadCircle.fillAmount = reloadTimer / reloadTime;
        /* Reloading */
        if (!canReload)
            reloadTimer = 0f;
        else
            reloadTimer += Time.deltaTime;
        if (reloadTimer >= reloadTime)
        {
            ammoCount = ammo;
            reloadTimer = 0f;
        }
        /* Shooting */
        if (isAvailable && ammoCount > 0)
        {
            GameObject closest = enemy.getClosest(transform.position);
            if (closest && Vector3.Distance(closest.transform.position, transform.position) < range)
            {
                Vector3 shootDir = closest.transform.position - transform.position;

                /* Summoning Snowball. */
                GameObject Snowball = Instantiate(projectile, transform.position, transform.rotation);
                Snowball.transform.tag = "PlayerSpawned";
                Snowball.GetComponent<ProjectileMovement>().Setup(shootDir.normalized);

                /* Cooldown Coroutine */
                ammoCount--;
                StartCoroutine(StartCooldown());
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "sled")
             canReload = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "sled")
            canReload = false;
    }
    public IEnumerator StartCooldown()
    {
        isAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        isAvailable = true;
    }

}
