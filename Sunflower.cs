using System.Runtime.Serialization;

namespace OOP___Lab_8;

//Sunflower Class
[DataContract]
public class Sunflower : Product {
    public Sunflower() : base(20,70,6,4,3) {
        
    }
    public override void Seed() {
        Console.WriteLine($"Hoa hướng dương đã được gieo trồng vào {DateTime.Now}. Thời gian chăm bón: 00:00:{Duration} giây.");
    }
}
