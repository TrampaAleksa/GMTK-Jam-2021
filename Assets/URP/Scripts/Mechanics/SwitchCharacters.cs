using _Project.Aleksa;
using _Project.Aleksa.Sounds;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
    [SerializeField]
    PlayerArrow arrow;

    GameObject[] characters;
    GameObject[] handsCollider;
    Movement[] movementScripts;
    int i = 0;
    void Awake()
    {
        arrow = Instantiate(arrow.gameObject).GetComponent<PlayerArrow>();        
        characters = GameObject.FindGameObjectsWithTag("Character");
        handsCollider = GameObject.FindGameObjectsWithTag("Hands");
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
            handsCollider[i].SetActive(false);
        }
    }
    void ActivateFirstCharacter()
    {
        movementScripts[0].enabled = true;
        movementScripts[0].GetComponent<Rigidbody>().mass /= 10;
        handsCollider[0].SetActive(true) ;
    }
    void ChangeCharacters()
    {
        //Deactivate current character
        handsCollider[i].SetActive(false);
        movementScripts[i].enabled = false;       
        movementScripts[i].GetComponent<Rigidbody>().mass *= 10;
        movementScripts[i++].GetComponentInChildren<Animator>().SetBool("isWalking", false);
        
        //Activate new character
        if (i == characters.Length)
            i = 0;
        handsCollider[i].SetActive(true);
        movementScripts[i].enabled = true;       
        movementScripts[i].GetComponent<Rigidbody>().mass /= 10;
        arrow.SetNewPlayer(characters[i].transform);
        AudioHolder.Instance.SwapCharacters();
    }
}