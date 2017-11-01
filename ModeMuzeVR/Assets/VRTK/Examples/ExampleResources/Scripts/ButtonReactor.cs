namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;
    using UnityEngine.Playables;

    public class ButtonReactor : MonoBehaviour
    {
       
        private VRTK_Button_UnityEvents buttonEvents;
        public PlayableDirector tutorialTimeline;
        public GameObject lever;
        private bool isEnabled = false;

        private void Start()
        {
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }

        private void Update()
        {
            if(tutorialTimeline.time >= 12 && isEnabled == false)
            {
                lever.GetComponent<MeshRenderer>().enabled = true;
                Transform[] allChildren = lever.GetComponentsInChildren<Transform>();

                foreach (Transform item in allChildren)
                {
                    if (item.gameObject.GetComponent<MeshRenderer>() != null)
                        item.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                isEnabled = true;
            }
        }
        private void handlePush(object sender, Control3DEventArgs e)
        {
            Destroy(GetComponent<VRTK_Button>());
            Destroy(GetComponent<ConstantForce>());
            Destroy(GetComponent<ConfigurableJoint>());
            Destroy(GetComponent<Rigidbody>());
            tutorialTimeline.Play();
        }
    }
}