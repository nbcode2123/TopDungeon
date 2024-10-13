using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public Vector3 markPosition;
    public float Range;
    public float TimeDelay;
    public Vector3 RandomMovePosition;
    public float distanceToPos;




    // Start is called before the first frame update
    void Start()
    {
        markPosition = gameObject.transform.position;
        RandomMovePosition = markPosition;

    }

    // Update is called once per frame
    void Update()
    {
        // distanceToPos = Vector2.Distance(new Vector2(markPosition.x, markPosition.y), new Vector2(RandomMovePosition.x, RandomMovePosition.y));

    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(markPosition, Range);

    }

    public void MoveRandom()
    {



    }

}

