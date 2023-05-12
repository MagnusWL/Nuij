using System;
using UnityEngine;

public class NuijController : MonoBehaviour
{

    public FloatVariable Nuij;
    public FloatVariable NuijRecovery;

    private void Start()
    {
        Nuij.Value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Nuij.Value = Math.Min(1, Nuij.Value + NuijRecovery.Value);
        gameObject.transform.localScale = new Vector3(Nuij.Value, 1f);
    }
}