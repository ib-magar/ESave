using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyClass :MonoBehaviour
{
    [Header("Variables")]
    public float health;
    public Transform target;
    public float speed;
    public float power;
    

    [Space]
    [Header("Tags")]
    public string earthObjectTag;
    public string waterObjectTag;
    

    private void Awake()
    {
        target = GameObject.FindWithTag("Earth").transform;
    }

}
