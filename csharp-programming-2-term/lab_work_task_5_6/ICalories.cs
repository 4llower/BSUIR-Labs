using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_task_5_6
{
    public interface ICalories : IComparable <ICalories>
    {
        string Name { get; }
        int Price { get; }
        int NumberOrder { get; }
        double getCalorieAbsorptionTime();
        double getCaloriesValue();
    }
}
