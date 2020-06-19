using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSpawnnerPedra : MonoBehaviour
{
    float tempo1 = 0f;
    float tempoRandomSpawn1 = 0.3f;
    bool podePedra = true;

    public GameObject pedraPrefab;
    public GameObject spawnPosition1;
    void Update()
    {
        tempoRandomSpawn1 = Random.RandomRange(0.4f, 1.5f);
        tempo1 += Time.deltaTime;
        
        if(tempo1 >= 1f && podePedra){
            Invoke("SpawnPedra", tempoRandomSpawn1);
            tempo1 = 0f;
            
        }
    }

    void SpawnPedra(){
        GameObject apedraPrefab = (GameObject)Instantiate(pedraPrefab);
        apedraPrefab.transform.position = spawnPosition1.transform.position;
    }
}
