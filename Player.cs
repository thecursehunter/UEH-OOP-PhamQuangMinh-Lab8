using System.Runtime.Serialization;
namespace OOP___Lab_8;

//Player Class
[DataContract]
public class Player {
    [DataMember]
    public string UserName { get; set; }
    [DataMember]
    public decimal RewardPoints { get; set; }
    [DataMember]
    public List<Product> Catalog { get; set; }

    public Player(string userName, decimal initialPoints)
    {
        UserName = userName;
        RewardPoints = initialPoints;
        Catalog = new List<Product>();
    }
    
    //method trồng cây
    public void Plant(Product product)
    {
        if (product.Cost <= RewardPoints)
        {
            Catalog.Add(product);
            RewardPoints -= product.Cost;
            product.Seed();
            System.Console.WriteLine($"{product.GetType().Name} đã được thêm vào trang trại của Nông Dân {UserName}.");
        }
        else 
        {
            System.Console.WriteLine("Không đủ điểm thưởng để mua vật phẩm này");
        }
    }
    //Thu hoạch hết mua vụ lấy tiền
    public void HarvestAll() {
        foreach (Product product in Catalog)
        {
            int numFertilizer = 0, numWater = 0;
            bool validInput = false;

            // Exception handling for fertilizer input
            while (!validInput)
            {
                try
                {
                    Console.WriteLine($"Nhập số lần bón phân cho {product.GetType().Name}:");
                    numFertilizer = int.Parse(Console.ReadLine());
                    if (numFertilizer < 0) throw new ArgumentException("Số lần bón phân phải lớn hơn hoặc bằng 0.");
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Nhập một số nguyên hợp lệ cho số lần bón phân.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            product.Feed(numFertilizer);

            // Reset validInput for watering input
            validInput = false;

            // Exception handling for watering input
            while (!validInput)
            {
                try
                {
                    Console.WriteLine($"Nhập số lần tưới nước cho {product.GetType().Name}:");
                    numWater = int.Parse(Console.ReadLine());
                    if (numWater < 0) throw new ArgumentException("Số lần tưới nước phải lớn hơn hoặc bằng 0.");
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Nhập một số nguyên hợp lệ cho số lần tưới nước.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            product.ProvWater(numWater);

            Console.WriteLine("Nhấn phím bất kỳ để thu hoạch sau khi thời gian chăm bón đã đủ.");
            Thread.Sleep(product.Duration * 1000);  // Simulate waiting time

            decimal profit = product.Harvest();
            RewardPoints += profit;
            Console.WriteLine($"Lãi thu được: {profit:C}.");
            Console.WriteLine($"{UserName} đã nhận được {profit:C} điểm!");
        }

        Catalog.Clear();
    }
}

