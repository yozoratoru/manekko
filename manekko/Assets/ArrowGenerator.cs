using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject[] arrows; // 矢印のプレハブ（上下左右）
    public float spawnInterval = 2.0f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnArrow();
            timer = 0f;
        }
    }

    private void SpawnArrow()
    {
        int randomIndex = Random.Range(0, arrows.Length);
        Instantiate(arrows[randomIndex], transform.position, Quaternion.identity);
    }
}

