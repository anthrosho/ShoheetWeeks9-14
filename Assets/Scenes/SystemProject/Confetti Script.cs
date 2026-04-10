using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Confetti : MonoBehaviour
{
    public GameObject confettiPrefab;
    public RectTransform canvasTransform;

    public void LaunchConfetti()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject c = Instantiate(confettiPrefab, canvasTransform);

            RectTransform rt = c.GetComponent<RectTransform>();

            // spawn near top center
            rt.anchoredPosition = new Vector2(Random.Range(-200, 200), 200);

            StartCoroutine(AnimateConfetti(rt));
        }
    }

    IEnumerator AnimateConfetti(RectTransform rt)
    {
        float time = 0f;
        float duration = 2f;

        Vector2 start = rt.anchoredPosition;
        Vector2 velocity = new Vector2(Random.Range(-50f, 50f), Random.Range(-150f, -250f));
        float rotationSpeed = Random.Range(-200f, 200f);

        while (time < duration)
        {
            rt.anchoredPosition += velocity * Time.deltaTime;
            rt.Rotate(0, 0, rotationSpeed * Time.deltaTime);

            time += Time.deltaTime;
            yield return null;
        }

        Destroy(rt.gameObject);
    }
}