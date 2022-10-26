using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Transform[] tr;
    [SerializeField]
    GameObject enemyPref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrtEnemy()
    {
        GameObject enemy = Instantiate(enemyPref, this.transform);
        Enemy scrEnemy = enemy.GetComponent<Enemy>();
        scrEnemy.Init(tr, 1000); //수정예정!
    }
}
