using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;
    public int _currentHealth;

    [SerializeField] private GameObject _deathTimeTextContainer;
    [SerializeField] private TMP_Text _deathTimeText;
    [SerializeField] private float _deathTime = 5;
    public float _deathTimer;

    void Start(){
        _currentHealth = _health;
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            _deathTimer -= Time.deltaTime;
            _deathTimeTextContainer.SetActive(true);
            _deathTimeText.text = _deathTimer.ToString();

            if (_deathTimer < 0)
            {
                //endgame code here
                Debug.Log("endgame");
            }
        }
        else
        {
            _deathTimeTextContainer.SetActive(false);
            _deathTimer = _deathTime;
        }
    }

    public void DecreaseHealth(int healthToDecrease)
    {
        _currentHealth -= healthToDecrease;
    }

    public void RessetHealth(){
        _currentHealth = _health;
    }
}
