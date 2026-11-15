using UnityEngine;
using UnityEngine.UIElements;

public class camerascript : MonoBehaviour
{
    public float maxHeight;
    public float minimumHeight;

    public Transform playerTransform;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public Vector3 higt;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       higt = new Vector3(0f, maxHeight-1, -10f);

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
                                transform.position = higt;

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