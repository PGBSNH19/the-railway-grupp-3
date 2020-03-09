namespace TrainConsole
{
    public class TrackSwitch
    {
        private bool _isSwitchRight = false;


        public bool IsSwitchRight()
        {
            return _isSwitchRight;
        }

        public void ToggleSwitch()
        {
            if (_isSwitchRight)
            {
                _isSwitchRight = false;
            }
            else
            {
                _isSwitchRight = true;
            }
        }



    }
}
