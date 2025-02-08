using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class XR_Stopwatch : MonoBehaviour
{
    // Ссылка на компонент Text для отображения времени
    public Text timeDisplay;

    // Переменные для хранения времени
    private bool isRunning = false;
    private float elapsedTime = 0f;

    // Метод для начала отсчёта времени
    public void StartTimer()
    {
        if (isRunning) return;
        RestartTimer();
    }

    // Метод для начала отсчёта времени
    public void RestartTimer()
    {
        isRunning = true;
        elapsedTime = 0f;
    }

    // Метод для завершения отсчёта времени
    public void StopTimer()
    {
        isRunning = false;
    }

    void Update()
    {
        // Если таймер запущен, обновляем время
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }
        // Выводим время на экран через компонент Text
        if (timeDisplay != null)
        {
            // Преобразуем время в формат "HH:mm:ss:fff"
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
            string timeFormatted = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}",
                timeSpan.Hours,
                timeSpan.Minutes,
                timeSpan.Seconds,
                timeSpan.Milliseconds);
            timeDisplay.text = timeFormatted;
        }
    }

    // Метод срабатывает, когда игрок входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartStopwatch"))
        {
            StartTimer();
        }
        else if (other.CompareTag("EndStopwatch"))
        {
            StopTimer();
        }
    }
}

