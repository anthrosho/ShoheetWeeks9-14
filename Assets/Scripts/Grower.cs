using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform treeTransform;
        void Start()
    {
        treeTransform.localScale = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void StartTreeGrowing()
    {
        StartCoroutine(GrowTree());
    }

    IEnumerator GrowTree()

    {
        float t = 0;

        t += Time.deltaTime;
     
    while(t <1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
        }
  
    }

}
