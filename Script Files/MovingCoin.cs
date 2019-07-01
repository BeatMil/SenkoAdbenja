using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCoin : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Update()
    {
        StartCoroutine(MoveCoin());
    }

    IEnumerator MoveCoin()
    {
        yield return new WaitForSeconds(2);
        transform.position = Vector3.MoveTowards(transform.position, target.position, 8f * Time.deltaTime);
    }
}
