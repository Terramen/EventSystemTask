using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellAnimation : MonoBehaviour
{
    
    [SerializeField] private UIRaycaster uiRaycaster;
    [SerializeField] private bool isPlayerCell;

    public bool IsPlayerCell
    {
        get => isPlayerCell;
        set => isPlayerCell = value;
    }


    public void PointerEnter()
    {
        transform.localScale = Vector3.one * 1.3f;
    }
    
    public void PointerExit()
    {
        transform.localScale = Vector3.one;
    }

}
