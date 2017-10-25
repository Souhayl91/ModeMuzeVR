namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;
    using UnityEngine.Playables;

    public class ButtonReactor : MonoBehaviour
    {
       
        private VRTK_Button_UnityEvents buttonEvents;
        public PlayableDirector tutorialTimeline;
        private void Start()
        {
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }

        private void handlePush(object sender, Control3DEventArgs e)
        {
            Destroy(GetComponent<VRTK_Button>());
            Destroy(GetComponent<ConstantForce>());
            Destroy(GetComponent<ConfigurableJoint>());
            Destroy(GetComponent<Rigidbody>());
            tutorialTimeline.Play();
            Debug.Log("PUSHHH");
        }
    }
}