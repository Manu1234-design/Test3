using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{


    [SerializeField]
    RectTransform thrusterFuelFill;

    private PlayerController controller;


    public void SetController(PlayerController _controller){
        controller = _controller;
    }


    void SetFuelAmount (float _amount){
        thrusterFuelFill.localScale = new Vector3 (1f, _amount, 1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       SetFuelAmount (controller.GetThrusterFuelAmount());
    }
}
