using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    public Animator animaton;
    public int rutina,direction;
    public GameObject target;
    public bool atack;
    [SerializeField] private float speedRunEnemy, cronometro;

    private void Start()
    {
        animaton = GetComponent<Animator>();
        target = GameObject.Find("Player 1");
    }

}
