using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverArea : MonoBehaviour
{
    private CoverScript[] covers;

    private void Awake()
    {
        covers = GetComponentsInChildren<CoverScript>();
    }

    public CoverScript GetRandomCover(Vector3 agentLocation)
    {
        return covers[Random.Range(0, covers.Length - 1)];
    }
}
