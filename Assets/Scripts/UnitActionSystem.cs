using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    // property that can only be get through this class(private set), but accessible everywhere(public)
    public static UnitActionSystem Instance { get; private set; }

    //EventHandler - nauczyc sie wiecej o DELEGATE
    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private LayerMask unitLayerMask;
    [SerializeField] private Unit selectedUnit;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("TOO MANY UnityActionSystem's" + transform + " - " + Instance);
            Destroy(gameObject); return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;
            selectedUnit.GetMoveAction().Move(MouseWorld.GetPosition());
        }
    }
    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
           if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        //To dziala dokladnie tak jak Event?.Invoke Event - rzecz, ? = Null check, .Invoke - wykonanie po przejsciu checka 
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }

}
