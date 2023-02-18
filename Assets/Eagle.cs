using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float eagleHeight = 2;
    [SerializeField]
    float speed = 2;
    SpriteRenderer sr;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        startPosition = transform.position;
        StartCoroutine(EagleAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x > transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }


    IEnumerator EagleAnimation()
    {
        Vector3 endPosition = new Vector3(startPosition.x,startPosition.y + eagleHeight, startPosition.z);

        float value = 0;
        bool isFlight = true;
        
        while(true)
        {
            yield return null;

            if (isFlight )
            {
                transform.position = Vector3.Lerp(startPosition,endPosition,value);
            }
            else
            {
                transform.position = Vector3.Lerp(endPosition, startPosition, value);

            }
            value += Time.deltaTime * speed;

            if (value > 1)
            {
                value = 0;
                isFlight = !isFlight;
            }
        }
    }
}
