using System;
using CarMechanic.Shared;

namespace CarMechanic;
public class WorkHouresCalculator
{
    
    public int CalculateWorkHours(string kategoria, int gyartasiEv, int hibaSulyossag)
    {
        double kategoriaMunkaora = GetCategoryWorkHours(kategoria);
        double korSuly = GetAgeWeight(gyartasiEv);
        double hibaSulyossagSuly = GetSeverityWeight(hibaSulyossag);

        double munkaora = kategoriaMunkaora * korSuly * hibaSulyossagSuly;

        return (int)Math.Round(munkaora);
    }

    private double GetCategoryWorkHours(string kategoria)
    {
        switch (kategoria)
        {
            case "Karosszéria":
                return 3;
            case "Motor":
                return 8;
            case "Futómű":
                return 6;
            case "Fékberendezés":
                return 4;
            default:
                throw new ArgumentException("Ismeretlen kategória");
        }
    }

    private double GetAgeWeight(int gyartasiEv)
    {
        int autoEletkor = DateTime.Now.Year - gyartasiEv;

        if (autoEletkor >= 0 && autoEletkor < 5)
            return 0.5;
        else if (autoEletkor >= 5 && autoEletkor < 10)
            return 1;
        else if (autoEletkor >= 10 && autoEletkor < 20)
            return 1.5;
        else if (autoEletkor >= 20)
            return 2;
        else
            throw new ArgumentException("Érvénytelen gyártási év");
    }

    private double GetSeverityWeight(int hibaSulyossag)
    {
        if (hibaSulyossag >= 1 && hibaSulyossag < 3)
            return 0.2;
        else if (hibaSulyossag >= 3 && hibaSulyossag < 5)
            return 0.4;
        else if (hibaSulyossag >= 5 && hibaSulyossag < 8)
            return 0.6;
        else if (hibaSulyossag >= 8 && hibaSulyossag < 10)
            return 0.8;
        else if (hibaSulyossag == 10)
            return 1;
        else
            throw new ArgumentException("Érvénytelen hiba súlyosság");
    }
}