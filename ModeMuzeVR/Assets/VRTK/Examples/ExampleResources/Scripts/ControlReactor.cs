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
            if(tutorialTimeline.time >= 12 && _infrontOfPlayer == false)
            {
                //AddComponents();
            }
        }

        private void AddComponents()
        {
            this.gameObject.AddComponent<VRTK_Lever>();
            VRTK_Lever lever = GetComponent<VRTK_Lever>();
            lever.direction = VRTK_Lever.LeverDirection.z;
            lever.minAngle = 0;
            lever.maxAngle = 60;
            lever.stepSize = 0.5f;
            lever.releasedFriction = 80;
            lever.grabbedFriction = 200;

            HingeJoint joint = GetComponent<HingeJoint>();
            joint.anchor = new Vector3(0, -0.5f, 0);
            joint.axis = new Vector3(0, 0, 1);
            joint.connectedAnchor = new Vector3(0.004001488f, 2.005949f, -7.866759f);
            GetComponent<Rigidbody>().angularDrag = 80f;
            //this.gameObject.AddComponent<ConstantForce>();
            //this.gameObject.AddComponent<HingeJoint>();
            //this.gameObject.AddComponent<Rigidbody>();

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
            Destroy(GetComponent<VRTK_Lever>());
            Destroy(GetComponent<ConstantForce>());
            Destroy(GetComponent<HingeJoint>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<VRTK_InteractableObject>());
        }

        public void HandleChange(object sender, Control3DEventArgs e)
        {
            Debug.Log(e.normalizedValue);
            if(e.normalizedValue >= 100)
            {
                Color newColor = new Color(0, 1, 0);
                GetComponent<MeshRenderer>().material.color = newColor;
                tutorialTimeline.playableGraph.GetRootPlayable(0).SetSpeed(1);
            }
        }


    }
}