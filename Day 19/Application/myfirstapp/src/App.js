import logo from "./logo.svg";
import "./App.css";
import conceptImg from "../src/assets/react-core-concepts.png";
import Profile from "./components/avatar";
import CoreConcept from "./components/CoreConcepts";
import reactComponent from "./assets/react-components.jpeg";
import { CORE_CONCEPTS } from "./data";
import InlineStyleExample from "./CSS/inlineStyle";
import CssClassDemo from "./CSS/cssClassDemo";
import Counter from "./components/counter";
import LoginLogout from "./components/loginlogoutdemo";
import ServerStatus from "./components/serverstatuswithstatus";
import ProductList from "./components/productlist";

const reactDescriptions = ["Fundamental", "Intermediate", "advanced"];

function getRandomInt(max) {
  return Math.floor(Math.random() * (max + 1));
}

function Header() {
  const description = reactDescriptions[getRandomInt(2)];
  return (
    <header>
      <main>
      
        <section id="core-concepts">
        <ProductList/>
        {/* <ServerStatus/> */}
        {/* <LoginLogout/> */}
        {/* <InlineStyleExample/>
        <CssClassDemo/>
        <Counter/> */}

          {/* <h2>Core concepts</h2> */}
          {/* <ul>
            <CoreConcept
              title={CORE_CONCEPTS[0].title}
              image={CORE_CONCEPTS[0].image}
              description={CORE_CONCEPTS[0].description}
            />
            <CoreConcept
              title={CORE_CONCEPTS[1].title}
              image={CORE_CONCEPTS[1].image}
              description={CORE_CONCEPTS[1].description}
            />
            <CoreConcept {...CORE_CONCEPTS[2]} />
            <CoreConcept {...CORE_CONCEPTS[3]} />
          </ul> */}
        </section>
      </main>
    </header>
  );
}

function App() {
  return (
    <div className="App">
      <Header />
    </div>
  );
}

export default App;