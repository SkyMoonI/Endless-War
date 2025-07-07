using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount=0;
    public int randomField=0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {

        while (true)
        {
            if (randomField==0) 
            {
                xPos = Random.Range(260,262);
                zPos = Random.Range(260,265);
                randomField++;
            }
            else if (randomField == 1)
            {
                xPos = Random.Range(230,235);
                zPos = Random.Range(260,265);
                randomField++;
            }
            else if (randomField == 1)
            {
                xPos = Random.Range(230, 235);
                zPos = Random.Range(230,235);
                randomField++;
            }
            else
            {
                xPos = Random.Range(258,263);
                zPos = Random.Range(235,240);
                randomField =0;
            }
            theEnemy.GetComponent<Skeleton>().hp = 100+(enemyCount*5);
            theEnemy.GetComponentInChildren<EnemySword>().damageAmount = 5 + (enemyCount);

            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemyCount++;
        }
    }
}
