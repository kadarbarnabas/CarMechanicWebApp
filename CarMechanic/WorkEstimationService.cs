using System.Threading.Tasks;

namespace CarMechanic;

public class WorkEstimationService
{
    public int EstimateWorkHoursAsync(string category, int carAge, int severity)
    {
        // Kategória alapján meghatározott munkaóra
        int baseHours;
        switch (category)
        {
            case "Karosszéria":
                baseHours = 3;
                break;
            case "Motor":
                baseHours = 8;
                break;
            case "Futómű":
                baseHours = 6;
                break;
            case "Fékberendezés":
                baseHours = 4;
                break;
            default:
                baseHours = 0;
                break;
        }

        // Autó életkorából származó súlyozás
        double ageWeight;
        if (carAge >= 0 && carAge <= 5)
            ageWeight = 0.5;
        else if (carAge > 5 && carAge <= 10)
            ageWeight = 1;
        else if (carAge > 10 && carAge <= 20)
            ageWeight = 1.5;
        else
            ageWeight = 2;

        // Hiba súlyosságából származó súlyozás
        double severityWeight;
        if (severity >= 1 && severity <= 2)
            severityWeight = 0.2;
        else if (severity >= 3 && severity <= 4)
            severityWeight = 0.4;
        else if (severity >= 5 && severity <= 7)
            severityWeight = 0.6;
        else if (severity >= 8 && severity <= 9)
            severityWeight = 0.8;
        else
            severityWeight = 1;

        // Munkaóra esztimáció kiszámítása a képlet alapján
        double estimatedHours = baseHours * ageWeight * severityWeight;
        return (int)estimatedHours;
    }
}