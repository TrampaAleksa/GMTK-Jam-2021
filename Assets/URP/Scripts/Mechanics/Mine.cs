using _Project.Aleksa.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] MineType mineType;

    Signal[] everySignal;
    Signal[] particularSignal;
    int numberOfParticularSignals = 0;

    enum MineType
    {
        Mine,
        RepairTool
    };
    void Awake()
    {
        everySignal = FindObjectsOfType<Signal>();
        particularSignal = new Signal[everySignal.Length];  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            FindEverySignalThatGoesThroughCharacter(other.gameObject);
            ChangeSignals(other.gameObject);     
        }
    }
    void RestoreSignal()
    {
        for (int i = 0; i < numberOfParticularSignals; i++)
        {
            particularSignal[i].onMine = false;
        }
    }
    void InteruptSignal()
    {
        for (int i = 0; i < numberOfParticularSignals; i++)
        {
            particularSignal[i].onMine = true;
        }
    }
    void FindEverySignalThatGoesThroughCharacter(GameObject other)
    {
        for (int i = 0; i < everySignal.Length; i++)
        {
            string characterName = other.transform.name;
            if (characterName == everySignal[i].character1.name || characterName == everySignal[i].character2.name)
            {
                particularSignal[numberOfParticularSignals++] = everySignal[i];
            }
        }
    }

    void ChangeSignals(GameObject other)
    {
        if (mineType.ToString().Equals("RepairTool"))
        {
            RestoreSignal();
        }
        else
        {
            InteruptSignal();
        }
        numberOfParticularSignals = 0;
    }
}
