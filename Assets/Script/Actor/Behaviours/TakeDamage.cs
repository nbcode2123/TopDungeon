using Script.Actor.Behaviours.Interface;
using UnityEngine;

namespace Script.Actor.Behaviours
{
    public class TakeDamage : MonoBehaviour
    {
        private void Start()
        {

        }
        void Update()
        {
        }
        public void DealDmgToActor(float DamageTaken) // gaay dmg len nhan vat 
        {
            if (gameObject.GetComponent<IActorStats>().currentHeath >= DamageTaken)
            {
                gameObject.GetComponent<IActorStats>().currentHeath -= DamageTaken;
                gameObject.GetComponent<Animator>().SetBool("isTakeDmg", true);


            }
            if (gameObject.GetComponent<IActorStats>().currentHeath <= DamageTaken)
            {
                gameObject.GetComponent<IActorStats>().currentHeath = 0;


            }
        }


    }
}
