using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Animator>().SetBool("isJumping", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }

        if (Input.GetKey(KeyCode.X))
        {
            GetComponent<Animator>().SetBool("isDamageTaken", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isDamageTaken", false);
        }

        
        
    }
}
