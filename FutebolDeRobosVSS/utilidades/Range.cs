using Emgu.CV.Structure;

namespace FutebolDeRobosVSS.utilidades
{
    public class Range
    {
        private Hsv lowerrange;
        public Hsv Lowerrange
        {
            get { return lowerrange; }
            set { lowerrange = value; }
        }
        private Hsv upperrange;
        public Hsv Upperrange
        {
            get { return upperrange; }
            set { upperrange = value; }
        }

        private int deltalow;
        public int Deltalow
        {
            get { return deltalow; }
            set { deltalow = value; }
        }
        private int deltahigh;
        public int Deltahigh
        {
            get { return deltahigh; }
            set { deltahigh = value; }
        }


        public Range(Hsv targetColor, int deltalow = 30, int deltahigh = 30)
        {
            lowerrange = new Hsv(targetColor.Hue - deltalow, targetColor.Satuation - deltalow, targetColor.Value - deltalow);
            upperrange = new Hsv(targetColor.Hue + deltahigh, targetColor.Satuation + deltahigh, targetColor.Value + deltahigh);
        }
    }
}
