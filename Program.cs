namespace OOP___Lab_8;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Tạo Player
        Player player = new Player("Quang Minh ", 100);
        while (true) {
            Console.WriteLine($"Bạn có {player.RewardPoints:C} để gieo trồng.");
            Console.WriteLine("Chọn vật phẩm để gieo trồng:");
            Console.WriteLine("1. Lúa mì (5 điểm)");
            Console.WriteLine("2. Cà chua (3 điểm)");
            Console.WriteLine("3. Hoa hướng dương (20 điểm)");
            Console.WriteLine("0. Thoát");

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                Console.WriteLine("Cảm ơn bạn đã chơi HarvestFarm! Tạm biệt.");
                break;
            }

            switch (choice)
            {
                case "1":
                    player.Plant(new Wheat());
                    break;
                case "2":
                    player.Plant(new Tomato());
                    break;
                case "3":
                    player.Plant(new Sunflower());
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                    break;
            }

            if (player.Catalog.Count > 0)
            {
                player.HarvestAll();
            }

            Console.WriteLine();
        }
    }
}
