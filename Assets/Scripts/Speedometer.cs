using TMPro;
using UnityEngine;


public class Speedometer : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 260.0f;

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public TMP_Text speedLabel; 
    public RectTransform arrow; 

    private float speed = 0.0f;
    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f;

        if (speedLabel != null)
        {
            speedLabel.text = ((int)speed) + " km/h";
        }
           
        if (arrow != null)
        {
            float clampedSpeed = Mathf.Clamp(speed, 0, maxSpeed);

            float arrowAngle = Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, clampedSpeed / maxSpeed);
            arrow.localEulerAngles = new Vector3(0, 0, arrowAngle);
        }
    }
}