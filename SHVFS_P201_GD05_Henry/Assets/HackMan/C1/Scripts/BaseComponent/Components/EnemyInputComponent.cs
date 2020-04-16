using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    public class EnemyInputComponent : MovementComponent
    {
        private IntVector2[] movementDirections = new[]
        {
            new IntVector2(0, 1),
            new IntVector2(0, -1),
            new IntVector2(1, 0),
            new IntVector2(-1, 0)
        };

        protected override void Update()
        {
            if (transform.position == targetGridPosition.AsVector3())
            {
                var possibleDirections = new List<IntVector2>();

                foreach (var movementDirection in movementDirections)
                {
                    IntVector2 potentialTargetPosition = targetGridPosition + movementDirection;
                    if (LevelGenerator.Grid[Mathf.Abs(potentialTargetPosition.y),
                        Mathf.Abs(potentialTargetPosition.x)] != 1)
                    {
                        if (currentInputDirecton != -movementDirection)
                        {
                            possibleDirections.Add(movementDirection);
                        }
                    }
                }
                
                // If it's a dead road, need a anti direction
                if (possibleDirections.Count < 1)
                {
                    possibleDirections.Add(-currentInputDirecton);
                }
                
                // LINQ -> Language Integrated Query
                

                int direction = Random.Range(0, possibleDirections.Count);
                currentInputDirecton = possibleDirections[direction];
            }
            base.Update();
        }
    }
}