﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DEEP.StateMachine;

public class EnemyWaitingState : State <EnemyAISystem>
{
    private static EnemyWaitingState instance;

    public EnemyWaitingState(){
        if (instance != null)
            return;
        
        instance = this;
    }

    public static EnemyWaitingState Instance
    {
        get 
        {
            if (instance == null)
            {
                new EnemyWaitingState();
            }

            return instance;
        }
    }
    public override void EnterState(EnemyAISystem owner){
        owner.waiting();
    }

    public override void ExitState(EnemyAISystem owner){}

    public override void UpdateState(EnemyAISystem owner){
        
        if (owner.search.get())
        {
            owner.enemySM.ChangeState(EnemyShootingState.Instance);
        }
        owner.waiting();
        
    }

}
