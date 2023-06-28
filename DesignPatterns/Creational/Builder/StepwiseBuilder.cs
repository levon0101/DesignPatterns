namespace DesignPatterns.Creational.Builder;

public class StepwiseBuilder
{
    public static void Run()
    {
       var car = CarStepwiseBuilder.Create()
            .OfType(CarType.Crossover)
            .WithWheels(17)
            .Build();

        Console.WriteLine(car.ToString());
    }
}

#region Models


public enum CarType
{
    Sedan,
    Crossover
};
public class Car
{
    public CarType Type;
    public int WheelSize;

    public override string ToString()
    {
        return $"CarType: {Type}, WheelSize: {WheelSize}";
    }
}


#endregion

public class CarStepwiseBuilder
{
    private class Impl : ISpecifyCarType, ISpecifyWheelSize, ICarBuilder
    {
        private Car car = new();
        public ISpecifyWheelSize OfType(CarType carType)
        {
            car.Type = carType;
            return this;
        }

        public ICarBuilder WithWheels(int wheelSize)
        {
            switch (car.Type)
            {
                case CarType.Sedan when wheelSize < 17 || wheelSize > 20:
                case CarType.Crossover when wheelSize < 15 || wheelSize > 17:
                    throw new ArgumentException($"Wheel size not applicable for {car.Type}");
            }
            car.WheelSize = wheelSize;
            return this;
        }

        public Car Build()
        {
            return car;
        }
    }

    public static ISpecifyCarType Create()
    {
        return new Impl();
    }
}

public interface ISpecifyCarType
{
    ISpecifyWheelSize OfType(CarType carType);
}
public interface ISpecifyWheelSize
{
    ICarBuilder WithWheels(int wheelSize);
}
public interface ICarBuilder
{
    Car Build();
} 