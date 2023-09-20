using UnityEngine;

public class Healthbar : MonoBehaviour
{
    private const string FILL_RATIO_PARAM_NAME = "_FillRatio";
    private const string SEGMENTS_COUNT_PARAM_NAME = "_SegmentsCount";

    [SerializeField] private MeshRenderer _meshRenderer;

    public void Init(int maxHealth)
    {
        _meshRenderer.material.SetFloat(SEGMENTS_COUNT_PARAM_NAME, maxHealth);
        gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        ResetRotation();
    }

    private void ResetRotation()
    {
        transform.rotation = Quaternion.identity;
    }

    public void UpdateValue(int current, int max)
    {
        float ratio = (float)current / max;
        if (ratio < 1f)
        {
            gameObject.SetActive(true);
            ResetRotation();
        }

        _meshRenderer.material.SetFloat(FILL_RATIO_PARAM_NAME, ratio);
    }
}
