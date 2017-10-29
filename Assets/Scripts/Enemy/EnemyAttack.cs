using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
	Transform player;
	NavMeshAgent nav;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
    }

    void Update ()
    {
		nav.SetDestination (player.transform.position);
    }
}
