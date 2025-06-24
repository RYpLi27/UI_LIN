using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        MeshRenderer UnitMeshRenderer = GetComponent<MeshRenderer>();
        meshRenderer = UnitMeshRenderer;
    }
}
