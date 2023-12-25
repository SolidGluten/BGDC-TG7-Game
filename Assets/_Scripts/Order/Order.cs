using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Image orderImage;
    public TextMeshProUGUI orderNameTMP;
    public DishScriptable dishOrder;
    public Slider patienceBar;

    public float currentPatience;
    public float maxPatience;

    CancellationTokenSource tokenSource;

    private async void Start()
    {
        maxPatience = GameManager.MaxPatience;
        currentPatience = maxPatience;
        patienceBar.maxValue = maxPatience;
        tokenSource = new CancellationTokenSource();

        gameObject.name = "Order_" + dishOrder.dishName;
        orderNameTMP.text = dishOrder.dishName;
        orderImage.sprite = dishOrder.dishSprite;

        try
        {
            await StartExplodeTimer(tokenSource.Token);
        }
        catch (OperationCanceledException)
        {
            Debug.Log("Destroy token was cancelled");
        }
    }


    private async Task StartExplodeTimer(CancellationToken token)
    {
        while (currentPatience > 0)
        {
            currentPatience -= Time.deltaTime;
            patienceBar.value = currentPatience;
            await Task.Yield();
            if (tokenSource.IsCancellationRequested)
            {
                Debug.Log("TASK STOPPED!!");
                return;
            }
        }

        Destroy(gameObject);
        Debug.Log("DEATH!");
    }

    private void OnDestroy()
    {
        tokenSource.Cancel();
    }
}
