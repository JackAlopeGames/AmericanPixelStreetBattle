using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(RectTransform))]
public class UIJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
	
	public RectTransform handle;
	public float radius = 40f;
	public float autoReturnSpeed = 8f;
	private bool returnToStartPos;
	private RectTransform parentRect;
	private InputManager inputmanager;
    public float timerToRun;
    public GameObject player;
    public Animator Anim;

    private bool SecondTime;

    public bool isUsing;

	void OnEnable(){
		inputmanager = GameObject.FindObjectOfType<InputManager>();
		returnToStartPos = true;
		handle.transform.SetParent(transform);
		parentRect = GetComponent<RectTransform>();
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.Anim = this.player.transform.GetChild(0).GetComponent<Animator>();
	}
		
	void Update() {

		//return to start position
		if (returnToStartPos) {
            timerToRun = 0;
            isUsing = false;
            if (handle.anchoredPosition.magnitude > Mathf.Epsilon) {
                SecondTime = true;
                handle.anchoredPosition -= new Vector2 (handle.anchoredPosition.x * autoReturnSpeed, handle.anchoredPosition.y * autoReturnSpeed) * Time.deltaTime;
				inputmanager.dir = Vector2.zero;
            } else {
				returnToStartPos = false;
            }
            try
            {
                this.Anim.SetBool("StartRunning", false);
            }
            catch { }
            this.player.GetComponent<PlayerMovement>().walkSpeed = 3.0f;
        }

        if (!returnToStartPos && SecondTime)
        {
            isUsing = true;
            timerToRun += Time.deltaTime;
            if (this.timerToRun > 3)
            {
                try
                {
                    this.Anim.SetBool("StartRunning", true);
                }
                catch { }
                this.player.GetComponent<PlayerMovement>().walkSpeed = 5.0f;
            }
        }
	}

	//return coordinates
	public Vector2 Coordinates {
		get	{
			if (handle.anchoredPosition.magnitude < radius){
				return handle.anchoredPosition / radius;
			}
			return handle.anchoredPosition.normalized;
		}
	}

	//touch down
	void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
		returnToStartPos = false;
		var handleOffset = GetJoystickOffset(eventData);
		handle.anchoredPosition = handleOffset;
		if(inputmanager != null) inputmanager.dir = handleOffset.normalized;
	}

	//touch drag
	void IDragHandler.OnDrag(PointerEventData eventData) {
		var handleOffset = GetJoystickOffset(eventData);
		handle.anchoredPosition = handleOffset;
		if(inputmanager != null) inputmanager.dir = handleOffset.normalized;
	}

	//touch up
	void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
		returnToStartPos = true;
	}

	//get offset
	private Vector2 GetJoystickOffset(PointerEventData eventData) {
		
		Vector3 globalHandle;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle (parentRect, eventData.position, eventData.pressEventCamera, out globalHandle)) {
			handle.position = globalHandle;
		}

		var handleOffset = handle.anchoredPosition;
		if (handleOffset.magnitude > radius) {
			handleOffset = handleOffset.normalized * radius;
			handle.anchoredPosition = handleOffset;
		}
		return handleOffset;
	}
}