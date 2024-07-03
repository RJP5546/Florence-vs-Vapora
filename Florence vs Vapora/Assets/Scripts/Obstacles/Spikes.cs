using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Vector2 moveDir;
    [SerializeField] private float speed;
    [SerializeField] private float maxDist;
    [Tooltip("In Seconds")]
    [SerializeField] private float intervalTime;

    private Vector2 startPos;
    private Vector2 targetPos;

    private bool spikeAgain = true;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector2(startPos.x + (maxDist * moveDir.x), startPos.y + (maxDist * moveDir.y));
        Debug.Log(targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (spikeAgain)
        {
            StartCoroutine(Activate());
            Debug.Log("Activated");
            Debug.Log(transform.position);
            Debug.Log(new Vector2((maxDist * moveDir.x) + transform.position.x, transform.position.y));
        }
    }

    IEnumerator Activate()
    {
        spikeAgain = false;
        while (Vector2.Distance(transform.position, targetPos) > .2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(intervalTime/2);

        while (Vector2.Distance(transform.position, startPos) > .2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(intervalTime);
        spikeAgain = true;
    }


}
