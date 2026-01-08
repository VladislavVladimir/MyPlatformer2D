using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>(true);

        foreach (SpriteRenderer r in renderers)
        {
            Transform t = r.transform; 
            if (t.position.z == 0f)
            {
                Vector3 pos = t.position;
                pos.z = r.bounds.min.y;
                t.position = pos;
            }
        }
    }
}