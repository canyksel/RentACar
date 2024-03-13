using Core.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car : Entity
{
    public int ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }

    public virtual Brand? Brand { get; set; }
    public virtual Model? Model { get; set; }

    public Car()
    {
        
    }
    public Car(int id, int modelId, CarState carState, int kilometer, short modelYear, string plate): this()
    {
        Id = id;
        ModelId = modelId;
        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
    }
}
