using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{

    private float _speed = 5.0f;
    private bool _moving = false;
    private int _maxRoads = 3; //-4, 0, 4
    private int _currentRoad = 2;
    private int _nextRoad;
    private float _nextRoadX;
    private float _roadWidth = 4.0f; //
    private bool _moveR;
    private bool _moveL;


    // Start is called before the first frame update
    void Start()
    {

        _currentRoad = (_maxRoads / 2) + 1;
        _moveR = false;
        _moveL = false;

        transform.position = new Vector3(0, -3, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Move(false, 0);
    }

    public void Move(bool startMove, int newRoad)
    {
        //Get Inputs, -1 < 0 < 1
        //float horizontalInput = Input.GetAxis("Horizontal");
        
        //float verticalInput = Input.GetAxis("Vertical");
        if (! _moving)
        {

            if (startMove && newRoad != _currentRoad)
            {

                //Debug.Log("StartMove " + startMove + " newRoad " + newRoad);

                if (newRoad < _currentRoad && _currentRoad > 1) //L
                {
                    _moveL = true;
                    _moving = true;
                    _nextRoad = newRoad;
                    _nextRoadX = ((_nextRoad * _roadWidth) - (_roadWidth * 2));
                    //Debug.Log("Next Road: " + _nextRoad + " X: " + _nextRoadX);
                }
                else if (newRoad > _currentRoad && _currentRoad < _maxRoads) //R
                {
                    _moveR = true;
                    _moving = true;
                    _nextRoad = newRoad;
                    _nextRoadX = ((_nextRoad * _roadWidth) - (_roadWidth * 2));
                    //Debug.Log("Next Road: " + _nextRoad + " X: " + _nextRoadX);
                }
            }
        }
        else
        {
            //Move
            if (_moveL)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }
            if (_moveR)
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speed);
            }


            //Limit on borders and new road
            
            if (_moveL && transform.position.x < _nextRoadX) //left
            {
                transform.position = new Vector3(_nextRoadX, transform.position.y, 0);
                _currentRoad = _nextRoad;
                _moveL = false;
                _moveR = false;
                _moving = false;

            }
            else if (_moveR && transform.position.x > _nextRoadX) //right
            {
                transform.position = new Vector3(_nextRoadX, transform.position.y, 0);
                _currentRoad = _nextRoad;
                _moveL = false;
                _moveR = false; 
                _moving = false;
            }
            

        }
    }

    

}


