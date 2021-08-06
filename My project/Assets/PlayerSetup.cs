using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerSetup : MonoBehaviour
{


    [SerializeField]
    GameObject playerUIprefab;
    private GameObject PlayerUIInstance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerUIInstance = Instantiate(playerUIprefab);
        PlayerUIInstance.name = playerUIprefab.name;


        PlayerUI ui = PlayerUIInstance.GetComponent<PlayerUI>();
        ui.SetController (GetComponent<PlayerController>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
