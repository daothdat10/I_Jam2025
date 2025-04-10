using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
           
    public int poolAmount = 4;         
    public GameObject[] randomObjects;  

    /*public GameObject[] targets;*/
    // GameObject[] pool;
    Queue<GameObject> pool;              
    int currentIndex = 0;               
    public Transform[] spawnPoints; 
    
    

    private void Awake()
    {
        //Time.timeScale = 0f;
    }


    void Start()
    {

        spawnEnemy();
    }

    private void spawnEnemy()
    {
            pool = new Queue<GameObject>();
            GameObject obj;
            for (int i = 0; i < poolAmount; i++)
            {
            
                int randomIndex = Random.Range(0, randomObjects.Length);
                obj = Instantiate(randomObjects[randomIndex], Vector3.zero, Quaternion.identity);
                obj.SetActive(false);
                /*LineRenderer lineRenderer = obj.AddComponent<LineRenderer>();
                obj.transform.SetParent(transform);
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
                lineRenderer.material = new Material(Shader.Find("Sprites/Default")) { color = Color.red };
                lineRenderer.enabled = false;*/
                
                pool.Enqueue(obj);
            }

            //InvokeRepeating("Fire", fireTime, fireTime);
            StartCoroutine(spawnFire());
    }

    IEnumerator spawnFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Fire();
            yield return new WaitForSeconds(20);
        }
    }
    
    void Fire()
    {
        
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("Không có điểm sinh ra nào được chỉ định!");
            return;
        }

        // random lay 1 doi tuong
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
       
        Transform spawnPoint = spawnPoints[randomSpawnIndex];
        //Transform targetPo = targets[randomSpawnIndex].transform;
        
        
        GameObject obj =pool.Dequeue();
        // di chuyen toi tuong ke tiep vao pool
        if (++currentIndex >= pool.Count)
        {
            currentIndex = 0;
        }
        
        StartCoroutine(ShowWarningLine(obj, spawnPoint.position));

       
    }

    

    IEnumerator ShowWarningLine(GameObject obj, Vector3 spawnPosition)
    {
        while (true)
        {
            
            /*LineRenderer lineRenderer = obj.GetComponent<LineRenderer>();
            // Hiển thị đường đỏ
            lineRenderer.enabled = true;
           
            lineRenderer.SetPosition(0, targetPosition); //cac diem cho tia
            lineRenderer.SetPosition(1, spawnPosition);   //cac diem spawn
            
            yield return new WaitForSeconds(0.5f);
            lineRenderer.enabled = false;*/
            // Kích hoạt đối tượng
            obj.transform.position = spawnPosition;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
            
            yield return new WaitForSeconds(3f);
            obj.SetActive(false);
            /*lineRenderer.enabled = true;*/
            pool.Enqueue(obj);
            
            
        }
       
    }
    
}
