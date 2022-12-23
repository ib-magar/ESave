using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]
public class Tiles_manager : MonoBehaviour
{
    
    [Header("Tiles")]
    [SerializeField] GameObject tiles;
    [SerializeField] float radius;
    [SerializeField] Transform target;
    Transform currentTile;
    [Space]
    [Header("Tiles and Objects Data")]
    [SerializeField] List<GameObject> EmptyTiles;
    [SerializeField] List<GameObject> EarthTiles;
    [SerializeField] List<GameObject> WaterTiles;
    [SerializeField] List<GameObject> objectsList;

    [Space]
    [Header("materials")]
    [SerializeField] Material non_empty;
   

    [Space]
    [Header("Scripts")]
    public resource_handler resource_handler_script;


    private void Start()
    {
        tilesManager();

        //EmptyTiles = new GameObject[tiles.transform.childCount];
        EmptyTiles = new List<GameObject>();
        EarthTiles = new List<GameObject>();
        WaterTiles = new List<GameObject>();
        objectsList = new List<GameObject>();
        getTileObjects();
       
    }

    private void Update()
    {
        //tilesManager();
       /* if(Input.GetKeyDown(KeyCode.A))
        {
            GameObject emptyTile = getrandomTile("Earth");
            if(emptyTile!=null && emptyTile.transform.childCount==0)            // can remove the checking as the value are stored and removed throught previous checkingt
            {
                
                instantiate_object(emptyTile);
                
            }
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            GameObject emptyTile = getrandomTile("Water");
            if (emptyTile != null && emptyTile.transform.childCount == 0)
            {

                instantiate_object(emptyTile);

            }
        }*/
        /*else if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Empty_tiles: "+EmptyTiles.Count);
            Debug.Log("Earth_tiles: " + EarthTiles.Count);
            Debug.Log("Water_tiles: " + WaterTiles.Count);
            Debug.Log("objects_list:" + objectsList.Count);
        }*/
    }
   public void instantiate_object(GameObject emptyTile)
    {
        // object instantiation
        {
            GameObject o = resource_handler_script.getAobject(emptyTile.tag.ToString());            // gettting the object type according to the tile tag
            GameObject obj = Instantiate(o, emptyTile.transform.position, Quaternion.identity);
            obj.transform.rotation = Quaternion.FromToRotation(Vector3.up, (emptyTile.transform.position - target.position));   // giving the opposite direction to this object coz the tile position is negative and object faces toward the center not outward
            if (emptyTile.CompareTag("EarthTile"))
                obj.transform.localScale = new Vector3(.06f, .06f, .06f);                   // setting the scale of the object instantiated
            else
                obj.transform.localScale = new Vector3(.16f, .16f, .16f);
            obj.transform.SetParent(emptyTile.transform);                                           // set the instantiated object as the child of the tile
        }
        // updating the data
        {
            EmptyTiles.Remove(emptyTile);               //removing the object from empty tiles
            objectsList.Add(emptyTile);                    // adding to the objects list
            if (emptyTile.CompareTag("EarthTile"))
            {
                EarthTiles.Remove(emptyTile);
            }
            else if (emptyTile.CompareTag("WaterTile"))
            {
                WaterTiles.Remove(emptyTile);
            }
        }
    }
    void getTileObjects()
    {
        for(int i=0;i<tiles.transform.childCount;i++)
        {
            GameObject currentTile = tiles.transform.GetChild(i).gameObject;    
            //EmptyTiles[i] = tiles.transform.GetChild(i).gameObject;     // storing each tile object into data
            EmptyTiles.Add(currentTile);
            if(currentTile.CompareTag("EarthTile"))
            {
                EarthTiles.Add(currentTile);
            }
            else
            {
                currentTile.tag = "WaterTile";
                WaterTiles.Add(currentTile);
               
            }
           
        }
        
    }
    GameObject  getrandomTile(string tileType)
    {
        if (tileType == "Earth")
        {
            int value = UnityEngine.Random.Range(0, EarthTiles.Count);
            
            EmptyTiles[value].GetComponent<MeshRenderer>().material = non_empty;        // changing the material of the tile 
            return EarthTiles[value];
        }
        else
        {
            int value = UnityEngine.Random.Range(0, WaterTiles.Count);

            EmptyTiles[value].GetComponent<MeshRenderer>().material = non_empty;        // changing the material of the tile 
            return WaterTiles[value];
        }
        
      
                                     
    }
    public void tilesManager()
    {
        for (int i = 0; i<tiles.transform.childCount; i++)
        {
            currentTile = tiles.transform.GetChild(i).transform;        // getting the current tile object
            
            Debug.DrawLine(target.position, currentTile.position, Color.red);

            Vector3 dir = target.position - currentTile.transform.position;
            currentTile.rotation = Quaternion.FromToRotation(Vector3.up, dir);


            currentTile.position = (target.position) - (dir.normalized * radius);
        }
    }

}
