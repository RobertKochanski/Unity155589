using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;
    private bool isDead = false;

    [SerializeField] private AudioClip deadAudio;
    [SerializeField] private AudioClip damagedAudio;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();
        hitPoints -= damage;

        if (!isDead)
        {
            audio.PlayOneShot(damagedAudio);
        }

        if (hitPoints <= 0 && !isDead)
        {
            audio.PlayOneShot(deadAudio);
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
