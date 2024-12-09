using System.Collections;
using Script.Actor.Behaviours.Interface;
using UnityEngine;

namespace Script.GameManager.Logic
{
    public class MoveRoundAI : MonoBehaviour
    {
        public float RangeMove;
        public float TimeStanding;
        public Vector2 targetPos;
        public float SpeedMove;

        public void Start()
        {
            SpeedMove = gameObject.GetComponent<IActorStats>().MoveSpeed;
            RunRandom();

        }
        public void RunRandom()
        {
            StartCoroutine(MoveEnemyRandom());

        }
        public IEnumerator MoveEnemyRandom()
        {
            while (true)
            {
                CreateRandomPosition();
                yield return StartCoroutine(MoveToTarget());
                yield return new WaitForSeconds(TimeStanding);

            }
        }
        public void CreateRandomPosition()
        {
            var enemyPos = gameObject.transform.position;
            var _posX = Random.Range(enemyPos.x - RangeMove, enemyPos.x + RangeMove);
            var _posY = Random.Range(enemyPos.y - RangeMove, enemyPos.y + RangeMove);
            targetPos = new Vector2(_posX, _posY);

        }
        public IEnumerator MoveToTarget()
        {
            while (Vector2.Distance(gameObject.transform.position, targetPos) > 0.1f)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPos, SpeedMove * Time.deltaTime);
                yield return null;
            }
        }

    }
}
