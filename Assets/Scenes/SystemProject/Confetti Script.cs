using System.Collections;
using UnityEngine;

public class ConfettiSpawner : MonoBehaviour
{
    public GameObject confettiPrefab;

    public void LaunchConfetti()
    {
        // Spawn multiple confetti pieces
        for (int i = 0; i < 20; i++)
        {
            GameObject c = Instantiate(confettiPrefab);

            // Spawn near the robot position
            Vector3 spawnPos = transform.position + new Vector3(Random.Range(-1f, 1f), 2f, 0f);
            c.transform.position = spawnPos;

            StartCoroutine(AnimateConfetti(c));
        }
    }

    IEnumerator AnimateConfetti(GameObject obj)
    {
        float time = 0f;
        float duration = 2f;

        // Random movement direction
        Vector3 velocity = new Vector3(
            Random.Range(-2f, 2f),
            Random.Range(2f, 5f),
            0f
        );

        while (time < duration)
        {
            // Move confetti
            obj.transform.position += velocity * Time.deltaTime;

            // Apply gravity effect
            velocity.y -= 9.8f * Time.deltaTime;

            time += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }
}