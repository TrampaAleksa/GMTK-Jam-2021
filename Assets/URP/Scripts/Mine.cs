using _Project.Aleksa.Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] MineColor mineColor;

    Signal signal;
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {           
            numberOfCharacter = other.name.Substring(5);
            for (int i = 0; i < everySignal.Length; i++)
            {
                if (everySignal[i].name.Contains(numberOfCharacter))
                {
                    particularSignal[numberOfParticularSignals++] = everySignal[i];
                }
            }
            if (numberOfParticularSignals > 0)
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
    }
    void RestoreSignal()
    {
        for (int i = 0; i < numberOfParticularSignals; i++)
        {
            particularSignal[i].GetComponent<Signal>().onMine = false;
        }
    }
    void InteruptSignal()
    {
        for (int i = 0; i < numberOfParticularSignals; i++)
        {
            particularSignal[i].GetComponent<Signal>().onMine = true;
        }
    }
}
