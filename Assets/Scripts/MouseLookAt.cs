using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAt : MonoBehaviour
{

    private Vector3 mouse, center;
    public GameObject arrow, pauseMenu;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (PauseMenu.paused == false)
        {
            center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));
            mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f));
            float angle = (Mathf.Atan2(mouse.y - center.y, mouse.x - center.x) * Mathf.Rad2Deg);
            arrow.transform.eulerAngles = new Vector3(0, 0, angle - 90);
        }
    }
}