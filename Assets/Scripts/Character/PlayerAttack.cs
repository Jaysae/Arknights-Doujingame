using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //References
    public PlayerCharacter playerCharacter;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            playerCharacter.isAttack = true;
        }
        else if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetInteger("Attack", 0);
            playerCharacter.isAttack = false;
        }


    }

    void Attack()
    {
        var atk = Input.GetButtonDown("Fire1");
        // Play Attack Animation
        animator.SetInteger("Attack", 1);

    }
}
