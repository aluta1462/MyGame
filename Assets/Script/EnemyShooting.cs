using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody2D rb;
    
    public float dist;
    public float delayShooting;
    public bool readyAttack;

    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;

    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject playerRef;
    public bool canSeePlayer { get; private set; }

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }


    private void Update()
    {
        
        if (canSeePlayer && !readyAttack)
        {
            Vector3 direction = playerRef.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            Shoot();
            readyAttack = true;
            Invoke(nameof(ResetAttack), delayShooting);
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * Bullet.bulletForce, ForceMode2D.Impulse);
        readyAttack = false;
    }

    private void ResetAttack()
    {
        readyAttack = false;
    }


    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FOV();


        }
    }


    private void FOV()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        if (collider2Ds.Length > 0)
        {
            Transform target = collider2Ds[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }


}
