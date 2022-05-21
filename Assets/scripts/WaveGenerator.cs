using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public Transform rangedEnemyParent;
    public GameObject ranged;
    public GameObject melee;
    public Transform meleeEnemyParent;
    private Transform[] rangedEnemies;
    private Transform[] meleeEnemies;
    public EnemyManager manager;
    // Start is called before the first frame update
    
    void Start()
    {
        rangedEnemies = rangedEnemyParent.GetComponentsInChildren<Transform>();
        meleeEnemies = meleeEnemyParent.GetComponentsInChildren<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            foreach(Transform enemy in rangedEnemies)
            {
                Instantiate(ranged, enemy);
                //Destroy(enemy.gameObject);
            }
           /* foreach (Transform enemy in meleeEnemies)
            {
                Instantiate(melee, enemy);
                //Destroy(enemy.gameObject);
            }*/
            manager.setup();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
