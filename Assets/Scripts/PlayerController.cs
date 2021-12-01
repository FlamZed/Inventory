using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _damage = 5;
    public bool IsDead => _isDead; // Get состояние смерти игрока
    private bool _isDead = false;

    public int CurrentHealth // Get текущее кол-во HP
    { 
        get
        {
            return CurrentHealth;
        }
        private set
        {
            if (CurrentHealth - value < 0)
                CurrentHealth = 0;
            else
                CurrentHealth -= value;
        }
    }

    public GameObject camerFollow, spectatorCamera;

    [SerializeField] private Text damagetext;
    [SerializeField] private Slider healthSlider;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        healthSlider.value = CurrentHealth;
        damagetext.text = CurrentHealth.ToString();

        if (CurrentHealth == 0)
        {
            SetDeadState();
            spectatorCamera.SetActive(true);
            camerFollow.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(_damage);
        }
    }

    public void SetDeadState()
    {
        _isDead = true;
        CarDestroying();
    }

    public void CarDestroying()
    {
        Destroy(gameObject);
    }
}