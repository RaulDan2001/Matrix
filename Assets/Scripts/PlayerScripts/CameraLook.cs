using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    public float xRotation;
    public float yRotation;

    private void Start()
    {
        //punem mouse-ul in mijlocul ecranului si il facem invizibil
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //luam input de la mouse
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        //caracterul poate privi doar pana la unghiuri de 90 de grade
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotare camera si orientare
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
