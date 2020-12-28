using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;


public class ButtonEffect : MonoBehaviour
{
    InteractionBehaviour interactionBehaviour;
    GameObject hoverEfx;
    GameObject touchEfx;

    // Start is called before the first frame update
    void Start()
    {
        interactionBehaviour = GetComponent<InteractionBehaviour>();
        hoverEfx = transform.Find("HoverEfx").gameObject;
        touchEfx = transform.Find("TouchEfx").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionBehaviour.isPrimaryHovered)
            hoverEfx.SetActive(true);
        else
            hoverEfx.SetActive(false);

        if ((interactionBehaviour as InteractionButton).isPressed)
            touchEfx.SetActive(true);
        else
            touchEfx.SetActive(false);

    }
}
