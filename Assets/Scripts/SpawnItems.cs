using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    private Transform spawnArea;
    [SerializeField]
    public GameObject ItemPrefab;


    private float tempTimer = 0f;

    private void Update()
    {
        SpawnItemPrefab();
    }

    void SpawnItemPrefab()
    {
        tempTimer += Time.deltaTime;
        if (tempTimer > 5f)
        {
            float randomX = Random.value * 1000;
            //spawnArea.transform.position = new Vector3(randomX, 500f, 0f);
            //Instantiate(ItemPrefab,spawnArea);
            tempTimer = 0f;
        }    
    }



}
