using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public int damage;

    protected Transform DetectObstacles()
    {
        return null;
    }

    public virtual void Attack(Transform target)
    {

    }

    public virtual void Death()
    {

    }

    public void TakeDamge(int damage)
    {
        // reduce health
        health -= damage;
        // if health =< 0
        if (health <= 0)
        {
            // call death 
            Death();
        }


    }
}
