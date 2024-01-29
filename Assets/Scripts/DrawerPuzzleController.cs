using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerPuzzleController : MonoBehaviour
{
    private List<int> drawerOrder = new List<int>();
    private int[] correctOrder = { 4, 5, 1 }; // Define the correct order
    public GameObject finalDrawer; // Rigidbody of the final drawer that opens automatically
    public float autoOpenDistance = 1.0f; // Distance to open the final drawer

    [SerializeField] private AudioClip openSound;
    private AudioSource finalDrawerAudioSource;
    void Start()
    {
        finalDrawerAudioSource = finalDrawer.GetComponent<AudioSource>();
    }

    // Method called by individual drawers when they are pulled
    public void DrawerPulled(int drawerID)
    {
        if (!drawerOrder.Contains(drawerID))
        {
            drawerOrder.Add(drawerID);
            Debug.Log("Drawer order updated: " + string.Join(", ", drawerOrder));
            CheckSequence();
        }
    }

    private void OpenFinalDrawer()
    {
        Debug.Log("Opening final drawer");
        StartCoroutine(SmoothlyOpenDrawer(finalDrawer.transform, autoOpenDistance));

        finalDrawerAudioSource.PlayOneShot(openSound);
    }
    public bool CanDrawerBePulled(int drawerID)
    {
        int nextIndex = drawerOrder.Count;
        if (nextIndex < correctOrder.Length)
        {
            bool canBePulled = correctOrder[nextIndex] == drawerID;
            Debug.Log($"Can drawer {drawerID} be pulled? {canBePulled}");
            return canBePulled;
        }
        return false; // All necessary drawers have been pulled
    }
    private void CheckSequence()
    {
        // Check if the drawer order matches the correct sequence
        Debug.Log("Current drawer order: " + string.Join(", ", drawerOrder));

        for (int i = 0; i < drawerOrder.Count; i++)
        {
            if (drawerOrder[i] != correctOrder[i])
            {
                Debug.Log("Incorrect drawer sequence. Resetting.");
                drawerOrder.Clear();
                return;
            }
        }

        if (drawerOrder.Count == correctOrder.Length)
        {
            OpenFinalDrawer();
        }
    }
    private IEnumerator SmoothlyOpenDrawer(Transform drawerTransform, float distance)
    {
        Vector3 startPosition = drawerTransform.position;
        Vector3 endPosition = startPosition + new Vector3(distance, 0, 0); // Adjust for the correct axis

        float duration = 2.0f; // Duration over which the drawer opens
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float fraction = elapsed / duration;

            drawerTransform.position = Vector3.Lerp(startPosition, endPosition, fraction);

            yield return null;
        }

        drawerTransform.position = endPosition; // Ensure it's exactly at the end position
    }
    public void DrawerPushedIn(int drawerID)
    {
        if (drawerOrder.Contains(drawerID))
        {
            Debug.Log("Drawer pushed in, resetting puzzle.");
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        drawerOrder.Clear();
    }

}
