let {assert} = require('chai');

const testNumbers = {
    sumNumbers: function (num1, num2) {
        let sum = 0;

        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        } else {
            sum = (num1 + num2).toFixed(2);
            return sum
        }
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input % 2 === 0) {
            return 'The number is even!';
        } else {
            return 'The number is odd!';
        }

    },
    averageSumArray: function (arr) {

        let arraySum = 0;

        for (let i = 0; i < arr.length; i++) {
            arraySum += arr[i]
        }

        return arraySum / arr.length
    }
};

describe("Tests …", function() {
    describe("TODO …", function() {
        it("TODO …", function() {
            assert.equal(testNumbers.sumNumbers(1, 2), 3)
        });
        it("TODO …", function() {
            assert.equal(testNumbers.sumNumbers(1, '  '), undefined)
        });
        it("TODO …", function() {
            assert.equal(testNumbers.sumNumbers(' ', 1), undefined)
        });
        it("TODO …", function() {
            assert.throws(() => testNumbers.numberChecker('  '), 'The input is not a number!')
        });
        it("TODO …", function() {
            assert.equal(testNumbers.numberChecker(4), 'The number is even!')
        });
        it("TODO …", function() {
            assert.equal(testNumbers.numberChecker(3), 'The number is odd!')
        });
        it("TODO …", function() {
            assert.equal(testNumbers.averageSumArray([2, 2, 2, 2]), 2)
        });
     });
});


