using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class Thunder1 : MonoBehaviour
{
    public VisualEffect vfx; // Assign your VFX GameObject here in the inspector

    public float interval = 2f; // Time between each VFX play

    public Vector3 positionOffsetRange = new Vector3(5f, 0f, 5f); // Range for random position offset

    private Vector3 initialLocalPosition; // To store the initial local position of the VFX

    private void Start()
    {
        initialLocalPosition = vfx.transform.localPosition; // Store the initial local position
        StartCoroutine(PlayVFXRepeatedly());
    }

    private IEnumerator PlayVFXRepeatedly()
    {
        while (true)
        {
            SetRandomPositionWithinRange();
            vfx.Play(); // Start the VFX
            yield return new WaitForSeconds(interval);
        }
    }

    private void SetRandomPositionWithinRange()
    {
        // Generate a random offset within the specified range
        Vector3 randomOffset = new Vector3(
            Random.Range(-positionOffsetRange.x, positionOffsetRange.x),
            Random.Range(-positionOffsetRange.y, positionOffsetRange.y),
            Random.Range(-positionOffsetRange.z, positionOffsetRange.z)
        );

        // Update the local position of the VFX with the offset
        vfx.transform.localPosition = initialLocalPosition + randomOffset;
    }
}
