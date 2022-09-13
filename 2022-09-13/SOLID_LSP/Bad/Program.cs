using SOLID_LSP_BAD.Models;

var penguin = new Penguin(nameof(Penguin));
var kiwi = new Kiwi(nameof(Kiwi));

Bird bird1 = penguin;
Bird bird2 = kiwi;

bird1.Eat();
bird1.LayEggs();
bird1.Fly();

bird2.Eat();
bird2.LayEggs();
bird2.Fly();