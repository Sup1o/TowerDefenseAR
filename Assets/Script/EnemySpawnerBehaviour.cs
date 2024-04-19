using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    public GameObject[] ListEnemyPrefab;
    public Transform Target;
    public Vector3 RandomPointOnCircle(float centerX, float centerZ, float radius)
    {
        // Generate a random angle between 0 and 2*PI (full circle)
        float angle = UnityEngine.Random.value * 2 * Mathf.PI;

        // Calculate x' and y' coordinates using the sine and cosine of the angle
        float xPrime = centerX + radius * Mathf.Cos(angle);
        float zPrime = centerZ + radius * Mathf.Sin(angle);

        return new Vector3(xPrime, 5, zPrime);
    }

    public IEnumerator SpawnEnemy(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnSingleEnemy(20);
            yield return new WaitForSeconds(1);
        }
    }

    public void SpawnSingleEnemy(int distantFromCenter)
    {
        // Randomly select an enemy prefab from the list
        GameObject enemyPrefab = ListEnemyPrefab[Random.Range(0, ListEnemyPrefab.Length)];

        // Randomly select a point on a circle with radius 10
        Vector3 randomPoint = RandomPointOnCircle(0, 0, distantFromCenter);

        // Instantiate the enemy prefab at the random point
        GameObject enemy = Instantiate(enemyPrefab, randomPoint, Quaternion.identity);

        // Set the target of the enemy to the target transform
        enemy.GetComponent<EnemyBehaviour>().Target = Target;
    }

}
