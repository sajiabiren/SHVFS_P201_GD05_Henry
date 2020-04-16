using System;
using System.Collections;
using System.Collections.Generic;
using HackManC1;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSetting : MonoBehaviour
{
    public string playerName;
    private PlayerInputComponent pIC;
    private void Awake()
    {
        pIC = GetComponent<PlayerInputComponent>();
        pIC.Movementspeed = AppDataSystem.Load<PlayerData>(playerName).MovementSpeed;
    }
}
