using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    float health;
    Transform target;
    float speed;
    float power;
    private void Start()
    {
        target = GetComponent<EnemyClass>().target;
        health = GetComponent<EnemyClass>().health;
        speed = GetComponent<EnemyClass>().speed;
        power = GetComponent<EnemyClass>().power;
    }
    private void Update()
    {
        if(health<=0f)
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.gameObject);
        objectScript s = collision.collider.GetComponent<objectScript>();
        if(s!=null)
        {
            //Debug.Log("object found and damaged");
            s.damage(power);
        }
        health = 0f;
       
    }
    

}
