namespace OOP___Lab_8;

//Abstract Product Class
public abstract class Product {
    public decimal Cost { get; set; }
    public decimal Value { get; set; }
    public DateTime Start { get; set; }
    public int Duration;
    public decimal FertilizerCost { get; set; }
    public decimal WaterCost { get; set; }

    public int NumFertilizer { get; set; }
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
