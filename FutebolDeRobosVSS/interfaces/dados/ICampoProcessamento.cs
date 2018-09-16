using System.Drawing;

namespace FutebolDeRobosVSS.interfaces.dados
{
    public interface ICampoProcessamento
    {
        Rectangle Gol { get; set; }

        Rectangle GolAdversario { get; set; }

        Rectangle GrandeArea { get; set; }

        Rectangle GrandeAreaAdversario { get; set; }

        Rectangle MeioCampo { get; set; }

        Rectangle AreaTotal { get; set; }
    }
}