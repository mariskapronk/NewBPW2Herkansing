using UnityEngine;

public class LockerIcon : MonoBehaviour, IInteractable
{

    public void Interact(DisplayImage currentDisplay)
    {
        transform.parent.GetComponent<IconLock>().currentIndividualIndex[transform.GetSiblingIndex()]++;

        if (transform.parent.GetComponent<IconLock>().currentIndividualIndex[transform.GetSiblingIndex()] > 9)
            transform.parent.GetComponent<IconLock>().currentIndividualIndex[transform.GetSiblingIndex()] = 0;

        this.gameObject.GetComponent<SpriteRenderer>().sprite =
            transform.parent.GetComponent<IconLock>().numberSprites[transform.parent.GetComponent<IconLock>().currentIndividualIndex[transform.GetSiblingIndex()]];
    }


}
