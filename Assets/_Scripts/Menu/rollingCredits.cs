using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollingCredits : MonoBehaviour
{

    public Vector3 startPos;
    public Vector3 endPos;
    public float speed;
    public int waitTime;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, endPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, endPos) < 0.05f)
        {
            StartCoroutine(waitAndReset());
        }
    }
    IEnumerator waitAndReset()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = startPos;
    }
}
