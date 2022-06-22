using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (score <= 0)
        {
            score = 0;
            EnemyManager.enemyArr.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }


    public void Damage(int a)
    {
        score -= a;
        DamagePopup.Create(transform.position, a);
    }
}
