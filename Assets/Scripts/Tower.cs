using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public int damage = 10;
    public float fireDelay = .5f;
    public float range = 3f;
    public int level = 1;
    public int cost = 5;

    private float fireTimer = 0;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireDelay)
        {
            List<Transform> targets = DetectTargets();
            Transform closestTarget = GetClosestTarget(targets);

            Aim(target);
            Fire(target);
        }
    }

    public virtual void Fire(Transform target)
    {

    }
    public virtual void Aim(Transform target)
    {

    }

    public Transform GetClosestTarget(List<Transform> targets)
    {
        // set min to max(infinty)
        float min = float.MaxValue;
        // set clostewst to null 
        Transform closest = null;
        // lloop through each target
        foreach (var target in targets)
        {
            // get distance between target and transform 
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance < min)
            {
                min = distance;
                closest = target;
            }

        }

        return closest;
    }
    protected List<Transform> DetectTargets()
    {
        List<Transform> result = new List<Transform>();
        // peform an overlap shpere phisics detection
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        // if hits contain enemy
        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy)
            {
                // addd to transform list
                result.Add(enemy.transform);
            }
        }

        // Return transform list
        return result;
    }
}
