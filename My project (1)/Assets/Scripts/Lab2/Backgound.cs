using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgound : MonoBehaviour
{
    [SerializeField]
    public GameObject[] backgrounds;
    [SerializeField]
    public Transform character; //Nhan vat di chuyen - thuc te la camera

    public float backgroundWidth; // Chieu rong cua moi background - ko phai chieu rong anh background
    private Camera mainCamera;
    public float cameraWidth;
    // Start is called before the first frame update
    void Start()
    {
        //Lay chieu rong camera dua tren kich thuoc camera
        mainCamera = Camera.main;
        cameraWidth = 2f * mainCamera.orthographicSize * mainCamera.aspect;
        backgroundWidth = backgrounds[1].transform.position.x - backgrounds[0].transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject bg in backgrounds)
        {
            // Kiem tra neu background da di khoi tam nhin cua camera ve ben trai
            if (bg.transform.position.x + backgroundWidth / 2 < character.position.x - cameraWidth / 2)
            {
                Vector3 newPosition = bg.transform.position;
                newPosition.x += backgroundWidth * backgrounds.Length;
                bg.transform.position = newPosition;
            }
        }
    }
}
