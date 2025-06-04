using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ShootExecution : MonoBehaviour
{
    private GameObject TargetPlayer;
    private float AttackSpeed;
    [SerializeField] private GameObject Pivot;
    [SerializeField] private GameObject Actor;
    [SerializeField] private GameObject Bullet1;
    [SerializeField] private GameObject Bullet2;

    private float BulletSpeed = 9;
    private float CounterTime;
    private Action CurrentShootPattern;





    private List<Action> ListShootPattern;
    private void Start()
    {
        AttackSpeed = Actor.GetComponent<IAttackable>().GetAttackSpeed();
        ListShootPattern = new List<Action>
        {
            ShootPattern1,
            ShootPattern2,
            // ShootPattern3
        };


    }
    public void ShootPattern1()
    {
        CounterTime += Time.deltaTime;
        if (CounterTime >= AttackSpeed)
        {
            if (TargetPlayer != null)
            {
                var _directionPivotToPlayer = TargetPlayer.transform.position - Pivot.transform.position;
                Vector2 _direction;
                if (_directionPivotToPlayer.x > 0)
                {
                    _direction = Vector2.right;

                }
                else
                {
                    _direction = Vector2.left;
                }
                float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

                // Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                // GameObject bullet = Instantiate(Bullet);
                // bullet.transform.position = Pivot.transform.position;
                // bullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);
                // bullet.SetActive(true);
                // bullet.GetComponent<Rigidbody2D>().velocity = q * Vector2.right * BulletSpeed;

                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                GameObject bullet = Instantiate(Bullet1);
                bullet.transform.position = Pivot.transform.position;
                bullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = q * Vector2.right * BulletSpeed;

                // 
                Quaternion qleft = Quaternion.AngleAxis(angle + 30, Vector3.forward);
                GameObject bullet1 = Instantiate(Bullet1);
                bullet1.transform.position = Pivot.transform.position;
                bullet1.transform.rotation = Quaternion.Slerp(transform.rotation, qleft, 10);
                bullet1.SetActive(true);
                bullet1.GetComponent<Rigidbody2D>().velocity = qleft * Vector2.right * BulletSpeed;

                Quaternion qright = Quaternion.AngleAxis(angle - 30, Vector3.forward);
                GameObject bullet2 = Instantiate(Bullet1);
                //
                bullet2.transform.position = Pivot.transform.position;
                bullet2.transform.rotation = Quaternion.Slerp(transform.rotation, qright, 10);
                bullet2.SetActive(true);
                bullet2.GetComponent<Rigidbody2D>().velocity = qright * Vector2.right * BulletSpeed;



                // 
                Quaternion qleft1 = Quaternion.AngleAxis(angle + 60, Vector3.forward);
                GameObject bullet3 = Instantiate(Bullet1);
                bullet3.transform.position = Pivot.transform.position;
                bullet3.transform.rotation = Quaternion.Slerp(transform.rotation, qleft, 10);
                bullet3.SetActive(true);
                bullet3.GetComponent<Rigidbody2D>().velocity = qleft1 * Vector2.right * BulletSpeed;

                Quaternion qright1 = Quaternion.AngleAxis(angle - 60, Vector3.forward);
                GameObject bullet22 = Instantiate(Bullet1);
                bullet22.transform.position = Pivot.transform.position;
                bullet22.transform.rotation = Quaternion.Slerp(transform.rotation, qright, 10);
                bullet22.SetActive(true);
                bullet22.GetComponent<Rigidbody2D>().velocity = qright1 * Vector2.right * BulletSpeed;

                CounterTime = 0;
            }

        }



    }
    public void ShootPattern2()
    {
        CounterTime += Time.deltaTime;
        if (CounterTime >= AttackSpeed)
        {

            Vector2 _direction;
            var _directionPivotToPlayer = TargetPlayer.transform.position - Pivot.transform.position;

            if (_directionPivotToPlayer.x > 0)
            {
                _direction = Vector2.right;

            }
            else
            {
                _direction = Vector2.left;
            }
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            for (int i = 0; i < 10; i++)
            {
                float _angleRandom = UnityEngine.Random.Range(angle - 60, angle + 60);
                Quaternion q = Quaternion.AngleAxis(_angleRandom, Vector3.forward);
                GameObject bullet = Instantiate(Bullet2);
                bullet.transform.position = Pivot.transform.position;
                bullet.transform.rotation = Quaternion.Slerp(transform.rotation, q, 10);
                bullet.SetActive(true);
                bullet.GetComponent<Rigidbody2D>().velocity = q * Vector2.right * BulletSpeed;
            }
            CounterTime = 0;




        }


    }
    public void ShootPattern3()
    {
        CounterTime += Time.deltaTime;
        if (CounterTime >= AttackSpeed)
        {

            Vector2 _direction;
            var _directionPivotToPlayer = TargetPlayer.transform.position - Pivot.transform.position;

            if (_directionPivotToPlayer.x > 0)
            {
                _direction = Vector2.right;

            }
            else
            {
                _direction = Vector2.left;
            }
            //


            CounterTime = 0;




        }

    }


    public void SetTargetPlayer(GameObject targetPlayer)
    {
        TargetPlayer = targetPlayer;
    }
    public void InvokeRandomShootPattern()
    {
        TargetPlayer = gameObject.GetComponent<StateControllerGangsterCat>().GetTargetPlayer();
        CurrentShootPattern.Invoke();


    }
    public void ChooseRandomPattern()
    {
        CurrentShootPattern = null;
        CurrentShootPattern += ListShootPattern[UnityEngine.Random.Range(0, ListShootPattern.Count)];

    }
}