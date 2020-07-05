namespace BerlinClock
{
    public class Lamp
    {
        private bool OnOff { get; set; }
        protected string Color { get; set; }
        public Lamp()
        {
            Color = "W";
        }
        public string GetColor()
        {
            return OnOff ? Color : "O";
        }
        public void TurnOn()
        {
            OnOff = true;
        }

        public void TurnOff()
        {
            OnOff = false;
        }
    }
}
