function solve(libraryInput, ordersInput) {
    let result = [];
    for (const order of ordersInput) {
        const obj = order.template;
        for (const part of order.parts) {
            obj[part] = libraryInput[part];
        }
        result.push(obj);
    }
 
    return result;
}




const library = {
  print: function () {
    console.log(`${this.name} is printing a page`);
  },
  scan: function () {
    console.log(`${this.name} is scanning a document`);
  },
  play: function (artist, track) {
    console.log(`${this.name} is playing '${track}' by ${artist}`);
  },
};

const orders = [
  {
    template: { name: 'ACME Printer'},
    parts: ['print']      
  },
  {
    template: { name: 'Initech Scanner'},
    parts: ['scan']      
  },
  {
    template: { name: 'ComTron Copier'},
    parts: ['scan', 'print']      
  },
  {
    template: { name: 'BoomBox Stereo'},
    parts: ['play']      
  },
];

solve(library, orders)