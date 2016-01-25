using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour
{
    public float PaddleHeightClamp = 3.75f;
    public float PaddleSpeed = 1.0f;
    public int PlayerOwner = 0;

    void Start( )
    {

    }

    void Update( )
    {
        float moveVal = 0.0f;
        if(PlayerOwner == 0 )
        {
            moveVal = Input.GetAxis( "Vertical" );
        }

        if(PlayerOwner == 1 )
        {
            moveVal = Input.GetAxis( "Vertical2" );
        }

        transform.Translate( Vector2.up * moveVal * PaddleSpeed * Time.deltaTime );

        //Position Correction
        transform.position = new Vector3( transform.position.x, Mathf.Clamp( transform.position.y, -PaddleHeightClamp, PaddleHeightClamp ), transform.position.z );
    }
}
