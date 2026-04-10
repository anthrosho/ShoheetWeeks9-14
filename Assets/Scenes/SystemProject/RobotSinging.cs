using System.Collections;
using UnityEngine;
using TMPro;

public class RobotSinging : MonoBehaviour
{
    // Declare Variables
    private Coroutine singingCR;

    public TextMeshProUGUI lyricsText;
    public AudioSource audioSource;
    private Vector3 originalScale;



    public void Start()
    {

        //Set the scale of the robot to its original scale
        originalScale = transform.localScale;

    }

    public void StartSinging()
    {
        if (singingCR != null) //If the robot is already singing, stop it. 
            StopCoroutine(singingCR);

        singingCR = StartCoroutine(Sing());   //Contains the Function into a variable for easier control 
    }

    public void StopSinging()
    {

        //If the robot is not null, then it should stop. 
        if (singingCR != null)
        {
            StopCoroutine(singingCR);
            singingCR = null;
        }

        audioSource.Stop();
        lyricsText.text = "";
        // Resets the lyrics. 
    }

    IEnumerator Sing()
    {
        audioSource.time = 0f;
        audioSource.Play();
        StartCoroutine(Bounce());

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

    IEnumerator Bounce()
    {
        while (audioSource.isPlaying)
        {
            transform.localScale = originalScale * 1.1f;
            yield return new WaitForSeconds(0.2f);

            transform.localScale = originalScale;
            yield return new WaitForSeconds(0.2f);
            // Expands in and out by mulitplying the variable containing the orginal scale.
        }
    }

}