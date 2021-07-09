using _Project.Aleksa.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] MineColor mineColor;

    GameObject[] everySignal;
    GameObject[] particularSignal;
    int numberOfParticularSignals = 0;
    string numberOfCharacter;

    enum MineColor
    {
        red,
        green
    };
    private void Awake()
    {
        everySignal = GameObject.FindGameObjectsWithTag("Signal");
        particularSignal = new GameObject[everySignal.Length];  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            FindEverySignalThatGoesThroughCharacter(other.gameObject);
            ChangeSignals(other.gameObject);     
        }
    }
    private void RestoreSignal()
    {
        for (int i = 0; i < numberOfParticularSignals; i++)
        {
            particularSignal[i].GetComponent<Signal>().onMine = false;
        }
    }
    private void InteruptSignal()
    {
        for (int i = 0; i < numberOfParticularSignals; i++)
        {
            particularSignal[i].GetComponent<Signal>().onMine = true;
        }
    }
    private void FindEverySignalThatGoesThroughCharacter(GameObject other)
    {
        numberOfCharacter = other.name.Substring(5);
        for (int i = 0; i < everySignal.Length; i++)
        {
            if (everySignal[i].name.Contains(numberOfCharacter))
            {
                particularSignal[numberOfParticularSignals++] = everySignal[i];
            }
        }
    }

    private void ChangeSignals(GameObject other)
    {
        if (mineColor.ToString().Equals(other.GetComponent<Character>().color.ToString()))
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
