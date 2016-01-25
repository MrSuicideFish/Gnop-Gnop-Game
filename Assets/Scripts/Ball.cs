using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private static Ball CurrentBall;
    public float BallLaunchPower = 3.0f;

    public Rigidbody2D RigidBodyComponent;

    void Start( )
    {
        CurrentBall = this;
        RigidBodyComponent = GetComponent<Rigidbody2D>( );

        //Listen for new gamestate
        GameManager.OnGameStateChanged += OnGameStateChanged;
    }

    void OnGameStateChanged(GameManager.eGameState newGameState )
    {
        if(newGameState == GameManager.eGameState.Playing )
        {
            Quaternion direction = Quaternion.Euler( (float)Random.Range( 0, 300 ), ( float )Random.Range( 0, 300 ), ( float )Random.Range( 0, 300 ) );

            //Launch in random direction
            RigidBodyComponent.AddForce( direction.eulerAngles * BallLaunchPower );
        }
    }
}