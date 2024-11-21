// const numbers=[1,2,3,4,5];
// const sum = numbers.reduce((accumulator,currentValue)=>
// accumulator+currentValue,0);
// console.log(sum);

// const nestedArray = [[1,2],[3,4],[5,6],[7,8]];
// const flatternedArray = nestedArray.reduce(
//     (accumulator,currentValue)=>accumulator.concat(currentValue),[]
// );
// console.log(flatternedArray);

// const users = [
//     {id:1,name:"Ranu",city:"Indore",age:45},
//     {id:2,name:"Monu",city:"Berlin",age:46},
//     {id:3,name:"Tinu",city:"Kasukabe",age:47},
//     {id:4,name:"Cheeku",city:"Indore",age:48},
// ];
// const groupByCity = users.reduce((x,y)=>{
//     const key = y.city;
//     if(!x[key]){
//         x[key] = [];
//     }
//     x[key].push(y);
//     return x;
// },{});
// console.log(groupByCity);

const cart=[
    {product:"Laptop",price:59000,quantity:1},
    {product:"Pen",price:90,quantity:5},
    {product:"Notebook",price:60,quantity:10},
];

const totalPrice = cart.reduce((accumulator,item)=>{
    return accumulator + item.price * item.quantity;
},0);
console.log(totalPrice);