using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class input_manager : MonoBehaviour
{
    [Header("keys")]
    [SerializeField] KeyCode objectChangeKey;
    [Header("Scripts")]
    [SerializeField] Raycast_handler raycast_handler_script;
    [SerializeField] resource_handler resource_handler_script;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(objectChangeKey))
        {
            raycast_handler_script.changeHintObject();

        }
        if(Input.GetMouseButtonDown(0))
        {
            resource_handler_script.insertObject();
        }
        

    }

}
