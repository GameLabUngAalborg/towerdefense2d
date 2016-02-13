using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    public List<WaveInfo> Waves = new List<WaveInfo>();
    public int WaveNumber = 0;
    public GameObject EnemyPrefab;
    public Transform StartSpawnLocation;
    public List<Transform> WayPoints = new List<Transform>();

    public void NextWave()
    {
       StartCoroutine(SpawnEnemies());
       
    }

    IEnumerator SpawnEnemies()
    {
        // WaveNumber er stadig 0 her, derfor får den første enemy fra listen
        for(int i = 0; i < Waves[WaveNumber].AmountOfEnemiesToSpawn; i++)
        {
            GameObject tmp = Instantiate(EnemyPrefab) as GameObject;
            tmp.transform.position = StartSpawnLocation.position;

            tmp.GetComponent<Enemy>().WayPoints = WayPoints;

            yield return new WaitForSeconds(Waves[WaveNumber].SpawnRate);
        }

        WaveNumber++;
    }

    // Use this for initialization
    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;

        for (int i = 0; i < WayPoints.Count; i++)
        {
            if (i == 0)
            {
                Gizmos.DrawLine(WayPoints[0].position, WayPoints[1].position);
            }
            else if (i == WayPoints.Count - 1)
            {

            }
            else
            {
                int nextNumber = i + 1;
                Gizmos.DrawLine(WayPoints[i].position, WayPoints[nextNumber].position);
            }


        }


    }

}

[System.Serializable]
public class WaveInfo
{
    // Er ikke lavet dynamisk til forskellige enemies per runde (med vilje)
    public int AmountOfEnemiesToSpawn = 1;
    public Sprite EnemySprite;
    public int EnemyHealth = 1;
    public float SpawnRate = 0.2f;


}
