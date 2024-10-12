using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallLooking : MonoBehaviour
{
    private GameObject player;
    public Vector3 PlayerTrans;
    public float speedRotate = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.Player;


    }

    // Update is called once per frame
    void Update()
    {
        PlayerTrans = player.transform.position;
        LookToPlayer();

    }
    public void LookToPlayer()
    {
        if (player != null)
        {

            Vector3 vectorToTarget = transform.position - player.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;


            if (gameObject.transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if (gameObject.transform.position.x < player.transform.position.x)
            {
                // Lật sprite bằng cách thay đổi x trong quaternion
                transform.localScale = new Vector3(1, -1, 1); // Lật theo trục X

            }

            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speedRotate);
        }
    }
}
