import React, { useState } from "react";
import "../css/controlledform.css";
import { useNavigate } from "react-router-dom";

const LoginForm = () => {
  const [formData, setFormData] = useState({ email: "", password: "" });
  const [errors, setErrors] = useState({});
  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const Validate = () => {
    let formErrors = {};
    if (!formData.email) {
      formErrors.email = "Email Required.";
    } else {
      const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      if (!emailPattern.test(formData.email)) {
        formErrors.email = "Please Enter a Valid Email";
      }
    }
    if (!formData.password) {
      formErrors.password = "Please enter the Password";
    }

    setErrors(formErrors);

    // Check if there are any validation errors
    return Object.keys(formErrors).length === 0;
  };

  const handleSubmit = (e) => {
    console.log("handleSubmit function called");
    e.preventDefault();

    const isValid = Validate();
    console.log("Validation result:", isValid);

    if (isValid) {
      navigate("/sample");
      console.log("Form is valid!");
      console.log(`formData: ${JSON.stringify(formData)}`);
      // Here, you can proceed with form submission logic, like sending data to an API
    } else {
      console.log("Form errors:", errors);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Email</label>
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
        />
        {errors.email && <span style={{ color: "red" }}>{errors.email}</span>}
      </div>
      <div>
        <label>Password</label>
        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
        />
        {errors.password && (
          <span style={{ color: "red" }}>{errors.password}</span>
        )}
      </div>
      <button type="submit">Login</button>
    </form>
  );
};

export default LoginForm;
