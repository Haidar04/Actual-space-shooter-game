using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float xThrow, yThrow;

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In m")] [SerializeField] float xRange = 25f;
    [Tooltip("In m")] [SerializeField] float yRange = 15f;

    void ProcessTranslation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");


        //Offsets
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * xSpeed * Time.deltaTime;

        //X raw
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);


        //Y raw
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); //change only Z, not Y and Z.
    }
        // Update is called once per frame
        void Update()
    {
        ProcessTranslation();
    }
}
