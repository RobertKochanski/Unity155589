using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;

    private bool isDead = false;

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
