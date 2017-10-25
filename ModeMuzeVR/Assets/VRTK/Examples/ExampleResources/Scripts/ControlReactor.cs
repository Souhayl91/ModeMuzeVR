namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;
    using UnityEngine.Playables;

    public class ControlReactor : MonoBehaviour
    {
        private VRTK_Control_UnityEvents controlEvents;
        public PlayableDirector tutorialTimeline;
        //public delegate void OnTimePassed();
        //public static event OnTimePassed PauseTimeline;

        private void Start()
        {
            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);
        }

        private void HandleChange(object sender, Control3DEventArgs e)
        {
            if(e.normalizedValue >= 100)
            {
                Color newColor = new Color(0, 1, 0);
                GetComponent<MeshRenderer>().material.color = newColor;
                tutorialTimeline.playableGraph.GetRootPlayable(0).SetSpeed(0);
            }
        }


    }
}