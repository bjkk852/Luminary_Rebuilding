using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoss : AIModel
{
    private bool[] patturns = new bool[3];
    private bool isMove = false;
    private float moveTime;

    public override void FixedUpdate()
    {
        if(GameManager.player != null)
        {
            // if is move, wait for seconds, to next action
            if (isMove)
            {
                if(Time.time - moveTime >= 1f)
                {
                    isMove = false;
                    target.setIdleState();
                    target.changeState(new MobCastState(0f, 0));
                }
            }
            else
            {
                // 체력 일정 수치 이하면 기믹패턴 발현
                if(target.HPPercent() <= 0.25f && !patturns[0])
                {
                    patturns[0] = true;
                    target.changeState(new MobCastState(2f, 3));
                }
                // 
                else if(Time.time - moveTime >= 1.3f)
                {
                    moveTime = Time.time;
                    isMove = true;
                    target.changeState(new MobChaseState());
                }
            }
        }
    }
}
