using System;
using System.IO;
using System.Linq;

namespace CovarianceAndContravarianceDelegateExample
{
    class Program
    {
        delegate Car CarFactoryDel(int id, string name);
        delegate void LogICECarDetailsDel(ICECar car);
        delegate void LogEVCarDetailsDel(EVCar car);
        static void Main(string[] args)
        {
            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar; //normalde CarFactoryDelin Car  tipinde döndürmesini bekliyoruz ancak burda ICECar döndürüyor. Buda covariance örneğidir.

            Car iceCar = carFactoryDel(1, "Audi R8");

            carFactoryDel = CarFactory.ReturnEvCar; // burda da aynı şekilde normalde CarFactoryDelin Car  tipinde döndürmesini bekliyoruz ancak burda EVCar döndürüyor. Buda covariance örneğidir.

            Car evCar = carFactoryDel(2, "Tesla Model-3"); 

            LogICECarDetailsDel logICECarDetailsDel = LogCarDetails;//normalde LogICECarDetailsDelin ICECar tipinde parametre almasını bekliyoruz ancak burda Car tipinde parametre alan LogCarDetails metodunu atıyoruz. Buda contravariance örneğidir.
                                                                    // yani eğer bir metot daha genel bir türü (car) kabul ediyorsa, bu metodu daha özel bir türü (ICECar) bekleyen bir delegate e atayabiliriz.

            logICECarDetailsDel(iceCar as ICECar); // burada iceCar car türünde ama LogICECarDetailsDel delegate i ICECar türünde parametre bekliyor. Bu yüzden iceCar ı ICECar a cast ediyoruz.

            LogEVCarDetailsDel logEVCarDetailsDel = LogCarDetails;

            logEVCarDetailsDel(evCar as EVCar);

            Console.ReadKey();

        }

        static void LogCarDetails(Car car)
        {
            if (car is ICECar)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICEDetails.txt"), true))
                {
                    sw.WriteLine($"Object Type: {car.GetType()}");
                    sw.WriteLine($"Car Detials: {car.GetCarDetails()}");
                }
                ;

            }
            else if (car is EVCar)
            {
                Console.WriteLine($"Object Type: {car.GetType()}");
                Console.WriteLine($"Car Detials: {car.GetCarDetails()}");
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name = name };
        }
        public static EVCar ReturnEvCar(int id, string name)
        {
            return new EVCar { Id = id, Name = name };
        }
    }
    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails()
        {
            return $"{Id} - {Name} ";
        }
    }
    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";
        }
    }
    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
        }
    }
}