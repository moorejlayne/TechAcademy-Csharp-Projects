function Monster(initialMonster, newDamage) {
    var self = this;
    self.monster = ko.observable(initialMonster);
    self.newDamageTaken = ko.observable(newDamage);
    self.updateDamage = ko.computed(function () {
        var newHP = self.monster().currentHP() - self.newDamageTaken();
        self.monster().currentHP(newHP);
        self.newDamageTaken(0);
    });
}

function MonsterViewModel() {
    var self = this;

    self.monsterOptions = [
        { monsterName: "Ancient Red Dragon", maxHP: 546, currentHP: ko.observable(546)},
        { monsterName: "Beholder", maxHP: 180, currentHP: ko.observable(180)},
        { monsterName: "Bugbear", maxHP: 27, currentHP: ko.observable(27)},
        { monsterName: "Cloaker", maxHP: 78, currentHP: ko.observable(78)},
        { monsterName: "Hobgoblin", maxHP: 11, currentHP: ko.observable(11)},
        { monsterName: "Kobold", maxHP: 5, currentHP: ko.observable(5)},
        { monsterName: "Mimic", maxHP: 58,currentHP: ko.observable(58)},
        { monsterName: "Nightmare", maxHP: 68, currentHP: ko.observable(68)},
        { monsterName: "Pixie", maxHP: 1, currentHP: ko.observable(1)},
        { monsterName: "Shadow Demon", maxHP: 66, currentHP: ko.observable(66)},
        { monsterName: "Yeti", maxHP: 51, currentHP: ko.observable(51)}
    ];

    self.monsters = ko.observableArray([
        new Monster(self.monsterOptions[0], 0, ko.observable(self.monsterOptions[0].maxHP))
    ]);

    // Add / remove monsters
    self.addMonster = function () {
        self.monsters.push(new Monster(self.monsterOptions[0], 0));
    }
    self.removeMonster = function (monster) { self.monsters.remove(monster) }
}
ko.applyBindings(new MonsterViewModel());