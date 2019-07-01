using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{

    [SerializeField] Transform pos1, pos2;
    [SerializeField] float speed;
    [SerializeField] Transform startPos;
    [SerializeField] float stopTime = 2f;

    Vector3 nextPos;
    LoseCollider loseCollider;


    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
        loseCollider = FindObjectOfType<LoseCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        moveBackAndForth();
    }

    void moveBackAndForth()
    {
        if (transform.position == pos1.position)
        {
            StartCoroutine(StopForSec(stopTime, pos2.position));
            //nextPos = pos2.position;
        }
        else if (transform.position == pos2.position)
        {
            StartCoroutine(StopForSec(stopTime, pos1.position));
            //nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    IEnumerator StopForSec(float secs, Vector3 nextPos2)
    {
        yield return new WaitForSeconds(secs);
        nextPos = nextPos2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Spike"))
        {
            loseCollider.HitLoseCollider();
        }
    }
}
