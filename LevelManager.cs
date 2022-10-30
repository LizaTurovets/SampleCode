using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    bool foggy = true;
    bool lerp = false;
    float time = 0f;

    float startTime = 0f;
    bool startLerp = false;

    [SerializeField] AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lerp)
        {
            if (startLerp)
            {
                startTime += Time.deltaTime / 0.5f;
                RenderSettings.fogDensity = (float)Mathf.Lerp(0.0015f, 0.02f, startTime);
                if (RenderSettings.fogDensity == 0.02f)
                {
                    startLerp = false;
                    startTime = 0f;
                    //am.Action();
                }
            }
            else
            {
                time += Time.deltaTime / 4f;
                RenderSettings.fogDensity = (float)Mathf.Lerp(0.02f, 0.0015f, time);

                if (RenderSettings.fogDensity == 0.0015f)
                {
                    lerp = false;
                    time = 0f;
                    //am.Action();
                }
            }
            
        }

    }

    public void Fog()
    {
        am.Calm();
        if (foggy)
        {
            startLerp = true;
            lerp = true;
        }
        
    }

    public void NoFog()
    {
        foggy = false;
        StartCoroutine(Foggy());
    }

    IEnumerator Foggy()
    {
        yield return new WaitForSeconds(4);
    }
}
