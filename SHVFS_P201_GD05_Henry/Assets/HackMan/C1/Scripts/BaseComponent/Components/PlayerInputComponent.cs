using UnityEngine;

namespace HackManC1
{
    // We set the currentInputDirection
    public class PlayerInputComponent : MovementComponent
    {
        protected override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentInputDirecton = new IntVector2(0, 1);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentInputDirecton = new IntVector2(0, -1);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentInputDirecton = new IntVector2(-1, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentInputDirecton = new IntVector2(1, 0);
            }
        }
    }
}