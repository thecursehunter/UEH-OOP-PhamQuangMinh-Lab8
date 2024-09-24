using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml;
namespace OOP___Lab_8;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string filePath = "playerData.xml";
        Player player;

        //Bước 1: load dữ liệu của player
        DataContractSerializer serializer = new DataContractSerializer(typeof(Player));
        if (File.Exists(filePath)) {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open)) {
                player = (Player)serializer.ReadObject(fileStream);
                System.Console.WriteLine("Dữ liêu được tải thành công");
            }
        } 
        else {
            //không có dữ liệu được lưu, tạo người chơi mới
            player = new Player("Quang Minh ", 100);
            System.Console.WriteLine("Tạo người chơi mới");
        }
        
        //game loop
        while (true) {
            Console.WriteLine($"Bạn có {player.RewardPoints:C} để gieo trồng.");
            Console.WriteLine("Chọn vật phẩm để gieo trồng:");
            Console.WriteLine("1. Lúa mì (5 điểm)");
            Console.WriteLine("2. Cà chua (3 điểm)");
            Console.WriteLine("3. Hoa hướng dương (20 điểm)");
            Console.WriteLine("4. Lưu trò chơi vào file");
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
                case "4":
                    // Step 4: Save game state manually
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create)) {
                        serializer.WriteObject(fileStream, player);
                    }
                    Console.WriteLine("Dữ liệu đã được lưu thành công vào file.");
                    continue;  // Go back to the game loop
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                    continue;
            }

            if (player.Catalog.Count > 0)
            {
                player.HarvestAll();
            }

            Console.WriteLine();

            //Lưu game sau mỗi lần chạy
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create)) {
                serializer.WriteObject(fileStream, player);
            }
        }

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            serializer.WriteObject(fileStream, player);  // Serialize player data
        }

        Console.WriteLine("Dữ liệu đã được lưu thành công.");
    }
}