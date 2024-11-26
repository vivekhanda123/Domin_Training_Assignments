import React, { useRef, useState } from "react";
import "../css/controlledform.css"
import { useNavigate } from "react-router-dom";

const UnControlledLoginForm = () => {
  const emailRef = useRef();
  const passwordRef = useRef();
  const [errors, setErrors] = useState({}); // Fixed typo from setErros to setErrors
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    
    const email = emailRef.current.value;
    const password = passwordRef.current.value;
    
    console.log("handleSubmit called");
    
    let valid = true;
    let validationErrors = {}; // Use a separate object for validation errors
    
    // Validate email
    if (!email) {
      valid = false;
      validationErrors.email = "Enter the email";
    }
    
    // Validate password
    if (!password) {
      valid = false;
      validationErrors.password = "Enter the Password";
    }

    console.log("Before valid if condition:", valid);
    
    if (valid) {
      console.log("Login Data:", email, password);
      setErrors({});
      navigate("/sample"); // Navigate to another route if validation passes
    } else {
      console.log("Errors:", validationErrors);
      setErrors(validationErrors); // Update state with validation errors
    }
  };

  return (
    <>
      <h1>Uncontrolled Component Login Form Demo</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Email</label>
          <input type="email" ref={emailRef} />
          {errors.email && <span style={{ color: "red" }}>{errors.email}</span>}
        </div>
        <div>
          <label>Password</label>
          <input type="password" ref={passwordRef} />
          {errors.password && (
            <span style={{ color: "red" }}>{errors.password}</span>
          )}
        </div>
        <button type="submit">Login</button>
      </form>
    </>
  );
};

export default UnControlledLoginForm;
