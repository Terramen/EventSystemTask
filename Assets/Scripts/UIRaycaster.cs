using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class UIRaycaster : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem eventSystem;

    private PointerEventData pointerEventData;
    
#if UNITY_EDITOR
    private void Reset()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();

        if (raycaster == null || eventSystem == null)
        {
            EditorUtility.DisplayDialog("UI Raycaster", "Please add UI Raycaster on Canvas only", "OK");
            Destroy(this);
        }
    }
#endif

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            return;
        }
        
    }

    public GameObject GetRaycast()
    {
        pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };
Debug.Log("");
        var result = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, result);
        GameObject gj = new GameObject();
        foreach (var res in result)
        {
            if (res.gameObject.name.Equals("Cell"))
            {
                gj = res.gameObject;
                Debug.Log($"Hit {res.gameObject.name}");
            }
        }

        return gj;
    }
    
    public bool TryGetRaycast(out Transform tr)
    {
        pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        var result = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, result);
        foreach (var res in result)
        {
            if (res.gameObject.name.Equals("Cell"))
            {
                if (res.gameObject.transform.childCount == 0)
                {
                    Debug.Log($"Hit {res.gameObject.name}");
                    tr = res.gameObject.transform;
                    return true;
                }
            }
        }
        tr = null;
        return false;
    }
}
