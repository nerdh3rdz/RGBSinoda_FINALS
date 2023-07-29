using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public bool dead = false, spawned = false;
    [SerializeField]
    float speed;

    private Vector3 target = new(0, 1, 0);

    [SerializeField]
    GameObject enemyPrefab;

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(target);
        }
        else if (dead && !spawned)
        {
            spawned = true;
            if (++EnemySpawner.Instance.deadEnemies > 25)
            {
                EnemySpawner.Instance.winCanvas.SetActive(true);
                EnemySpawner.Instance.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!dead)
        {
            dead = true;

            StartCoroutine(SpawnAndDie());
            //GetComponent<Rigidbody>().useGravity = true;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            EnemySpawner.Instance.deadCanvas.SetActive(true);
            EnemySpawner.Instance.plane.SetActive(false);
            EnemySpawner.Instance.rc.SetActive(false);
            EnemySpawner.Instance.lc.SetActive(false);
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    IEnumerator SpawnAndDie()
    {
        SpawnAnother(EnemySpawner.Instance.spawnIndex++);
        SpawnAnother(EnemySpawner.Instance.spawnIndex++);

        yield return new WaitForSeconds(2f);
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void SpawnAnother(int index)
    {
        Vector3 spawnPosition;
        GameObject newEnemy;

        int spawnPoint = index % 4;
        switch (spawnPoint)
        {
            case 1:
                spawnPosition = new Vector3(UnityEngine.Random.Range(-25, 20), transform.position.y, UnityEngine.Random.Range(20, 25));
                newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().dead = false;
                break;
            case 2:
                spawnPosition = new Vector3(UnityEngine.Random.Range(20, 25), transform.position.y, UnityEngine.Random.Range(-20, 25));
                newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().dead = false;
                break;
            case 3:
                spawnPosition = new Vector3(UnityEngine.Random.Range(-20, 25), transform.position.y, UnityEngine.Random.Range(-25, -20));
                newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().dead = false;
                break;
            case 0:
                spawnPosition = new Vector3(UnityEngine.Random.Range(-25, -20), transform.position.y, UnityEngine.Random.Range(-25, 20));
                newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().dead = false;
                break;
        }
    }
}
