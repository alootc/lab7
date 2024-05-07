using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float speed;
    public float time_idle;
    public Transform[] points;

    public Vector3 point_current;

    private int index;
    public bool isStopped;
    public bool isPlayer;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        point_current = points[index].position;
        
    }

    private void FixedUpdate()
    {
        if (isStopped || isPlayer) return;

        Vector3 dir = point_current - transform.position;
        dir.Normalize();

        rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.z * speed);

        Vector2 pos1 = new(transform.position.x, transform.position.z); ;
        Vector2 pos2 = new(point_current.x, point_current.z);

        if(Vector2.Distance(pos1, pos2) < 0.1f)
        {
            StartCoroutine(IsGoal());
        }

        //isStopped = Vector3.Distance(transform.position, point_current) < 0.1f;

    }

    private IEnumerator IsGoal()
    {
        isStopped = true;
        yield return new WaitForSecondsRealtime(time_idle);

        index ++;
        if (index >= points.Length) index = 0;

        point_current = points[index].position;
        isStopped = false;
    }
}
