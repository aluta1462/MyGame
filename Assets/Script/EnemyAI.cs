using UnityEngine;
using Pathfinding;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class EnemyAI : MonoBehaviour
{

    public Transform target;

    public float updateRate = 2f;

    private Seeker seeker;

    private Rigidbody2D rb;

    //phan tinh toan

    public Path path;
    // toc do AI moi giay
    public float speed = 300f;

    public ForceMode2D forceMode;
    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistants = 3;


    public int currentWaypoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        if (target == null)
        {
            Debug.LogError("ko thay nguoi choi");
            return;

        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f/updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("ta co 1 duong dan, lieu no co loi ko?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;

        }
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        if(path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }

            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;

        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //di chuyen AI
        rb.AddForce(dir, forceMode);

        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistants)
        {
            currentWaypoint++;
            return;
        }



    }   


}
