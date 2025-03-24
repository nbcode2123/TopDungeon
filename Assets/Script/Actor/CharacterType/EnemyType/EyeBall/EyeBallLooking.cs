using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallLooking : MonoBehaviour
{
    public GameObject player { get; set; }
    public Vector3 PlayerTrans { set; get; }
    public float speedRotate = 10;
    public Action OnActive;
    // Start is called before the first frame update
    void Start()
    {
        // player = GameManager.Instance.Player;

    }
    void OnEnable()
    {
        OnActive += LookToPlayer;
    }
    void OnDisable()
    {
        OnActive -= LookToPlayer;
    }
    // Update is called once per frame
    void Update()
    {
        OnActive?.Invoke();
    }
    public void LookToPlayer()
    {
        if (player != null)
        {
            PlayerTrans = player.transform.position;


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
