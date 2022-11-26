using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100f;
    private bool isDead = false;

    [SerializeField] private AudioClip DeadAudio;
    [SerializeField] private AudioClip DamagedAudio;
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
            audio.clip = DamagedAudio;
            audio.Play();
        }

        if (hitPoints <= 0 && !isDead)
        {
            audio.clip = DeadAudio;
            audio.Play();
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
