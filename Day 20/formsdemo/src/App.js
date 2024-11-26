import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import LoginForm from "./components/controlledform";
import Sample from "./components/sample";
import UnControlledLoginForm from "./components/uncontrolledcomponent";
import FormWithHook from "./components/formwithhook";
import RegistrationFormWithDynamicFields from "./components/UseFormWithDynamicFields";
import DepartmentList from "./components/demowithoutuseEffect";

function App() {
  return (
    <div className="App">
      <Router>
        <Routes>
        <Route path="/" element={<DepartmentList />} />
          {/* <Route path="/" element={<RegistrationFormWithDynamicFields />} /> */}
          {/* <Route path="/" element={<FormWithHook />} /> */}
          {/* <Route path="/" element={<UnControlledLoginForm />} /> */}
          {/* <Route path="/" element={<LoginForm />} /> */}
          <Route path="/sample" element={<Sample />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
