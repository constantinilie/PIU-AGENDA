using System;
using System.CodeDom;


namespace Obiect.Enumerari
{
    public enum TipActivitate // TEMA LAB 5 1.a
    {
        Scoala = 1,
        Facultate = 2,
        Serviciu = 3,
        Recreere = 4,
        Reminder = 5
    };

    [Flags]
    public enum OptiuniActivitate // TEMA LAB 5 1.b
    {
        Fara = 0,
        Notificari = 1,
        Repetare = 2,
        Alarme = 4

    };
}
