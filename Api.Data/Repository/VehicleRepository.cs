using System.Linq;
using Api.Data;

public class VehicleRepository : IRepository<Vehicle>
{
    public void Add(Vehicle data)
    {
        using (Context context = new Context())
        {
            context.Vehicles.Add(data);
            context.SaveChanges();
        }
    }

    public Vehicle Get(string name)
    {
        using (Context context = new Context())
            {
                Vehicle databaseVehicle = context.Vehicles.FirstOrDefault(vehicle => vehicle.Name == name);
                return databaseVehicle;
            }
    }

    public void Update(string name)
    {
        using (Context context = new Context())
        {
            Vehicle databaseVehicle = context.Vehicles.FirstOrDefault(vehicle => vehicle.Name == name);
            context.Vehicles.Update(databaseVehicle); ;
            context.SaveChanges();
        }
    }
}