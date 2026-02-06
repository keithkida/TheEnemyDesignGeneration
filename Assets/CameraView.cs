using UnityEngine;
using UnityEngine.UI;

public class CameraSlider : MonoBehaviour
{
    public Transform target;
    public Slider slider;
    public float distance = 5f;
    public float height = 2f;

    void Update() { // Slider goes 0 → 1, convert to 0 → 360 degrees 
        float angle = slider.value * 360f + 180f; // Start at 180 degrees to be behind the target
        float rad = angle * Mathf.Deg2Rad; 
        Vector3 offset = new Vector3( 
            Mathf.Sin(rad) * distance, 
            height, 
            Mathf.Cos(rad) * distance 
        ); 
        
        transform.position = target.position + offset; 
        transform.LookAt(target); 
    }
}
