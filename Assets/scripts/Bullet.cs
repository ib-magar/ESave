using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class bullet
{

    public int damageAmount;

    public void giveDamage(GameObject objectTogiveDamage)
    {

        // Give Damage to the object when bullet collides
        /*if(objectTogiveDamage.GetComponent<Health>()!=null)
        {
            objectTogiveDamage.GetComponent<Health>().takeDamage(damageAmount);
        }*/
    }

}
