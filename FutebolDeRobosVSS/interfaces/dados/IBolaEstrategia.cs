using FutebolDeRobosVSS.utilidades;
using System.Drawing;

namespace FutebolDeRobosVSS.interfaces.dados
{
    public interface IBolaEstrategia
    {
        Point Posicao { get; }

        Point PosicaoAnteiror { get; }

    }
}