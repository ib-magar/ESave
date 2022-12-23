using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quest_pointer : MonoBehaviour
{


    public Transform target;
    private RectTransform pointerPosition;
    private Vector3 direction;
    private bool targetOffscreen;
    [SerializeField] float screenOffset;
    private Transform Earth;
    private Vector3 targetObjectScreenPoint;

    private float distance=1f;
    private Color c;

    [SerializeField] float distanceFromEarth;


    private void Start()
    {
        Earth = GameObject.FindGameObjectWithTag("Earth").transform;
        pointerPosition = GetComponent<RectTransform>();
        c = GetComponent<RawImage>().color;
        distance = Mathf.Abs( Vector3.Distance( target.position,transform.position));
        distanceFromEarth = Screen.height / 4f;
    }
   /* public void setTarget(Transform t)
    {
        target = t;
    }*/
    private void Update()
    {
        transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
        if (target != null)
        {
            // boolean for the target object offscreen
            {
                targetObjectScreenPoint = Camera.main.WorldToScreenPoint(target.position);
                targetOffscreen = targetObjectScreenPoint.x <= 0f || targetObjectScreenPoint.x >= Screen.width || targetObjectScreenPoint.y <= 0f || targetObjectScreenPoint.y >= Screen.height;
            }

            //rotation
            {
                direction = target.position - (new Vector3(Earth.position.x, Earth.position.y, 0f));
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                transform.localEulerAngles = new Vector3(0f, 0f, angle);
            }
            if (targetOffscreen)
            {
                //change the color
                {
                    float a = (Vector3.Distance(target.position, transform.position) / distance);
                    c.a = 1-a;
                    c.r = 1 - a;
                    c.g = a;
                    c.b = a;
                    GetComponent<RawImage>().color = c;
                    
                }

                Vector3 pointerCappedPositon = targetObjectScreenPoint;
                if (pointerCappedPositon.x < 0f) pointerCappedPositon.x = 0f + screenOffset;
                if (pointerCappedPositon.x > Screen.width) pointerCappedPositon.x = Screen.width - screenOffset;
                if (pointerCappedPositon.y < 0f) pointerCappedPositon.y = 0f + screenOffset;
                if (pointerCappedPositon.y > Screen.height) pointerCappedPositon.y = Screen.height - screenOffset;

                pointerPosition.position = Camera.main.ScreenToWorldPoint(pointerCappedPositon);


                //pointerPosition.position = player.position + (direction.normalized * screenOffset);

            }
            else
            {
                if (Vector3.Distance(target.position, Earth.position) > 3f)
                {
                    
                    transform.position = target.position - (direction.normalized*0.2f);
                }
                else
                    Destroy(gameObject);
                
            }

        }
        else
        {
            Destroy(gameObject);
            //Debug.Log("Target for the pointer is null");
        }
        
    }
}
