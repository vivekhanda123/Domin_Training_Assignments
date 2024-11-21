// const numbers = [2,3,4,5,6,7,8,9,10,11,12];
// To check condition and return only single value
// const evenNumbers = numbers.find(num => num%2 === 0);
// console.log(evenNumbers);

const users=[
    {id:1,name:"Vivek",age:12},
    {id:2,name:"Shivam",age:13},
    {id:3,name:"Akshay",age:14}
];
const userVivek = users.find(u=>u.name==="Vivek");
console.log(userVivek);

const products = [
    {id:1,name:'Laptop',details:{price:49999,instock:true}},
    {id:1,name:'Phone',details:{price:49999,instock:false}},
    {id:1,name:'Speaker',details:{price:49999,instock:true}},
    {id:1,name:'Car',details:{price:49999,instock:false}},
    {id:1,name:'Watch',details:{price:49999,instock:true}},
];
const firstInStock = products.find(x=>x.details.instock);
console.log(firstInStock);