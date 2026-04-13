using System.Collections;
using UnityEngine;
using TMPro;

public class RobotSinging : MonoBehaviour
{
    // Declare Variables
    private Coroutine singingCR;   // Stores the singing coroutine for control (start/stop)
    private Coroutine bounceCR;    // Stores bounce coroutine so it doesn't stack

    public TextMeshProUGUI lyricsText;
    public AudioSource audioSource;

    private Vector3 originalScale; // Stores the original size of the robot

    public void Start()
    {
        // Set the scale of the robot to its original scale
        originalScale = transform.localScale;
    }

    public void StartSinging()
    {
        // If the robot is already singing, stop it first
        if (singingCR != null)
            StopCoroutine(singingCR);

        // Also stop bounce if it was already running
        if (bounceCR != null)
            StopCoroutine(bounceCR);

        // Start singing coroutine and store it in a variable 
        singingCR = StartCoroutine(Sing());

        // Start bounce animation and stores it in a variable
        bounceCR = StartCoroutine(Bounce());
    }

    public void StopSinging()
    {
        // If the robot is singing, stop  coroutine
        if (singingCR != null)
        {
            StopCoroutine(singingCR);
            singingCR = null;
        }

        // Which also stops the bounce animation 
        if (bounceCR != null)
        {
            StopCoroutine(bounceCR);
            bounceCR = null;
        }

        audioSource.Stop();
        lyricsText.text = ""; // Resets the lyrics by making it 'blank' at the end 

        // Reset robot scale so it doesn't stay stretched,get the stretched scale then just make it equal to the
        //original scale of the object. 
        transform.localScale = originalScale;
    }

    IEnumerator Sing()
    {
        // Reset audio to beginning and play
        audioSource.time = 0f;
        audioSource.Play();

        // This took a dumb amount of time to sync 
        yield return new WaitUntil(() => audioSource.time >= 0f);
        lyricsText.text = " ";

        yield return new WaitUntil(() => audioSource.time >= 4.5f);
        lyricsText.text = "Daisy, Daisy,";

        yield return new WaitUntil(() => audioSource.time >= 8.0f);
        lyricsText.text = "Give me your answer do,";

        yield return new WaitUntil(() => audioSource.time >= 12f);
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

        // Clear text at end
        lyricsText.text = "";

        // Mark coroutine as finished
        singingCR = null;
    }

    IEnumerator Bounce()
    {
        // Continuously runs while audio is playing
        while (audioSource.isPlaying)
        {
            // Expands robot slightly
            transform.localScale = originalScale * 1.1f;
            yield return new WaitForSeconds(0.2f);

            // Returns robot to original size
            transform.localScale = originalScale;
            yield return new WaitForSeconds(0.2f);

            // Expands in and out by multiplying the variable containing the original scale
        }
    }
}