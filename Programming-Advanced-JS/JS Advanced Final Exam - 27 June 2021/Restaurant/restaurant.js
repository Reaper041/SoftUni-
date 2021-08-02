class Restaurant {


    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        let resultArr = [];


        for (let index = 0; index < products.length; index++) {
            let action = '';

            let [productName, productQuantity, productPrice] = products[index].split(' ');

            if (Number(productPrice) <= this.budgetMoney) {
                this.budgetMoney -= Number(productPrice);

                if (this.stockProducts[productName]) {
                    this.stockProducts[productName] += Number(productQuantity);
                } else {
                    this.stockProducts[productName] = Number(productQuantity);
                }
                action = `Successfully loaded ${productQuantity} ${productName}`;

            } else {
                action = `There was not enough money to load ${productQuantity} ${productName}`;
            }

            this.history.push(action);
            resultArr.push(action);
        }

        return resultArr.join('\n');
    }

    addToMenu(meal, neededProducts, price) {

        if (this.menu[meal]) {
            return `The ${meal} is already in the our menu, try something different.`;
        } else {
            this.menu[meal] = {
                products: neededProducts,
                price: Number(price)
            }
        }

        if (Object.keys(this.menu).length == 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else if (Object.keys(this.menu).length > 1) {
            return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
        }

    }

    showTheMenu() {
        if (Object.keys(this.menu).length <= 0) {
            return "Our menu is not ready yet, please come later...";
        }

        let result = '';

        for (const meal in this.menu) {
            result += `${meal} - $ ${this.menu[meal].price}\n`;
        }

        return result.trimEnd();
    }

    makeTheOrder(meal) {
        if (!Object.keys(this.menu).includes(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }
        let mealCanBeCooked = true;
        this.menu[meal].products.forEach(x => {
            let [productName, productQuantity] = x.split(' ');
            if (!this.stockProducts[productName] || this.stockProducts[productName] < Number(productQuantity)) {
                mealCanBeCooked = false;
            }
        })
        if (!mealCanBeCooked) {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }
        this.menu[meal].products.forEach(x => {
            let [productName, productQuantity] = x.split(' ');
            this.stockProducts[productName] -= Number(productQuantity);
        })
        this.budgetMoney += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}

let kitchen = new Restaurant(1000);
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.showTheMenu());


