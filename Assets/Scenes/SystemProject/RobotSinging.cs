using System.Collections;
using UnityEngine;
using TMPro;

public class RobotSinging : MonoBehaviour
{
    private Coroutine singingCR;

    public TextMeshProUGUI lyricsText;
    public AudioSource audioSource;

    public void StartSinging()
    {
        if (singingCR != null)
            StopCoroutine(singingCR);

        singingCR = StartCoroutine(Sing());
    }

    public void StopSinging()
    {
        if (singingCR != null)
        {
            StopCoroutine(singingCR);
            singingCR = null;
        }

        audioSource.Stop();
        lyricsText.text = "";
    }

    IEnumerator Sing()
    {
        audioSource.time = 0f;
        audioSource.Play();

        yield return new WaitUntil(() => audioSource.time >= 0f);
        lyricsText.text = " ";


        yield return new WaitUntil(() => audioSource.time >= 4.5f);
        lyricsText.text = "Daisy, Daisy,";

        yield return new WaitUntil(() => audioSource.time >= 8.0f);
        lyricsText.text = "Give me your answer do,";

        yield return new WaitUntil(() => audioSource.time >= 12);
        lyricsText.text = "I'm half crazy,";

        yield return new WaitUntil(() => audioSource.time >= 16.0f);
        lyricsText.text = "All for the love of you...";


        yield return new WaitUntil(() => audioSource.time >= 20.0f);
        lyricsText.text = "It won't be a stylish marriage";

        yield return new WaitUntil(() => audioSource.time >= 24.0f);
        lyricsText.text = "I can't afford a carriage...";

        yield return new WaitUntil(() => audioSource.time >= 29.0f);
        lyricsText.text = "But you'll look sweet, upon a seat-";

        yield return new WaitUntil(() => audioSource.time >= 33.0f);
        lyricsText.text = "Of a bicycle built for two!";

        yield return new WaitUntil(() => audioSource.time >= 38.0f);



        lyricsText.text = "";

        singingCR = null;
    }
}