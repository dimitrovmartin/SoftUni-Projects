const {assert, expect} = require('chai');

const flowerShop = {
    calcPriceOfFlowers(flower, price, quantity) {
        if (typeof flower != 'string' || !Number.isInteger(price) || !Number.isInteger(quantity)) {
            throw new Error('Invalid input!');
        } else {
            let result = price * quantity;
            return `You need $${result.toFixed(2)} to buy ${flower}!`;
        }
    },
    checkFlowersAvailable(flower, gardenArr) {
        if (gardenArr.indexOf(flower) >= 0) {
            return `The ${flower} are available!`;
        } else {
            return `The ${flower} are sold! You need to purchase more!`;
        }
    },
    sellFlowers(gardenArr, space) {
        let shop = [];
        let i = 0;
        if (!Array.isArray(gardenArr) || !Number.isInteger(space) || space < 0 || space >= gardenArr.length) {
            throw new Error('Invalid input!');
        } else {
            while (gardenArr.length > i) {
                if (i != space) {
                    shop.push(gardenArr[i]);
                }
                i++
            }
        }
        return shop.join(' / ');
    }
}


describe("FlowerShop tests …", function() {
    describe("calcPriceOfFlowers …", function() {
        it("calcPriceOfFlowers throws when flower is not string…", function() {
            expect(() => {flowerShop.calcPriceOfFlowers(1,1,2)}).to.throw('Invalid input!')

        });
        it("calcPriceOfFlowers throws number is not an integer…", function() {
            expect(() => {flowerShop.calcPriceOfFlowers(1,"1",2)}).to.throw('Invalid input!')
            expect(() => {flowerShop.calcPriceOfFlowers(1, 0.5 ,2)}).to.throw('Invalid input!')
            
        });
        it("calcPriceOfFlowers throws when quantity is not an integer …", function() {
            expect(() => {flowerShop.calcPriceOfFlowers(1,1,"2")}).to.throw('Invalid input!')
        });
        it('calcPriceOfFlowers passes', function() {
            expect(flowerShop.calcPriceOfFlowers('Cvete', 20, 10)).to.equal(`You need $200.00 to buy Cvete!`)
        })
     });
     
     describe("checkFlowersAvailable …", function() {
        it("checkFlowersAvailable are available…", function() {
            expect(flowerShop.checkFlowersAvailable('Rose', ["Rose", "Lily", "Orchid"])).to.equal('The Rose are available!')
        });
        it("calcPriceOfFlowers throws number is not an integer…", function() {
            expect(flowerShop.checkFlowersAvailable('Gosho', ["Rose", "Lily", "Orchid"])).to.equal('The Gosho are sold! You need to purchase more!')
        })
     });


     describe("sellFlowers …", function() {
        it("sellFlowers are available…", function() {
            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 0)).to.equal('Lily / Orchid')
        });
        it("sellFlowers throws number isarray…", function() {
            expect(() => {flowerShop.sellFlowers(0, 0)}).to.throw('Invalid input!')
        })
        it("sellFlowers throws.2", function() {
            expect(() => {flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], "0")}).to.throw('Invalid input!')
            expect(() => {flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 5.2)}).to.throw('Invalid input!')
        })
        it("sellFlowers throws number 3", function() {
            expect(() => {flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], -1)}).to.throw('Invalid input!')
        })
        it("sellFlowers throws number 4", function() {
            expect(() => {flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 3)}).to.throw('Invalid input!')
        })
        it("sellFlowers throws number 5", function() {
            expect(() => {flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 5)}).to.throw('Invalid input!')
        })
     });
});

