using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Raycast_handler : MonoBehaviour
{
    [Header("camera")]
    [SerializeField] float cameraDistance;
    [Space]
    [Header("tags")]
    [SerializeField] string earthTag;
    [SerializeField] string waterTag;
    [SerializeField] string earthHintTag;
    [SerializeField] string waterHintTag;
    private string ObjectTag;
    [Space]
    [Header("hintObject")]
    public GameObject hintObject;
    //[SerializeField] GameObject hintTile;
    [SerializeField] Vector3 hitPoint;
    [SerializeField] Vector3 direction;
    [Space]
    [Header("scripts")]
    [SerializeField] resource_handler resource_handler_script;
    private void Start()
    {
        hintObject = resource_handler_script.getAHintObject("Earth");
    }

    private void Update()
    {
        ObjectTag = getRaycast();

        // Object creation
        {
            if (ObjectTag != null)
            {
                if (ObjectTag == earthTag)
                {
                    // hint the earth Objects

                    if (hintObject == null || hintObject.tag == waterHintTag)
                        hintObject = resource_handler_script.getAHintObject(ObjectTag);
                    else
                        setTheHintObjects();

                }
                else if (ObjectTag == waterTag)
                {
                    //hint the water Objects

                    if (hintObject == null || hintObject.tag == earthHintTag)
                        hintObject = resource_handler_script.getAHintObject(ObjectTag);
                    else
                        setTheHintObjects();
                }
                else if (ObjectTag == earthHintTag || ObjectTag == waterHintTag)
                {
                   // Debug.Log("raycast falling on hint object");

                }
                else
                {
                    resource_handler_script.destroyExistingHintObjects();
                }


            }
            else
            {
                resource_handler_script.destroyExistingHintObjects();
            }
        }


    }
    public void changeHintObject()
    {
        if (hintObject != null)
        {
            
            resource_handler_script.changeHintObjectValue();
            resource_handler_script.getAHintObject(ObjectTag);
        }
    }

    void setTheHintObjects()
    {
        hintObject.transform.position = hitPoint;
        hintObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

    }
    string getRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, cameraDistance))
        {
            hitPoint = hit.point;
            direction = hit.normal;
            return hit.collider.tag;

        }
        else
            return null;
    }

    public Vector3 getCursorPosition()
    {
        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance);
        return (Camera.main.ScreenToWorldPoint(pos));
    }
    




    /* [SerializeField] float cameraDistance;
     [SerializeField] Transform earthCenter;
     [SerializeField] Transform mainCamera;

     [Space]
     [Header("layer")]
     [SerializeField] LayerMask tilesLayer;
     [SerializeField] LayerMask earthLayer;

     [Space]
     [Header("raycastObject")]
     [SerializeField] GameObject currentObject;
     [SerializeField] GameObject currentTile;
     [SerializeField] GameObject tileToInstantiate;
     [Space]
     [Header("Scripts")]
     [SerializeField] Tiles_manager tileManager;
     private void Start()
     {
         //getRaycast();
         currentTile.GetComponent<MeshRenderer>().enabled = false;
         currentObject.GetComponent<MeshRenderer>().enabled = false;
     }

     private void FixedUpdate()
     {
         //getRaycast();
         getraycastPlace();
         if(Input.GetMouseButtonDown(0))
         {
             GameObject g = getTile();
             if(g!=null)
             tileManager.instantiate_object(tileToInstantiate);
         }
     }
     public void getraycastPlace()
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
         if(Physics.Raycast(ray,out hit,cameraDistance,earthLayer,QueryTriggerInteraction.Collide))
         {
             currentTile.GetComponent<MeshRenderer>().enabled = true;
             currentTile.transform.position = hit.point;
             currentTile.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
         }
         else
         {
             currentTile.GetComponent<MeshRenderer>().enabled = false;

         }
     }
     public GameObject getTile()
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit, cameraDistance, tilesLayer, QueryTriggerInteraction.Ignore))
         {
             tileToInstantiate = hit.collider.transform.gameObject;
             return tileToInstantiate;
         }
         else
         {
             return null;
         }
     }
     public void getRaycast()
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit, cameraDistance, tilesLayer))
         {
             Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);

             GameObject g = hit.collider.transform.gameObject;


             {
                 currentObject.GetComponent<MeshRenderer>().enabled = true;
                 currentTile.GetComponent<MeshRenderer>().enabled = true;

                 currentObject.transform.position = hit.point;
                 currentObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

                 currentTile.transform.position = g.transform.position;
                 currentTile.transform.rotation = g.transform.rotation;
             }
         }
         else
         {
             currentObject.GetComponent<MeshRenderer>().enabled = false;
             currentTile.GetComponent<MeshRenderer>().enabled = false;
         }
     }*/
    /*public Vector3 getCursorPosition()
     {
         Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance);
         return (Camera.main.ScreenToWorldPoint(pos));
     }*/

}
