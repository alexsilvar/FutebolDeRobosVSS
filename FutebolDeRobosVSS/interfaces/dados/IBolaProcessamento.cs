using FutebolDeRobosVSS.utilidades;
using System.Drawing;

namespace FutebolDeRobosVSS.interfaces.dados
{
    public interface IBolaProcessamento
    {
        Point Posicao { get; set; }

        Point PosicaoAnteiror { get; }

        Range RangeCorBola { get; set; }
    }
}