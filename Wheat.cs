using System.Runtime.Serialization;

namespace OOP___Lab_8;

//Wheat Class
[DataContract]
public class Wheat : Product {
    public Wheat() : base(10,50,7,2,1) {
        
    }
    public override void Seed() {
        Console.WriteLine($"Lúa mì đã được gieo trồng vào {DateTime.Now}. Thời gian chăm bón: 00:00:{Duration} giây.");
    }
}
