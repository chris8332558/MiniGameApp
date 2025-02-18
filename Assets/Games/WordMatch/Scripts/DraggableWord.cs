using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableWord : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent;
    private int originalIndex;
    private GameObject placeholder;
    private Canvas canvas;

    void Awake()
    {
        // Find the top‑level canvas (needed for correct drag positioning)
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Remember where we came from
        originalParent = transform.parent;
        originalIndex = transform.GetSiblingIndex();

        // Create a placeholder to mark the original spot
        placeholder = new GameObject("Placeholder");
        placeholder.transform.SetParent(originalParent);
        // Add a LayoutElement so the placeholder takes up space in the layout group
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        LayoutElement myLE = GetComponent<LayoutElement>();
        if (myLE != null)
        {
            le.preferredWidth = myLE.preferredWidth;
            le.preferredHeight = myLE.preferredHeight;
        }
        placeholder.transform.SetSiblingIndex(originalIndex);

        // Move our word to be a child of the canvas (so it isn’t clipped by its original container)
        transform.SetParent(canvas.transform, false);

        // Disable blocking so that we can drop on other items
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Follow the pointer
        transform.position = eventData.position;

        // (Optional) If you want to update the placeholder’s position based on pointer position,
        // you can do so by checking the positions of siblings in the original parent.
        if (originalParent != null)
        {
            int newSiblingIndex = originalParent.childCount;
            for (int i = 0; i < originalParent.childCount; i++)
            {
                // Compare y coordinates (assuming a vertical layout, adjust if needed)
                if (transform.position.y > originalParent.GetChild(i).position.y)
                {
                    newSiblingIndex = i;
                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;
                    break;
                }
            }
            placeholder.transform.SetSiblingIndex(newSiblingIndex);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Return the dragged word to its original container, at the placeholder’s position
        transform.SetParent(originalParent);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        // Clean up the placeholder
        Destroy(placeholder);

        // Re-enable raycast blocking
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // Inform the game manager that a move was made
        WordGameManager gameManager = FindFirstObjectByType<WordGameManager>();
        if (gameManager != null)
        {
            gameManager.IncrementMoveCount();
        }
    }

}