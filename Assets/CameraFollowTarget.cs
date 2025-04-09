using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float smoothSpeed = 0.5f;
    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        // Проверяем нажатые клавиши
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement += Vector3.forward * speed * Time.deltaTime;
        }

        //Ограничение области полета камеры
        Vector3 currentPos = transform.position + movement;
        if (currentPos.x < -10.0f) currentPos.x = -10.0f;
        if (currentPos.x > 10.0f) currentPos.x = 10.0f;
        if (currentPos.z < -10.0f) currentPos.z = -10.0f;
        if (currentPos.z > 10.0f) currentPos.z = 10.0f;
        transform.position = currentPos;
    }

    private void LateUpdate()
    {
        // Рассчитываем направление от камеры к объекту
        Vector3 direction = target.position - transform.position;

        // Поворачиваем камеру в направлении объекта
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Плавно поворачиваем камеру
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, smoothSpeed * Time.deltaTime);
    }
}
