using UnityEngine;

public class UnitSkin : MonoBehaviour
{
    [SerializeField] private Material _playerMaterial;
    [SerializeField] private Material _enemyMaterial;
    [SerializeField] private Renderer[] _renderers;

    private Owner _currentSkin = Owner.Player;

    public void SetSkin(Owner owner)
    {
        if (_currentSkin == owner) return;

        switch (owner)
        {
            case Owner.Player:
                UpdateMaterial(_playerMaterial);
                break;
            case Owner.Enemy:
                UpdateMaterial(_enemyMaterial);
                break;
            default:
                break;
        }

        _currentSkin = owner;
    }

    private void UpdateMaterial(Material material)
    {
        foreach (Renderer renderer in _renderers)
        {
            renderer.sharedMaterial = material;
        }
    }
}
