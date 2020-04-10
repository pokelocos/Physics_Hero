using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private CameraMovement cameraMovement;
    public ActionableValue actionable;

    public float SpeedRotation;
    public float zoomSpeed;
    public float angularSpeed;

    public FloatBar magnitud = new FloatBar(0.5f,0,1);

    public UnityEvent OnActionModeChange;
    public UnityEvent OnAction;

    private void Awake()
    {
        cameraMovement = GameObject.FindObjectOfType<CameraMovement>();
        OnActionModeChange.Invoke();
    }

    public void ChageFroceControl()
    {
       
        magnitud.current += -Input.GetAxis("AngularAxis") * angularSpeed * Time.deltaTime;
        magnitud.current = Mathf.Clamp(magnitud.current,0,1);
        
    }

    public void ChangeActionModeControl()
    {
        
        string[] Controls = Input.GetJoystickNames();
        if (Controls.Length > 0)
        {
            
            if (Input.GetButtonDown("RightBumper"))
            {
                (actionable.value as Character).typeAction++;
 
                if((int)(actionable.value as Character).typeAction >= Enum.GetValues(typeof(TypeAction)).Length)
                {
                    (actionable.value as Character).typeAction = 0;
                }
                OnActionModeChange.Invoke();
            }
            else if (Input.GetButtonDown("LeftBumper"))
            {
                (actionable.value as Character).typeAction--;
                if ((int)(actionable.value as Character).typeAction < 0)
                {
                    (actionable.value as Character).typeAction = (TypeAction)(Enum.GetValues(typeof(TypeAction)).Length - 1);
                }
                OnActionModeChange.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { (actionable.value as Character).typeAction = TypeAction.LineMovement; OnActionModeChange.Invoke(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { (actionable.value as Character).typeAction = TypeAction.JumpMovement; OnActionModeChange.Invoke(); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { (actionable.value as Character).typeAction = TypeAction.PrimaryAttack; OnActionModeChange.Invoke(); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { (actionable.value as Character).typeAction = TypeAction.SecondaryAtack; OnActionModeChange.Invoke(); }
        
    }

    public void ActionControl(BoolValue next)
    {
        if (Input.GetButtonDown("Jump"))
        {
            OnAction.Invoke();
            next.value = true;
            actionable.value.Action(cameraMovement.transform.forward, magnitud.current);
        }
        else
        {
            next.value = false;
        }
    }

    public void RotationControl()
    {
        
        //cameraMovement.camera.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * SpeedRotation * Time.deltaTime);
        cameraMovement.camera.transform.Translate(Vector3.up * Input.GetAxis("Vertical") * SpeedRotation * Time.deltaTime);

        //cameraMovement.transform.Rotate(Vector3.right * Input.GetAxis("Vertical") * SpeedRotation * Time.deltaTime);
        cameraMovement.transform.Rotate(Vector3.up * -Input.GetAxis("Horizontal") * SpeedRotation * 3 * Time.deltaTime);
        
    }

    public void ZoomControl()
    {
        
        GameObject camera = cameraMovement.camera.gameObject;
        camera.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime);
        
    }

}
