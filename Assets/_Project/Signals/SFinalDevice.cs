using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFinalDevice : MonoBehaviour
{

    public int numberOfBad = 0;
    public int numberOfGood = 0;

    private bool timerActive;

    public void RemoveSignal(Signal signal)
    {
        if (signal.type == SignalType.Bad)
        {
            numberOfBad--;
        }
        if (signal.type == SignalType.Good)
        {
            numberOfGood--;
        }
    }
    
    public void AddSignal(Signal signal)
    {
        if (signal.type == SignalType.Bad)
        {
            numberOfBad++;
        }
        if (signal.type == SignalType.Good)
        {
            numberOfGood++;
        }
    }

    private void Update()
    {
            if (numberOfGood != 0 && numberOfBad <=0)
            {
                if (timerActive == false)
                {
                    StartCoroutine(DelayForCheck());
                }
            }
    }

    private IEnumerator DelayForCheck()
    {
        timerActive = true;
        yield return new WaitForSeconds(2f);
        
        if (numberOfGood != 0 && numberOfBad <=0)
        {
            // LevelChanger.Instance.RoundFinished();
            // PauseMenu.Instance.CallNextLevel();
        }

        timerActive = false;
    }
}