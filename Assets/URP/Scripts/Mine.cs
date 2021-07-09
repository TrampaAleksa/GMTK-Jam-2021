using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] MineColor mineColor;

    string rec;

    enum MineColor
    {
        red,
        green
    };
    // Start is called before the first frame update
    void Start()
    {
        print(mineColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            if (mineColor.ToString().Equals(other.GetComponent<Character>().color.ToString()))
            {
                RestoreSignal();
            }
            else
            {
                InteruptSignal();
            }
                
        }
    }
    void RestoreSignal()
    {

    }
    void InteruptSignal()
    {

    }
}
