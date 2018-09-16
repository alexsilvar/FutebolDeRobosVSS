using System.Drawing;

namespace FutebolDeRobosVSS.interfaces.dados
{
    public interface ICampoEstrategia
    {
        Rectangle Gol { get; }

        Rectangle GolAdversario { get; }

        Rectangle GrandeArea { get; }

        Rectangle GrandeAreaAdversario { get; }

        Rectangle MeioCampo { get; }

        Rectangle AreaTotal { get; }
    }
}