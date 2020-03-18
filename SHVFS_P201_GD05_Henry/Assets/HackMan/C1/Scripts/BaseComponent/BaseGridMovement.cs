using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{

    public class BaseGridMovement : BaseGridObject
    {
        public float Movementspeed;
        protected IntVector2 targetGridPosition;
        protected float progressToTarget = 1f;
        protected IntVector2 currentInputDirecton;
        private IntVector2 previousInputDirection;

        private void Start()
        {
            targetGridPosition = GridPosition;
        }

        protected virtual void Update()
        {
            // If we have arrived...
            if(transform.position == targetGridPosition.AsVector3())
            {
                progressToTarget = 0f;
                GridPosition = targetGridPosition;
            }
            // If we set a new target, and current input is valid
            if(GridPosition == targetGridPosition && 
                LevelGenerator.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirecton.y), Mathf.Abs(targetGridPosition.x + currentInputDirecton.x)] != 1)
            {

            }
            // If we set a new target, and previous input is valid

            // If we have arrived, and no input was valid
        }
    }
}