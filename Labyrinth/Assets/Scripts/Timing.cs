using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Threading;
using System.Threading.Tasks;

public class Timing : MonoBehaviour
{
    public Image loadingImg;
    public Text progressText;
    private int deactivationTime = 0;
    public static bool activeProgres = false;
    private float spendTime = 0f;
    const int workingTime = 10;

    private new GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find("MainProgressBar");

        loadingImg.type = Image.Type.Filled;
        loadingImg.fillMethod = Image.FillMethod.Radial360;
        loadingImg.fillOrigin = (int)Image.OriginVertical.Bottom;
        loadingImg.fillAmount = 1.0f;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.startGame)
        {
            if (activeProgres)
            {
                ProgressCircle();
            }
        }
    }

    public void ProgressCircle()
    {
        spendTime += Time.deltaTime;
        Debug.Log(spendTime);
        if (deactivationTime >=10)
        {
            gameObject.SetActive(false);
            activeProgres = false;
            deactivationTime = 0;
            spendTime = 0;
            loadingImg.fillAmount = 1.0f;
            progressText.text = (workingTime - deactivationTime).ToString();
        }
        if ((int)spendTime != deactivationTime)
        {
            deactivationTime++;
            progressText.text = (workingTime - deactivationTime).ToString();
            loadingImg.fillAmount -= 0.1f;
        }

    }
}
