using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] public string characterName;
    [SerializeField] public int maxHealthPoint;
    [HideInInspector] public int healthPoint;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float runSpeed;
    [SerializeField] public float normalAttackSpeed;
    [SerializeField] public int maxNormalAttack;
    public Animator animator;

    //Charactor Behavior
    [HideInInspector] public bool isTalk;
    [HideInInspector] public bool isStart;
    [HideInInspector] public bool isEvade;
    [HideInInspector] public bool isAttack;
    [HideInInspector] public bool isMove;
    [HideInInspector] public bool isDie;

    private void Start()
    {
        healthPoint = maxHealthPoint;
    }

    public float getWalkSpeed()
    {
        return walkSpeed;
    }
}
