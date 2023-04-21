using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public ColorYype colortype;
    public  BlockType type;

    private SpriteRenderer spriteRenderer;

    private bool isDragging;
    private Vector2 initialPosition;
    
    
    private Vector2 gridSize = new Vector2(1, 1);



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(colortype);
    }

    private void Update()
    {
        if (isDragging)
        {
            isDragging = false;

            //Vector2 direction = endPoint - beginPoint;

           // print(direction);


            /*
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mouseWorldPosition - initialPosition;
            print(direction);
            // 상하좌우 방향을 결정
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                direction.y = 0;
            }
            else
            {
                direction.x = 0;
            }

            // 한 칸만큼 이동 제한
            direction = Vector2.ClampMagnitude(direction, gridSize.x);

            // 오브젝트 이동
            transform.position = initialPosition + direction;
             */
        }
    }

    private void OnMouseDown()
    {
        //initialPosition = transform.position;

        
    }

    private void OnMouseUp()
    {
        isDragging = true;
        


        /*
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = initialPosition - mouseWorldPosition;
        Vector2 finalPosition = initialPosition;

        // 한 칸만큼 이동
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            finalPosition.x += Mathf.Round(direction.x / gridSize.x) * gridSize.x;
        }
        else
        {
            finalPosition.y += Mathf.Round(direction.y / gridSize.y) * gridSize.y;
        }

        // 최종 위치 설정
        transform.position = finalPosition;
         */
    }

    public void SetColor(ColorYype color)
    {
        switch (color)
        {
            case ColorYype.Red:
                spriteRenderer.color = Color.red;
                break;

            case ColorYype.Orange:
                spriteRenderer.color = new Color(255.0f, 150.0f, 0.0f, 255.0f);
                break;

            case ColorYype.Yellow:
                spriteRenderer.color = Color.yellow;
                break;

            case ColorYype.Green:
                spriteRenderer.color = Color.green;
                break;

            case ColorYype.Blue:
                spriteRenderer.color = Color.blue;
                break;

            case ColorYype.Purple:
                spriteRenderer.color = new Color(255.0f, 0.0f, 255.0f, 255.0f);
                break;
        }
    }
}
