using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerTransform;

    private float rotationX = 0f;
    void Start()
    {
        //para que el cursor no salga
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {// getaxis de input nos hace recibir lo que pongamos dentro, esto y aesta definido
        //en unity, tambien lo puedes cambiar ahi mismo, esto lo multiplicamos con
        //la sencibilidad y el tiempo por frame de la pc, asi evitamos problema.
        float mousex = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mousey;
        //Limitacion para que no de 360 grado hacia arriba y  abajo
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        //La rotacion siempre esta hecho d eun quaternion
        transform.localRotation = Quaternion.Euler(rotationX,0f,0f);

        playerTransform.Rotate(Vector3.up * mousex);
    }
}
