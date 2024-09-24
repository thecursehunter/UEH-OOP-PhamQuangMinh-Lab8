using System.Runtime.Serialization;
namespace OOP___Lab_8;

//Abstract Product Class
[DataContract]
[KnownType(typeof(Wheat))]
[KnownType(typeof(Tomato))]
[KnownType(typeof(Sunflower))]
public abstract class Product {
    [DataMember]
    public decimal Cost { get; set; }
    [DataMember]
    public decimal Value { get; set; }
    [DataMember]
    public DateTime Start { get; set; }
    [DataMember]
    public int Duration;
    [DataMember]
    public decimal FertilizerCost { get; set; }
    [DataMember]
    public decimal WaterCost { get; set; }
    [DataMember]
    public int NumFertilizer { get; set; }
    [DataMember]
    public int NumWater { get; set; }
    //Constructor
    public Product(decimal cost, decimal value, int duration, decimal fertilizerCost, decimal waterCost) {
        Cost = cost;
        Value = value;
        Duration = duration; //đặt cái này là int để tính ngày
        FertilizerCost = fertilizerCost;
        WaterCost = waterCost;
        Start = DateTime.Now;
    }
    //Abstract class to be implemented by the derived classes
    public abstract void Seed();
    public virtual decimal Harvest() {
        decimal totalCost = Cost + (NumFertilizer * FertilizerCost) + (NumWater * WaterCost);
        Console.WriteLine($"Tổng chi phí: {totalCost:C}. Giá trị thu hoạch: {Value:C}.");
        return Value - totalCost; // Profit
    }

    public void Feed(int numFertilizer)
    {
        NumFertilizer = numFertilizer;
    }

    public void ProvWater(int numWater)
    {
        NumWater = numWater;
    }
}
