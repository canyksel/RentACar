using Core.Repositories;
using Domain.Enums;

namespace Domain.Entities;

public class Car : Entity<int>
{
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public CarState CarState { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }

    public virtual Color? Color { get; set; }
    public virtual Model? Model { get; set; }

    public Car()
    {

    }
    public Car(int id, int colorId, int modelId, CarState carState, int kilometer, short modelYear, string plate) : this()
    {
        Id = id;
        ColorId = colorId;
        ModelId = modelId;
        CarState = carState;
        Kilometer = kilometer;
        ModelYear = modelYear;
        Plate = plate;
    }
}
