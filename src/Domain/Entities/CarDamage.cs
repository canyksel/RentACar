using Core.Repositories;

namespace Domain.Entities
{
    public class CarDamage : Entity<int>
    {
        public int CarId { get; set; }
        public string DamageDescription { get; set; }
        public bool IsFixed { get; set; }

        public virtual Car? Car { get; set; }

        public CarDamage()
        {          
        }

        public CarDamage(int id, int carId, string damageDescription, bool isFixed) : this()
        {
            Id = id;
            CarId = carId;
            DamageDescription = damageDescription;
            IsFixed = isFixed;
        }
    }
}
