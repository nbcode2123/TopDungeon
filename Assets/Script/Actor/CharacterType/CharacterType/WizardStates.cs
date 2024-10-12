using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStates : MonoBehaviour
{
    public StateMachine stateMachine;
    public WizardAttackState wizardAttackState;
    public WizardIdleState wizardIdleState;

    void CheckConditionToChangeState(){
        if(Input.GetKeyDown(KeyCode.K)){
            if(stateMachine.CurrentState == wizardIdleState){
                stateMachine.ChangeState(wizardAttackState);
            }
            else{
                stateMachine.ChangeState(wizardIdleState);
            }
        }
    }
    void Awake(){

        stateMachine = new StateMachine();
        wizardAttackState = new WizardAttackState(gameObject, stateMachine);
        wizardIdleState = new WizardIdleState(gameObject, stateMachine);

        stateMachine.Initialize(wizardIdleState);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // stateMachine.Initialize(wizardIdleState);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Vị trí chuột trong World Space: " + worldPosition);
        stateMachine.CurrentState.FrameUpdate();
        CheckConditionToChangeState();
    }

}
