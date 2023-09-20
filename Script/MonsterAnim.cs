using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnim : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private EnemyMovSystem enemyMovSystem;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Anim()
    {
        animator.SetBool("isPatrol", enemyMovSystem.isPatrol);
        animator.SetBool("isAttack", enemyMovSystem.isAttack);
    }
    private void Update()
    {
        enemyMovSystem.MovSystem();
        Anim();
        Debug.Log("패트롤 상태 = " + enemyMovSystem.isPatrol);
        Debug.Log("공격 상태 = " + enemyMovSystem.isAttack);
    }
}
