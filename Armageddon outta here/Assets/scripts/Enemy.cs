using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    private float speedNorm;
    private float angularSpeedNorm;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speedNorm = agent.speed;
        angularSpeedNorm = agent.angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if (Vector3.Distance(target.position, transform.position) <= 15 && gameObject.CompareTag("Shooter"))
        {
            FaceTarget(target.position);
        }
    }
    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }
}
