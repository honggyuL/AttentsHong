using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleSelector : StateMachineBehaviour
{
    

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.IsInTransition(0))    // 0번째 레이어가 트랜지션 중인지 아닌지 확인해서 아닐경우 아래 코드 실행
        {
            animator.SetInteger("IdleSelect", RandomSelect());
        }
    }

    int RandomSelect()
    {
        float num = Random.Range(0.0f, 1.0f);
        int select;
        if(num < 0.7f)
        {
            // 70% 확률로 들어올 수 있다.
            select = 0;
        }
        else if(num < 0.8f)
        {
            // 10% 확률로 들어올 수 있다.
            select = 1;
        }
        else if(num < 0.87f)
        {
            // 7% 확률로 들어올 수 있다.
            select = 2;
        }
        else if(num < 0.94f)
        {
            // 7% 확률로 들어올 수 있다.
            select = 3;
        }
        else
        {
            // 6% 확률로 들어올 수 있따.
            select = 4;
        }

        return select;
    }
}
