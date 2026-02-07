using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class SceneFade : MonoBehaviour {
    private Image _image;
    private Image _childrenImages;
    private GameObject[] _allChildrenGameObjects;
    private Image[] _allChildrenImages;
    //private List<Image> _childrenImages = new List<Image>();
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _helpBanner;
    [SerializeField] private GameObject _settingsButton;
    public void FadeScreen() {
        _image = GetComponent<Image>();
        
        _childrenImages= GetComponentInChildren<Image>();
        _allChildrenGameObjects = new GameObject[transform.childCount];
        _allChildrenImages = new Image[_allChildrenGameObjects.Length];
        for (int i =0; i< _allChildrenGameObjects.Length; i++) {
            _allChildrenGameObjects[i] = transform.GetChild(i).gameObject;
            _allChildrenImages[i] = _allChildrenGameObjects[i].GetComponent<Image>();
        }
        Debug.Log("The children are " + _allChildrenImages[1] + " and count is "+ _allChildrenGameObjects.Length);
        StartCoroutine(Fader());
    }

    IEnumerator Fader() {
        _helpBanner.SetActive(false);
        _settingsButton.SetActive(false);
        float t = 0;
        Color c = _image.color;
        while (t < _duration) {
            t += Time.deltaTime;
            c.a = t / _duration;
            _image.color = c;
            yield return null;
        }
        foreach (GameObject child in _allChildrenGameObjects) {
            if (child != null) {
                child.SetActive(true);
            }
            
        }   
            

    }
    private void OnEnable() {
        GameManager.onGameStateChanged += OnGameStateChanged;
    }

    private void OnDisable() {
        GameManager.onGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState state) {
        if (state == GameState.End) {
            Debug.Log("It went into fading!");
            FadeScreen();
        }
    }
    }
