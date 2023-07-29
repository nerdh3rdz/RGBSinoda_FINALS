using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    public int spawnIndex = 0, deadEnemies = 0;

    public GameObject deadCanvas, winCanvas, plane, rc,lc;
}
