using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            if (!anim.GetBool("isAttacking"))
            {
                anim.SetBool("isAttacking", true);
            }
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                anim.SetBool("isAttacking", false);
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
