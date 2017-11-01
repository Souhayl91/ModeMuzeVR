namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;
    using UnityEngine.Playables;

    public class ControlReactor : MonoBehaviour
    {
        
        private VRTK_Control_UnityEvents controlEvents;
        public PlayableDirector tutorialTimeline;
        private bool _infrontOfPlayer;
        //public delegate void OnTimePassed();
        //public static event OnTimePassed PauseTimeline;
        
        private void Start()
        {
            _infrontOfPlayer = false;
            //RemoveComponents();

            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);

        }

        private void Update()
        {
            if(tutorialTimeline.time >= 15 && _infrontOfPlayer == false)
            {
                //AddComponents();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tutorialTimeline.time = 15;
            }
        }

        private void AddComponents()
        {
            //this.gameObject.AddComponent<VRTK_Lever>();
            //VRTK_Lever lever = GetComponent<VRTK_Lever>();
            //lever.direction = VRTK_Lever.LeverDirection.z;
            //lever.minAngle = 0;
            //lever.maxAngle = 60;
            //lever.stepSize = 0.5f;
            //lever.releasedFriction = 80;
            //lever.grabbedFriction = 200;

          
            GetComponent<VRTK_Lever>().enabled = true;

            //GetComponent<ConstantForce>().enabled = true;
            GetComponent<VRTK_InteractableObject>().enabled = true;

            HingeJoint joint = GetComponent<HingeJoint>();
            joint.connectedBody = this.GetComponent<Rigidbody>();
            //joint.anchor = new Vector3(0, -0.5f, 0);
            //joint.axis = new Vector3(0, 0, 1);
            //joint.connectedAnchor = new Vector3(0.004001488f, 2.005949f, -7.866759f);
            GetComponent<Rigidbody>().angularDrag = 80f;
            //this.gameObject.AddComponent<ConstantForce>();
           
            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);
            _infrontOfPlayer = true;

        }
        private void RemoveComponents()
        {
            GetComponent<VRTK_InteractableObject>().enabled = false;
            GetComponent<VRTK_Lever>().enabled = false;

            if(GetComponent<ConstantForce>() != null)
                GetComponent<ConstantForce>().enabled = false;
            //HingeJoint join = GetComponent<HingeJoint>();
            //Rigidbody emptyRigid = new Rigidbody();
            //join.connectedBody = emptyRigid;
            GetComponent<Rigidbody>().detectCollisions = false;
            //Destroy(GetComponent<HingeJoint>());
            
        }

        public void HandleChange(object sender, Control3DEventArgs e)
        {
            if(e.normalizedValue >= 100)
            {
                Color newColor = new Color(0, 1, 0);
                GetComponent<MeshRenderer>().material.color = newColor;
                tutorialTimeline.playableGraph.GetRootPlayable(0).SetSpeed(1);
            }
        }


    }
}