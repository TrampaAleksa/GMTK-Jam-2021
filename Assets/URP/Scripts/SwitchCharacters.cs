using _Project.Aleksa;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    public PlayerArrow arrow;

    GameObject[] characters;
    Movement[] movementScripts;
    int i = 0;
    private void Awake()
    {
        arrow = Instantiate(arrow.gameObject).GetComponent<PlayerArrow>();
        
        characters = GameObject.FindGameObjectsWithTag("Character");
        movementScripts = new Movement[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            movementScripts[i] = characters[i].GetComponent<Movement>();
            //movementScripts[i].enabled = false;
        }
        
        arrow.SetNewPlayer(characters[0].transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        movementScripts[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            movementScripts[i++].enabled = false;
            if (i == characters.Length)
                i = 0;
            movementScripts[i].enabled = true;
            
            arrow.SetNewPlayer(characters[i].transform);
            AudioHolder.Instance.SwapCharacters();
        }
    }
}