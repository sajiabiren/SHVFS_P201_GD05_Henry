using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.GetComponent<Pill>())
        //     {
        //         Destroy(other.gameObject);
        //         if (FindObjectsOfType<Pill>().Length <= 1)
        //         {
        //             Debug.Log(("You win!!!!"));
        //             SceneManager.LoadScene("HackMan/C1/Scenes/GameScene");
        //         }
        //     }
        //
        //     if (other.GetComponent<EnemyInputComponent>())
        //     {
        //         Debug.Log("You lose!!!!");
        //         SceneManager.LoadScene("HackMan/C1/Scenes/GameScene");
        //     }
        // }
    }
}