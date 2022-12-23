using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float healthLoss;


    private void Start()
    {
        
    }
    private void Update()
    {
        if(health<=0f)
        {
            destoryGameobject();
        }
    }
    public void damage()
    {
        health -= healthLoss;
    }
    public void damage(float x)
    {
        health -= x;
    }
    private void destoryGameobject()
    {
        //Debug.Log("object destroyed " + gameObject.name);
        Destroy(gameObject);
    }

}
