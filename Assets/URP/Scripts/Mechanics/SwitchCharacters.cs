using _Project.Aleksa;
using _Project.Aleksa.Sounds;
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
        InitializeCharacters();       
        arrow.SetNewPlayer(characters[0].transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        ActivateFirstCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) ChangeCharacters(); 
    }
    void InitializeCharacters()
    {
        movementScripts = new Movement[characters.Length];
        for (int i = 0; i < characters.Length; i++)
        {
            movementScripts[i] = characters[i].GetComponent<Movement>();           
            //movementScripts[i].enabled = false;
        }
    }
    void ActivateFirstCharacter()
    {
        movementScripts[0].enabled = true;
        movementScripts[i].GetComponent<Rigidbody>().mass /= 10;
    }
    void ChangeCharacters()
    {

        movementScripts[i].enabled = false;
        movementScripts[i].GetComponent<Rigidbody>().mass *= 10;
        movementScripts[i++].GetComponentInChildren<Animator>().SetBool("isWalking", false);
        if (i == characters.Length)
            i = 0;
        movementScripts[i].enabled = true;
        movementScripts[i].GetComponent<Rigidbody>().mass /= 10;
        arrow.SetNewPlayer(characters[i].transform);
        AudioHolder.Instance.SwapCharacters();
    }
    //public void ChangeCharactersOnButton() => ChangeCharacters();
}