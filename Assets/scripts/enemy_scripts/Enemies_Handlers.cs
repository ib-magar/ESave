using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Handlers : MonoBehaviour
{
    [Header("Enmies arrays")]
    [SerializeField] Enemies[] EnemiesGroup;
    [Space]
    [SerializeField] bool coroutineAllowed;
    [SerializeField] int EnemiesWave;
    [Header("current Wave variables")]
    [SerializeField] int enemiesCount;
    [SerializeField] float WaveGapTime;
    [Header("enemy generation variables")]
    [SerializeField] GameObject enemy;
    [SerializeField] float xVal;
    [SerializeField] float yVal;
    [Header("time variable")]
    [SerializeField] float timeVar;
    private float timeCounter;
    [SerializeField] quest_pointer_handler quest_handler;
    private void Start()
    {
        EnemiesWave = 0;
        //coroutineAllowed = true;
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if(coroutineAllowed)
        {
            
            timeCounter += Time.deltaTime;
            //Debug.Log("coroutine allowed");
            if (timeCounter >= timeVar)
            {
                timeCounter = 0f;
                StartCoroutine(StartWave());
            }
        }
    }
    IEnumerator StartWave()
    {
        //Debug.Log("EnemiesWave: " + EnemiesWave);
        coroutineAllowed = false;
        enemiesCount = EnemiesGroup[EnemiesWave++].EnemiesNumber;
        int count=0;
        while(count<enemiesCount)        
        {
            count++;
            Vector3 pos = new Vector3(Random.Range(-xVal, xVal), Random.Range(-yVal, yVal), 0f);
            GameObject g = Instantiate(enemy,pos, Quaternion.identity);

            if(quest_handler.GetComponent<quest_pointer_handler>()!=null)
            quest_handler.GetComponent<quest_pointer_handler>().generatePointer(g);

            g.transform.SetParent(transform);
            yield return new WaitForSeconds(1f);

        }
        EnemiesWave %= EnemiesGroup.Length;
        coroutineAllowed = true;
    }


}
