using UnityEngine;
using UnityEngine.UIElements;

public class camerascript : MonoBehaviour
{
    public float maxHeight;
    public float minimumHeight;

    public Transform playerTransform;
    public Vector3 offset = new Vector3(0f, 0f, -10f);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    void LateUpdate()
    {
        if (playerTransform != null)
        {
                Vector3 position = transform.position;
        if(position.y <= minimumHeight)
            {
                transform.position = position;
            }
        else if(position.y >= maxHeight)
            {
                                transform.position = position;

            }  
        else{
            transform.position = playerTransform.position + offset;
        }
    }
    }

    // Update is called once per frame
    void Update()
    {

        
          }
    }