using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectionImageController : MonoBehaviour
{
    public Action<int> OnListAmountChanged;

    [SerializeField] private Transform selectionImageTransform;

    [Header("Scaling Selector Animation Values")] [SerializeField]
    private float scalingSize = .25f;
    [SerializeField] private float scalingDuration = .75f;
    [SerializeField] private Ease scalingEase = Ease.OutBack;

    private void Awake()
    {
        OnListAmountChanged += CheckImageActive;
    }

    private void Start()
    {
        StartScalingAnimation();
        CloseSelectionImage();
    }

    private void StartScalingAnimation()
    {
        selectionImageTransform.transform.DOScale(Vector3.one * scalingSize, scalingDuration).From()
            .SetLoops(-1, LoopType.Yoyo).SetEase(scalingEase);
    }

    private void CloseSelectionImage()
    {
        selectionImageTransform.gameObject.SetActive(false);
    }
    
    private void OpenSelectionImage()
    {
        selectionImageTransform.gameObject.SetActive(true);
    }


    internal void SetSelectionImagePosition(List<Orb> orbList)
    {
        if (orbList.Count > 0)
        {
            selectionImageTransform.position = orbList[0].transform.position;
        }
    }

    private void CheckImageActive(int listCount)
    {
        if (listCount > 0)
        {
            OpenSelectionImage();
        }
        else
        {
            CloseSelectionImage();
        }
    }
}
