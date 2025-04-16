using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour

{
    public Animator Alanimator;
    public int value=25;
    [System.Serializable]
    public struct path
    {
        public List<Transform> pathList;
    }
    NavMeshAgent agent=>GetComponent<NavMeshAgent>();
    
  
    public List<path> paths;

    public List<Transform> currentList;
    int completedPoints=0;
    public float tolerance = 1;
     bool goingThroughList;
    public float distanceToPlayer = 10;
    public NavMeshPath navMeshP;
    public List<bool> activeTriggers;
    public NavMeshAgent alrb;
    public bool melee;
    public bool sentryMode;
    public bool FindPlayer;
    public float timer=0;
    public float timerTarget=6;
    public float health=0;
    public float maxHealth = 100;
    public float damage=15;
    public float stuckTimer = 0;
    public float stuckTimerTarget=2;
    public void triggerPath(int pathInAList)
    {
        if (!melee)
        {
            if (pathInAList != 0)
            {
                sentryMode = false;
            }
            if (!sentryMode)
            {
              
                    if (paths.Count >= pathInAList)
                    {
                        if (paths[pathInAList].pathList.Count != 0)
                        {

                   
                        currentList = paths[pathInAList].pathList;
                        goingThroughList = true;
                        completedPoints = 0;
                        agent.ResetPath();
                        agent.SetDestination(new Vector3( currentList[completedPoints].position.x,0, currentList[completedPoints].position.z));
                        agent.isStopped = false;
                    }
                }
            }

        }else
        {
            if(!sentryMode) FindPlayer = true;

        }
    }
    public void triggerKillMode(string gogblegook)
    {
        Debug.Log("soht0");
        agent.ResetPath();
        agent.isStopped = false;
        agent.SetDestination(new Vector3(FindObjectOfType<FirstPersonController>().transform.position.x, 0,  FindObjectOfType<FirstPersonController>().transform.position.z));
        sentryMode=false;
        FindPlayer = true;
    }
        public void triggerKillMode()
    {
        agent.ResetPath();
        agent.SetDestination(new Vector3(FindObjectOfType<FirstPersonController>().transform.position.x, 0, FindObjectOfType<FirstPersonController>().transform.position.z));


        FindPlayer = true;
        
    }
    private void Start()
    {
        health = maxHealth;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            health -= damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            FindObjectOfType<gameManager>().score += value;
            Destroy(gameObject);
        }
        if (!sentryMode)
        {
            Alanimator.SetFloat("horizontalMovement", alrb.velocity.z);
            Alanimator.SetFloat("forwardMovement", alrb.velocity.x);
            if (goingThroughList)
            {
                var v = Mathf.Abs((new Vector3(currentList[completedPoints].position.x, 0, currentList[completedPoints].position.z) - new Vector3(transform.position.x, 0, transform.position.z)).magnitude);
                Debug.Log("distance to target"+v);
                if (v <= tolerance)
                {
                    if (completedPoints != currentList.Count-1)
                    {
                        
                       
                      
                        completedPoints++;
                        agent.isStopped = false;
                        goingThroughList = true;
                        agent.ResetPath();
                        agent.SetDestination(new Vector3(currentList[completedPoints].position.x, 0, currentList[completedPoints].position.z));
                    }
                    else
                    {
                        agent.ResetPath();
                        agent.isStopped = true;
                        completedPoints = 0;
                        goingThroughList = false;
                    }
                }
                else if (agent.velocity.magnitude == 0)
                {
              
                    if (stuckTimer < 0)
                    {
                        Debug.Log("stuck");
                        stuckTimer = stuckTimerTarget;
                        agent.ResetPath();
                        agent.enabled = false;
                        agent.enabled = true;
                        agent.isStopped = false;
                        agent.SetDestination(new Vector3(currentList[completedPoints].position.x, 0, currentList[completedPoints].position.z));

                    }
                    else
                    {
                        stuckTimer -= Time.deltaTime;
                    }
                }
            }
            else
            {
                for (int i = 0; i < activeTriggers.Count; i++)
                {
                    if (activeTriggers[i])
                    {
                        triggerPath(i);
                    }
                }
            }
        }

        if (!sentryMode&&FindPlayer&&timer<0)
        {
            timer = timerTarget;
            triggerKillMode();
        }
        else{
            timer-=Time.deltaTime;
        }
    }
}

