namespace OOP___Lab_8;

//Tomato Class
public class Tomato : Product {
    public Tomato() : base(15,60,5,3,2) {
        
    }
    public override void Seed() {
        Console.WriteLine($"Cà chua đã được gieo trồng vào {DateTime.Now}. Thời gian chăm bón: 00:00:{Duration} giây.");
    }
}
