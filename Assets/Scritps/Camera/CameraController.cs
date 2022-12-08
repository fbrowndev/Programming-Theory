using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Camera Variables
    //Variables
    [Header("Mouse Controls")]
    [SerializeField] float mouseSensitivity;

    //References
    Transform parent;

    #endregion

    private void Start()
    {
        parent = transform.parent;
    }

    private void Update()
    {
        Rotate();
    }


    #region Control Methods
    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            parent.Rotate(Vector3.up, mouseX);
        }
        
    }

    #endregion

}
