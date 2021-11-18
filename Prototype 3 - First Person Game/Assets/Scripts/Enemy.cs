using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    // Enemy stats
    public int curHP, maxHp, scoreToGive;
    //Enemy movement
    public float moveSpeed, attackRange, yPathOffset;
    // Cords for a path
    private List<Vector3> path;
    // Enemy weapon
    private Weapon weapon;
    // Target to target
    private GameObject target;



    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHP = maxHp;
    }


    void UpdatePath()
    {
        // Calculate emeny path to target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }


    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
            Die();
    }

    void Die()
        {
            GameManager.instance.AddScore(scoreToGive);
            Destroy(gameObject);
        }
    

    // Update is called once per frame
    void Update()
    {
        // Have enemy look at target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        // Calculate distance between the enemy and player
        float dist = Vector3.Distance(transform.position, target.transform.position);
        // If within attackrang, shoot at player
        if(dist <= attackRange)
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        // If enemy if too far away, chase after player
        else
        {
            ChaseTarget();
        }
        
    }
}
