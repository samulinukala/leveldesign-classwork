using CurvedPathGenerator;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class checkforAfork : MonoBehaviour
{

    PathFollower pathFollower => GetComponent<PathFollower>();
    public keepPlayerIn keepPlayerIn;
    public List<PathGenerator> differentRoutes;
    public List<string> PathDescriptions;
    public tramFunc playerTram;
    private tramui tramui => GetComponentInChildren<tramui>();
    bool ignoreOnce = false;
    public float turnOffTimer = 0;
    public float turnOffTimerT = 2;
    public GameObject leftCol;
    public GameObject rightCol;
    public PathGenerator start;
    public trackInfo STARTINFO;
    bool closed;
    private void Start()
    {
        playerTram.attachtotransform(transform);
        pathFollower.Generator = start;
        differentRoutes = STARTINFO.nextPaths;
        PathDescriptions = STARTINFO.nextDescription;
        Physics.IgnoreLayerCollision(3, 6);
        Physics.IgnoreLayerCollision(2, 6);
        Physics.IgnoreLayerCollision( 6,3);
        Physics.IgnoreLayerCollision( 6,2);
        Physics.IgnoreLayerCollision( 2,3);
        Physics.IgnoreLayerCollision(3, 2);
    }
    public void CloseDoors()
    {
        if (!closed)
        {
            leftCol.SetActive(true);
            rightCol.SetActive(true);
            closed = true;
           
        }
        var v = FindObjectsOfType<checkforAfork>().ToList();
        foreach (var v2 in v)
        {
            if (v2.closed == false)
            {
                v2.CloseDoors();
            }
        }
    }
  
    public void OpenDoors()
    {
        if (closed)
        {
            closed = false;
            leftCol.SetActive(false);
            rightCol.SetActive(false);
        }
        keepPlayerIn.disable();
        var v = FindObjectsOfType<checkforAfork>().ToList();
        foreach (var v2 in v)
        {
            if (v2.closed )
            {
                v2.OpenDoors();
            }
        }
    }
    public void chooseARoute(int pathNumber)
    {

        CloseDoors();
        tramui.ClearText();
        bool ig = true;
        if (ignoreOnce)
        {
            pathFollower.Generator = differentRoutes[pathNumber];
            if (differentRoutes[pathNumber].gameObject.GetComponent<trackInfo>() != null)
            {
                Debug.Log("not null");

                if (differentRoutes[pathNumber].gameObject.GetComponent<trackInfo>().nextPaths.Count != 0)
                {
                    Debug.Log("update track");
                    differentRoutes = pathFollower.Generator.gameObject.GetComponent<trackInfo>().nextPaths;
                    PathDescriptions = pathFollower.Generator.gameObject.GetComponent<trackInfo>().nextDescription;


                }

            }
            else
            {
                ig = false;
            }

        }

        if (ig)
        {
            pathFollower.IsLoop = true;
            pathFollower.IsMove = true;
            pathFollower.IsLoop = true;
            turnOffTimer = turnOffTimerT;
            ignoreOnce = true;
        }
    }
    private void Update()
    {
        if (turnOffTimer > 0)
        {
            pathFollower.IsMove = true;
            pathFollower.IsLoop = true;
        }
        if (pathFollower.IsMove)
        {
            if (turnOffTimer < 0)
            {


                pathFollower.IsLoop = false;
            }
            else
            {
                turnOffTimer -= Time.deltaTime;
            }
        }
    }
    public void showUI()
    {
        if (differentRoutes.Count == 3)
        {
            tramui.setChoise(PathDescriptions[0], PathDescriptions[1], PathDescriptions[2]);
        }
        else if (differentRoutes.Count == 2)
        {
            tramui.setChoise(PathDescriptions[0], PathDescriptions[1]);
        }
        else if (differentRoutes.Count == 1)
        {
            chooseARoute(0);
        }

    }
}