using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HackManC1;
using UnityEngine;
using UnityEngine.UI;

public class RecordBoardManager : MonoBehaviour
{
    private void OnEnable()
    {
        // Find all the record text
        var recordBoards = FindObjectsOfType<Record>();
        // Read all the record data and write them down
        for (int i = 0; i < recordBoards.Length; i++)
        {
            recordBoards[i].GetComponent<Text>().text = RecordDataManager.rank[4 - i].ToString();
        }
    }
}
