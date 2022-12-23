using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class resource_handler : MonoBehaviour
{

   
    [Header("Lists")]
    [SerializeField] GameObject[] Trees;
    [SerializeField] GameObject[] mushrooms;
    [SerializeField] GameObject[] stones;
    [Space]
    [Header("tags")]
    [SerializeField] string earthTag;
    [SerializeField] string waterTag;
    [SerializeField] string earthHintTag;
    [SerializeField] string waterHintTag;
    [SerializeField] string earthObjectTag;
    [SerializeField] string waterObjectTag;
    [Space]
    [Header("hint Object")]
    GameObject hintObject;
    [Space]
    [Header("Scripts")]
    [SerializeField] Raycast_handler raycast_handler_script;
    [Space]
    [Header("ParentObjects")]
    [SerializeField] Transform earthObjectsParent;
    [SerializeField] Transform waterObjectsParent;
    [Space]
    [Header("Objects_arrays")]
    [SerializeField] List<GameObject> EarthObjectsList;
    [SerializeField] List<GameObject> WaterObjectsList;
    [Space]
    [Header("object values")]
    [SerializeField] int earthObjectValue;
    [SerializeField] int waterObjectValue;
    
    private void Start()
    {
        
    }
    public GameObject  getAobject(string objectType)
    {
        if(objectType=="EarthTile")
        {
            int value = Random.Range(0, Trees.Length);
            return Trees[value];
        }
        else if(objectType=="WaterTile")
        {
            int value = Random.Range(0, stones.Length);
                return stones[value];
        }
        else
        {
            Debug.Log(objectType);
            return null;
        }
    }
    public void destroyExistingHintObjects()
    {
        GameObject a = GameObject.FindGameObjectWithTag(earthHintTag);
        GameObject b = GameObject.FindGameObjectWithTag(waterHintTag);
        if (a != null)
            // Destroy(a.gameObject);
            DestroyImmediate(a.gameObject);
        if (b != null)
            //Destroy(b.gameObject);
            DestroyImmediate(b.gameObject);
    }
    public void changeHintObjectValue()
    {
        if (hintObject.tag == earthHintTag)
            earthObjectValue = ++earthObjectValue % Trees.Length;
        else if (hintObject.tag == waterHintTag)
            waterObjectValue = ++waterObjectValue % stones.Length;
    }
    public  GameObject getAHintObject(string objectOfType)
    {

        destroyExistingHintObjects();
        // Hint object instantiation
        {
            if (objectOfType == earthTag)
            {
                
                hintObject = Instantiate(Trees[earthObjectValue], Vector3.zero, Quaternion.identity);

                hintObject.transform.SetParent(transform);
                hintObject.transform.tag = earthHintTag;
                return hintObject;

            }
            else if (objectOfType == waterTag)
            {

                hintObject = Instantiate(stones[waterObjectValue], Vector3.zero, Quaternion.identity);

                hintObject.transform.SetParent(transform);
                hintObject.transform.tag = waterHintTag;
                return hintObject;

            }
            return null;                // default return
        }

    }
    public void insertObject()
    {
        GameObject objectToInsert = raycast_handler_script.hintObject;
        if (objectToInsert != null)
        {
            GameObject obj = Instantiate(raycast_handler_script.hintObject, objectToInsert.transform.position, objectToInsert.transform.rotation);
            if (objectToInsert.tag == earthHintTag)
            {
                obj.tag = earthObjectTag;
                obj.transform.SetParent(earthObjectsParent);
                EarthObjectsList.Add(obj);
                //Debug.Log(EarthObjectsList.Count);
            }
            else if (objectToInsert.tag == waterHintTag)
            {
                obj.tag = earthObjectTag;
                obj.transform.SetParent(waterObjectsParent);
                WaterObjectsList.Add(obj);
                //Debug.Log(WaterObjectsList.Count);
            }
            // update the objects data 
        }
    }
}
