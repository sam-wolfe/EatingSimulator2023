using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private HungerManager _hungerManager;

    [SerializeField]
    private Slider HungerBar;

    [SerializeField] private Image HungerBarFill;
    
    [SerializeField]
    private Slider ChokeBar;
    [SerializeField] 
    private GameObject ActualChokeBar; //I'm in a rush, sue me
    [SerializeField]
    private Throat throat;

    private Color initialColor;
    private float hungerBarInitial;

    [SerializeField] private TextMeshProUGUI textmeshparent;
    [SerializeField] private TextMeshPro textmesh;
    
    //------------
    // This hsouldnt be here
    public int score;

    public void increaseScore() {
        score++;
        textmeshparent.text = score.ToString();
        // textmesh.text = score.ToString();
    }
    // ------
    
    void Start() {
        _hungerManager.OnStarve += UpdateHungerBar;
        _hungerManager.OnFoodGain += UpdateHungerBar;
        initialColor = HungerBarFill.color;
        hungerBarInitial = HungerBar.value;

        throat.OnChoke += InitChokeBar;
        throat.OnAirDeplete += UpdateChokeBar;
        throat.OnClearBlockage += ClearChokebar;
        
        ActualChokeBar.SetActive(false);
        score = 0;
        textmesh = textmeshparent.GetComponent<TextMeshPro>();
    }

    private void UpdateHungerBar(int foodLevel) {
        HungerBar.value = foodLevel;
        HungerBarFill.color = Color.Lerp(initialColor, Color.red, (hungerBarInitial-foodLevel)/hungerBarInitial);
    }

    private void InitChokeBar() {
        ActualChokeBar.SetActive(true);
    }

    private void UpdateChokeBar(int chokeLevel) {
        ChokeBar.value = chokeLevel;
    }

    private void ClearChokebar() {
        ActualChokeBar.SetActive(false);

    }

}
