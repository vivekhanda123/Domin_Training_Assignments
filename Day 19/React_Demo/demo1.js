// const name = "Vivek";
// console.log("Entered name is",name);
// console.log("Entered name is " + name);
// console.log(`Entered name is ${name}`);

// Function Example 
// function great(name){
//     console.log(`Hi ${name}, Welcome to React Session`);
// }
// great('Hexaware');

// IIFE Immediately invoking function expression
// (function(name){
//     console.log(`Hi All welcome to today's session`);
// })();

// Arrow function 
const greet = () => {
    console.log(`I am an exxaple for arrow function without any parameter`);
}
greet();

const greetGuest = (name) => {
    console.log(`Hi ${name} welcome to react sesssion`);
}
greetGuest("Vivek");