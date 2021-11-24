using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class PlayerController : MonoBehaviour
{
    private float movement;
    [SerializeField] private GameObject fighter, PlayerManager;
    [SerializeField] private float screenRangeMin, screenRangeMax;
    [SerializeField] private Canvas view;
    [SerializeField] private Camera camView;
    private Vector2 minX, maxX;
    private int canvasDivisor = 4, platformInt;
    private float maxRot = -30, sensitivity = 0.05f;
    private Gyroscope _gyro;

    void Start()
    {
        Rect pixelRect = view.pixelRect;
        
        RectTransform rec = view.GetComponent<RectTransform>();
        minX = new Vector2(pixelRect.xMin, pixelRect.center.y);
        maxX = new Vector2(pixelRect.xMax, pixelRect.center.y);

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rec, minX, camView, out Vector3 minPoint);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rec, maxX, camView, out Vector3 maxPoint);
        
        screenRangeMin = minPoint.x / canvasDivisor;
        screenRangeMax = maxPoint.x / canvasDivisor;

        _gyro = Input.gyro;
        _gyro.enabled = true;

        Time.timeScale = 1;

        platformInt = PlayerPrefs.GetInt("platform");
    }
    
    void FixedUpdate()
    {
        var fPos = fighter.transform.position;
        switch (platformInt)
        {
            case 0:
                movement += _gyro.rotationRateUnbiased.y * sensitivity;
                break;
            case 1:
                movement = Input.GetAxis("Horizontal");
                break;
        }
 

        Quaternion rotation = Quaternion.Euler(0,0, maxRot * movement);
        fighter.transform.rotation = rotation;

        if (fPos.x + movement >= screenRangeMin && fPos.x + movement <= screenRangeMax)
        {
            fighter.transform.position = new Vector2 (fPos.x + movement, PlayerManager.transform.position.y);
        }
    }
}
