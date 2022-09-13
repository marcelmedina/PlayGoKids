
#region Case1
var duck1 = new SOLID_LSP_GOOD.Models.Case1.Duck(nameof(SOLID_LSP_GOOD.Models.Case1.Duck));
var kiwi1 = new SOLID_LSP_GOOD.Models.Case1.Kiwi(nameof(SOLID_LSP_GOOD.Models.Case1.Kiwi));

SOLID_LSP_GOOD.Models.Case1.Bird bird1C1 = duck1;
SOLID_LSP_GOOD.Models.Case1.Bird bird2C1 = kiwi1;

bird1C1.Eat();
bird1C1.LayEggs();
duck1.Fly();

bird2C1.Eat();
bird2C1.LayEggs();
#endregion

#region Case2
var duck2 = new SOLID_LSP_GOOD.Models.Case2.Duck(nameof(SOLID_LSP_GOOD.Models.Case2.Duck));
var kiwi2 = new SOLID_LSP_GOOD.Models.Case2.Kiwi(nameof(SOLID_LSP_GOOD.Models.Case2.Kiwi));

SOLID_LSP_GOOD.Models.Case2.FlyingBird bird1C2 = duck2;
SOLID_LSP_GOOD.Models.Case2.Bird bird2C2 = kiwi2;

bird1C2.Eat();
bird1C2.LayEggs();
bird1C2.Fly();

bird2C2.Eat();
bird2C2.LayEggs();
#endregion