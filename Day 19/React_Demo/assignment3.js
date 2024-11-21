// You are provided with an array of user orders.
// Your task is to process these orders and generate a summary report
//  using JavaScript array methods.
 
// 1)List the orders to include only those that are delivered.
 
// 2) filtered orders to an array of objects with only userId and amount.
 
// 3) Finds the first order placed by the user with userId 102.
 
// 4) filtered orders to calculate the total revenue.
 
// note :you can use map(), filter(), find(), and reduce() methods
 
// Given Data:
const orders = [
  { id: 1, userId: 101, product: 'Laptop', amount: 999, delivered: true },
  { id: 2, userId: 102, product: 'Phone', amount: 699, delivered: false },
  { id: 3, userId: 101, product: 'Tablet', amount: 499, delivered: true },
  { id: 4, userId: 103, product: 'Monitor', amount: 199, delivered: true },
  { id: 5, userId: 104, product: 'Keyboard', amount: 49, delivered: false },
  { id: 6, userId: 102, product: 'Mouse', amount: 25, delivered: true },
  { id: 7, userId: 105, product: 'Printer', amount: 150, delivered: true },
  { id: 8, userId: 106, product: 'Webcam', amount: 75, delivered: false },
  { id: 9, userId: 107, product: 'Speakers', amount: 85, delivered: true },
  { id: 10, userId: 108, product: 'Router', amount: 120, delivered: true },
];

// Question 1
// var firstResult = orders.filter(x=>x.delivered);
// console.log(listResult);

// Question 2
// var secondResult = orders.map(x=>({userId:x.userId,amount:x.amount}));
// console.log(secondResult);

// Question 3
// var thirdResult = orders.find(x => x.userId===102);
// console.log(thirdResult);

// Question 4
var fourthResult = orders.reduce((total,order) => total + order.amount,0);
console.log(fourthResult);