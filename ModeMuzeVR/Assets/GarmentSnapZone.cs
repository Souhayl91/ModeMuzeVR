using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarmentSnapZone : VRTK.VRTK_SnapDropZone {
    public GameObject storyLine;
    public GameObject garment;

    protected override void SnapObject(Collider collider)
    {
        VRTK.VRTK_InteractableObject ioCheck = ValidSnapObject(collider.gameObject, false);
        //If the item is in a snappable position and this drop zone isn't snapped and the collider is a valid interactable object
        if (willSnap && !isSnapped && ioCheck != null)
        {
            //Only snap it to the drop zone if it's not already in a drop zone
            if (!ioCheck.IsInSnapDropZone())
            {
                if (highlightObject != null)
                {
                    //Turn off the drop zone highlighter
                    SetHighlightObjectActive(false);
                }

                Vector3 newLocalScale = GetNewLocalScale(ioCheck);
                if (transitionInPlaceRoutine != null)
                {
                    StopCoroutine(transitionInPlaceRoutine);
                }

                isSnapped = true;
                currentSnappedObject = ioCheck.gameObject;
                if (cloneNewOnUnsnap)
                {
                    CreatePermanentClone();
                }

                var script = currentSnappedObject.GetComponent<Obi.ObiCloth>();
                if (script != null)
                {
                    script.enabled = false;
                }

                if(collider.gameObject == garment)
                {
                    storyLine.GetComponent<UnityEngine.Playables.PlayableDirector>().Play();
                }

                transitionInPlaceRoutine = StartCoroutine(UpdateTransformDimensions(ioCheck, highlightContainer, newLocalScale, snapDuration));

                ioCheck.ToggleSnapDropZone(this, true);

            }
        }

        //Force reset isSnapped if the item is grabbed but isSnapped is still true
        isSnapped = (isSnapped && ioCheck && ioCheck.IsGrabbed() ? false : isSnapped);
        wasSnapped = false;
    }
}
