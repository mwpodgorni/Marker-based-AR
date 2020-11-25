using UnityEngine;
using Vuforia;
public class QueenScript : MonoBehaviour
{
    private GameObject vbRButton;
    private GameObject rPaddle;
    private float speed = 3f;
    private bool _rRotationStatus=false;
    private float rRotationValue;
    Vector3 rRotation = new Vector3(0, 60, 0);
    
    private GameObject vbLButton;
    private GameObject lPaddle;
    private bool _lRotationStatus=false;
    private float lRotationValue;
    Vector3 lRotation = new Vector3(0, -60, 0);
    void Start()
    {
        vbRButton = GameObject.FindGameObjectWithTag("QueenRightButton");
        vbRButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnRightButtonPressed);
        vbRButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnRightButtonReleased);
        rPaddle = GameObject.FindGameObjectWithTag("QueenRightPaddle");
        rRotationValue = rPaddle.transform.rotation.eulerAngles.y-140;
        
        vbLButton = GameObject.FindGameObjectWithTag("QueenLeftButton");
        vbLButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnLeftButtonPressed);
        vbLButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnLeftButtonReleased);
        lPaddle = GameObject.FindGameObjectWithTag("QueenLeftPaddle");
        lRotationValue = lPaddle.transform.rotation.eulerAngles.y;
    }

    public void OnRightButtonPressed(VirtualButtonBehaviour vb)
    {
        _rRotationStatus = true;
  
    }

    public void OnRightButtonReleased(VirtualButtonBehaviour vb)
    {
    }

    void Update()
    {
        if (_rRotationStatus == true)
        {
            if (rRotationValue<260)
            {
                rRotationValue = rRotationValue + this.rRotation.y * Time.deltaTime * speed;
                rPaddle.transform.Rotate(this.rRotation * (Time.deltaTime * speed));
            }
            else
            {
                returnRRotation();
            }
        }
        if (_lRotationStatus == true)
        {
            if (lRotationValue > 140)
            {
                lRotationValue = lRotationValue + this.lRotation.y * Time.deltaTime * speed;
                lPaddle.transform.Rotate(this.lRotation * (Time.deltaTime * speed));
            }
            else
            {
                returnLRotation();
            }
        }

    }
    void returnRRotation()
    {
        _rRotationStatus = false;
        rRotationValue = 200;
        Vector3 rotation = new Vector3(0, -60, 0);
        rPaddle.transform.Rotate(rotation);
    }
    
    public void OnLeftButtonPressed(VirtualButtonBehaviour vb)
    {
        _lRotationStatus = true;
    }

    public void OnLeftButtonReleased(VirtualButtonBehaviour vb)
    {
    }


    void returnLRotation()
    {
        _lRotationStatus = false;
        lRotationValue = 200;
        Vector3 rotation = new Vector3(0, 60, 0);
        lPaddle.transform.Rotate(rotation);
    }
}
