// const numbers = [2,3,4,5,6,7,8,9,10,11,12];
// const evenNumbers = numbers.filter(num => num%2 == 0);
// console.log(evenNumbers);

// Array of objects 
// const users=[
//     {id:1,name:"Vivek",age:12},
//     {id:2,name:"Shivam",age:13},
//     {id:3,name:"Akshay",age:14}
// ];

// const teenAgeUsers = users.filter(user=>user.age>=13 && user.age<20 );
// console.log(teenAgeUsers);

const products = [
    {id:1,name:'Laptop',details:{price:49999,instock:true}},
    {id:1,name:'Phone',details:{price:49999,instock:false}},
    {id:1,name:'Speaker',details:{price:49999,instock:true}},
    {id:1,name:'Car',details:{price:49999,instock:false}},
    {id:1,name:'Watch',details:{price:49999,instock:true}},
];
const inStockProducts = products.filter((product)=>product.details.instock);
console.log(inStockProducts);

//Assignment 1
//List of product in stock in Html table or Listitem
 
//Assignment :2
// Create array of Object of students which has Student
// id,name, result,percentage
// You should list out all passed student and they got the percentage greater than 80

const students = [
    {id:1,name:"Vivek",result:"pass",percentage:90},
    {id:2,name:"Sam",result:"fail",percentage:30},
    {id:3,name:"Atharva",result:"pass",percentage:75},
    {id:4,name:"Raman",result:"fail",percentage:50},
    {id:5,name:"Mohit",result:"pass",percentage:65}
];
const studentsPass = students.filter(x=>x.result==="pass" && x.percentage>=80);
console.log(studentsPass);