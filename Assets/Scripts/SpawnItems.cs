using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
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
        if (tempTimer > 2f)
        {
            float randomX = Random.value * 8;
            Vector2 tempPos = new Vector2(randomX,spawnArea.transform.position.y);
            Debug.Log(tempPos);
            Instantiate(ItemPrefab, tempPos, Quaternion.identity);
            tempTimer = 0f;
        }    
    }



}
