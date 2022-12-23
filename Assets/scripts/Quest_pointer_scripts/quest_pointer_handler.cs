using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest_pointer_handler : MonoBehaviour
{

    [SerializeField] GameObject quest_pointer;
    [SerializeField] Transform quest_holder;
    public  void generatePointer(GameObject g)
    {
        GameObject p = Instantiate(quest_pointer, quest_holder.position, Quaternion.identity);
        p.transform.SetParent(quest_holder);
        p.GetComponent<quest_pointer>().target = g.transform;
        
    }

}
