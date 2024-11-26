import 'bootstrap/dist/css/bootstrap.min.css';
import logo from "./logo.svg";
import "./App.css";
import { useState } from "react";
import Header from "./components/Header";
import HomePage from "./components/HomePage";
import { AuthProvider } from "./components/AuthContext";
// import { Route } from "react-router-dom";
import Home from "./components/Home";
import Login from "./components/Login";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import ProtectedRoute from "./components/ProtectedRoute";
import Products from "./components/Product";
import Footer from "./components/footer";


function App() {
  return (
    <div className="App">
      <AuthProvider>
        <Router>
          <Header />
          <div className="content">
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/login" element={<Login />} />
              <Route element={<ProtectedRoute />}>
                <Route path="/products" element={<Products />} />
              </Route>
            </Routes>
          </div>
          <Footer />
        </Router>
      </AuthProvider>
    </div>
  );
}

export default App;
