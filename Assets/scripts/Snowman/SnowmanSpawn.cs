using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowmanSpawn : MonoBehaviour
{
    [SerializeField] private Image spawnCircle;
    [SerializeField] private float reloadTime;
    [SerializeField] private GameObject SnowmanPf;
    private bool canReload;
    private float reloadTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCircle.fillAmount = reloadTimer / reloadTime;
        /* Reloading */
        if (!canReload)
            reloadTimer = 0f;
        else
            reloadTimer += Time.deltaTime;
        if (reloadTimer >= reloadTime)
        {
            GameObject Snowman = Instantiate(SnowmanPf, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //Vector3 uiPosition = cam.WorldToScreenPoint(collision.gameObject.transform.position);

            canReload = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            canReload = false;
    }
}
