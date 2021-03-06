using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LegacyInputController : MonoBehaviour
{
    //[SerializeField] private Transform cubeTransform;
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private GameObject bullet;

    private bool jump;
    private bool shot;
  
    private void Update()
    {
        Vector3 pos = cube.transform.position;
        pos.x = Input.GetAxis("Horizontal");
        cube.transform.position = pos;

        if (Input.GetButtonDown("Jump") && !jump)
        {
            var jumpSequence = DOTween.Sequence();
            jumpSequence.Append(cube.transform.DOJump(pos, 1f, 1, 0.3f));
            jump = true;
            jumpSequence.OnComplete(() => { jump = false; });
        }

        if (!Input.GetKey(KeyCode.W))
        {
            aimTransform.gameObject.SetActive(false);
            return;
        }
      

        aimTransform.gameObject.SetActive(true);

        var dir = Input.GetAxis("Mouse X");
        pos = aimTransform.position;
        pos.x += dir * Time.deltaTime * 5f;
        pos.x = Mathf.Clamp(pos.x, -1f, 1f);

        aimTransform.position = pos;
        Debug.Log("Inst1");

        if (!Input.GetMouseButtonUp(0) || shot)
        {
            return;
        }
        Debug.Log("Inst");
        var obj = Instantiate(bullet, aimTransform.position, Quaternion.identity);
        shot = true;
        var shotSequence = DOTween.Sequence();
        shotSequence.Append(obj.transform.DOMoveZ(10f, 1f));
        shotSequence.OnComplete(() =>
        {
            Destroy(obj);
            shot = false;
        });
    }
}