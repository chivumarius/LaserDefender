using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    // ▼ "Shake Duration" Property 
    //     → indicates "How Long" to "Move" the "Camera" ▼
    [SerializeField] float shakeDuration = 1f;
    
    // ▼ "Shake Magnitude" Property 
    //     → indicates "How Far" to "Move the "Camera" ▼ 
    [SerializeField] float shakeMagnitude = 0.5f;

    // ▼ "Initial Position" Property 
    //     → indicates the "Initial Position" of the "Camera" ▼
    Vector3 initialPosition;




    // ▬▬▬▬▬▬▬▬▬▬ "Start()" Method ▬▬▬▬▬▬▬▬▬▬
    void Start()
    {
        // ▼ "Setting" the "Initial Position" of the "Camera" ▼
        initialPosition = transform.position;
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Play()" Method ▬▬▬▬▬▬▬▬▬▬
    public void Play()
    {
        // ▼ "Starting" the "Coroutine" ▼
        StartCoroutine(Shake());
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Shake()" - "Coroutine" with "IEnumerator" ▬▬▬▬▬▬▬▬▬▬
    IEnumerator Shake()
    {
        // ▼ "Setting" the "Elapsed Time" Variable ▼
        float elapsedTime = 0;
        
        
        // ▼ "Shaking" the "Camera" "For" "Shake Duration" "Seconds" ▼
        while(elapsedTime < shakeDuration)
        {
            // ▼ "Moving" the "Camera" to a "Random Position" ▼
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            
            // ▼ "Incrementing" the "Elapsed Time" Variable ▼
            elapsedTime += Time.deltaTime;
            
            // ▼ "Waiting" for "End" of "Frame" ▼
            yield return new WaitForEndOfFrame();
        }

        // ▼ "Resetting" the "Camera" to its "Initial Position" ▼
        transform.position = initialPosition;
    }
}
