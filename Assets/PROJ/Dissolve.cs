using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;

    bool isDissolving = false;
    bool dissolved = false;
    float fade = 1f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            isDissolving = true;
        }
        /*
        else if(Input.GetKeyDown(KeyCode.B))
        {
            isDissolving = false;
        }

        if (!isDissolving)
        {
            fade += Time.deltaTime;

            if(fade >= 1f)
            {
                fade = 1f;
                material.SetFloat("_Fade", fade);
                isDissolving = true;
            }
        }
        */
        if (isDissolving && dissolved == false)
        {
            fade -= Time.deltaTime;

            if(fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                dissolved = true;
            }

            material.SetFloat("_Fade", fade);
        }

    }
}
