using UnityEngine;
using System.Collections;


public class EarthSpinScript : MonoBehaviour {
    public float speed = 10f;

    [Space]
    [Header("inputs")]
    [SerializeField] float horizontalInput;
    [SerializeField] float VerticalInput;

    void Update() {
        getInput();
        //transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
        transform.eulerAngles += new Vector3(0f,horizontalInput*Time.deltaTime, 0f);
    }
    void getInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            VerticalInput = speed*2;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            VerticalInput = -speed;
        }
        else
            VerticalInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = speed*4;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = -speed*4;
        }
        else
            horizontalInput = speed;



    }
}