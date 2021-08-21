using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public float wide;
    public float length;

    public int enemy1Count;
    public int enemy2Count;
    public int enemy3Count;

    private float PosX;
    private float PosZ;
    private int currentCount = 0;
    private bool ended;

    public Vector3 offset;

    public Vector3 rotate;

    public bool mainSpawner;
    private bool used = false;

    public Camera MainCamera;

    private GameController gm;


    private void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        gm = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        
        if(mainSpawner)
        {
            transform.position = new Vector3 (transform.position.x,transform.position.y, MainCamera.transform.position.z + offset.z); 
            
        }

        if (gm.GameStarted && !used)
        {
            StartCoroutine(SpawnEnemy());
            used = true;
        }

        if (gm.GameEnded)
            StopCoroutine(SpawnEnemy());
    }

    public void SpawnMore()
    {
        if (mainSpawner&&ended)
        {
            currentCount = 0;
            StartCoroutine(SpawnEnemy());
        }
    }


    IEnumerator SpawnEnemy()
    {
        ended = false;
        Debug.Log("Stawrrearsdf");
        while (currentCount < enemy1Count)
        {
            PosX = Random.Range(transform.position.x - wide, transform.position.x + wide);
            PosZ = Random.Range(transform.position.z - length, transform.position.z + length);
            Instantiate(enemy1, new Vector3(PosX, 0.1f, PosZ), Quaternion.Euler(rotate));
            yield return new WaitForSeconds(0.1f);
            currentCount += 1;
        }
        currentCount = 0;
        while (currentCount < enemy2Count)
        {
            PosX = Random.Range(transform.position.x - wide, transform.position.x + wide);
            PosZ = Random.Range(transform.position.z - length, transform.position.z + length);
            Instantiate(enemy2, new Vector3(PosX, 0.1f, PosZ), Quaternion.Euler(rotate));
            yield return new WaitForSeconds(0.1f);
            currentCount += 1;
        }
        currentCount = 0;
        while (currentCount < enemy3Count)
        {
            PosX = Random.Range(transform.position.x - wide, transform.position.x + wide);
            PosZ = Random.Range(transform.position.z - length, transform.position.z + length);
            Instantiate(enemy3, new Vector3(PosX, 0.1f, PosZ), Quaternion.Euler(rotate));
            yield return new WaitForSeconds(0.1f);
            currentCount += 1;
        }
        ended = true;
        StopCoroutine(SpawnEnemy());
        if (!mainSpawner)
            Destroy(this.gameObject);
    }

}
