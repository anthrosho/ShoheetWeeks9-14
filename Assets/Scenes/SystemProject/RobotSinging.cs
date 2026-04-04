using System.Collections;
using UnityEngine;

public class RobotSinging : MonoBehaviour
{
    private Coroutine singingCR;

    public void StartSinging()
    {
        if (singingCR != null) StopCoroutine(singingCR); // stop previous
        singingCR = StartCoroutine(Sing());
    }

    public void StopSinging()
    {
        if (singingCR != null)
        {
            StopCoroutine(singingCR);
            singingCR = null;
        }
    }

    IEnumerator Sing()
    {
        Debug.Log("Daisy, Daisy,");
        yield return new WaitForSeconds(1.5f);

        Debug.Log("Give me your answer do,");
        yield return new WaitForSeconds(1.5f);

        Debug.Log("I'm half crazy,");
        yield return new WaitForSeconds(1.5f);

        Debug.Log("All for the love of you...");
        yield return null;

        singingCR = null; // reset reference
    }
}