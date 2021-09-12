using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject target;
    private float speedNorm;
    private float angularSpeedNorm;
    public float reloadTime = 30;
    private float reloadCounter;
    public GameObject projectile;
    private Target targetC;

    // Start is called before the first frame update
    void Start()
    {
        targetC = GetComponent<Target>();
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        speedNorm = agent.speed;
        angularSpeedNorm = agent.angularSpeed;
        reloadCounter = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target.transform.GetComponent<playerController>().gameWon)
        {
            agent.SetDestination(target.transform.position);
            FaceTarget(target.transform.position);
            if (Vector3.Distance(target.transform.position, transform.position) <= 50 && gameObject.CompareTag("Shooter"))
            {
                agent.Stop();
                reloadCounter--;
                if (reloadCounter <= 0) shoot();
            }
            else
            {
                agent.Resume();
            }
            if(targetC.health <= 0) agent.Stop();
        }
        else Destroy(gameObject);
    }
    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }
    private void shoot()
    {
        reloadCounter = reloadTime;
        Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + agent.height, transform.position.z) + (transform.forward*5) , new Quaternion { });
    }
}
