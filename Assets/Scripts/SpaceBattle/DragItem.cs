using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Image image;

    [SerializeField] private Transform parentTransform;
    private Transform currentTransform;
    
    [SerializeField] private UIRaycaster uiRaycaster;
    private CellAnimation _cellAnimation;
    [SerializeField] private Exchange _exchange;
    
    
    public void BeginDrag()
    {
        image.raycastTarget = false;
    }

    public void Drag()
    {
        var pos = Input.mousePosition;
        pos.z = 0f;
        transform.position = pos;
    }

    public void EndDrag()
    {
        
        transform.localScale = Vector3.one;
        image.raycastTarget = true;
        if (uiRaycaster.TryGetRaycast(out var result))
        {
            if (result != null)
            {

                if (parentTransform.gameObject.CompareTag("Player") || result.gameObject.CompareTag("Trader"))
                {
                    _exchange.SellAsteroid(10);
                }
                if (parentTransform.gameObject.CompareTag("Trader") || result.gameObject.CompareTag("Player"))
                {
                    _exchange.BuyAsteroid(10);
                }
                parentTransform = result;
                transform.SetParent(parentTransform, true);
            }

        }
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
    }

    public void Drop()
    {
        image.color = Color.white;
    }
}
