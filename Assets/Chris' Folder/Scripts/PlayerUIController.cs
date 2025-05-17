using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    private PlayerController _player;

    [SerializeField] private Image _healthBarFill;

    private void Awake()
    {
        this._player = GetComponent<PlayerController>();
    }

    private void Start()
    {
        this._player.OnHealthChange += this.OnHealthChange;
    }

    private void OnHealthChange(float health)
    {
        this._healthBarFill.fillAmount = health / 100f;
    }
}
