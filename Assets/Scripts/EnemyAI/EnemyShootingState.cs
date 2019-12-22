﻿using UnityEngine;

using DEEP.StateMachine;

namespace DEEP.AI
{

    public class EnemyShootingState: State<EnemyAISystem>{

        private static EnemyShootingState instance;

        public EnemyShootingState(){
            if (instance != null)
                return;
            
            instance = this;
        }

        public static EnemyShootingState Instance
        {
            get 
            {
                if (instance == null)
                {
                    new EnemyShootingState();
                }

                return instance;
            }
        }

        public override void EnterState(EnemyAISystem owner) {
            
            Debug.Log("entering Enemy Shooting State");
            owner.Shooting();

            // Make enemy not move when shooting.
            owner.agent.SetDestination(owner.transform.position);

            if(owner.OnAggro != null)
                owner.OnAggro();

        }

        public override void ExitState(EnemyAISystem owner) {
            Debug.Log("exiting Enemy Shooting State");
        }

        public override void UpdateState(EnemyAISystem owner) {

            if (owner.InAttackRange())
                owner.Shooting();
            else//the enemy is trying to flee
                owner.ChangeState(EnemyPursuingState.Instance);
                
        }
    }
}