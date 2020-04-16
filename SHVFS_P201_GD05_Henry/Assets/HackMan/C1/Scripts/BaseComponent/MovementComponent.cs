using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    
    public class MovementComponent : BaseGridObject
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
            // If we have arrived, we need to set a new target, and if current input is valid
            if(GridPosition == targetGridPosition
               && LevelGenerator.Grid[Mathf.Abs(targetGridPosition.y + currentInputDirecton.y), Mathf.Abs(targetGridPosition.x + currentInputDirecton.x)] != 1)
            {
                targetGridPosition += currentInputDirecton;
                previousInputDirection = currentInputDirecton;
            }
            // If we need to set a new target, and previous input is valid
            else if (GridPosition == targetGridPosition
                && LevelGenerator.Grid[Mathf.Abs(targetGridPosition.y + previousInputDirection.y), Mathf.Abs(targetGridPosition.x + previousInputDirection.x)] != 1)
            {
                targetGridPosition += previousInputDirection;
            }
            // If we need to set a new target, and no input was valid
            if (GridPosition == targetGridPosition) return;
            
            // Movement logic
            progressToTarget += Movementspeed * Time.deltaTime;
            // We will lerp towards the target
            transform.position = Vector3.Lerp(GridPosition.AsVector3(), targetGridPosition.AsVector3(), progressToTarget);
        }
    }
}