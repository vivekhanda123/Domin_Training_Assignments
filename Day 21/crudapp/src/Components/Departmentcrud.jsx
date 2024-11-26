import React, { useState, useEffect } from "react";
import {
  getDepartments, // Fixed typo from getDepartmets to getDepartments
  createDepartment,
  updateDepartment,
  deleteDepartment,
} from "../Services/DepartmentService";

const Department = () => {
  const [departments, setDepartments] = useState([]);
  const [newDepartments, setNewDepartment] = useState({
    id: 0,
    name: "",
    departmentHead: "",
  });

  const [isEdit, setIsEdit] = useState(false);
  const [errors, setErrors] = useState({
    name: "",
    departmentHead: "",
  });

  useEffect(() => {
    fetchDepartments();
  }, []);

  const fetchDepartments = async () => {
    try {
      const data = await getDepartments(); // Fixed typo here
      setDepartments(data);
      console.log("Data", data);
    } catch (error) {
      console.error("Error fetching departments:", error);
    }
  };

  const validateForm = () => {
    let formErrors = {};
    if (!newDepartments.name) formErrors.name = "Name Required.";
    if (!newDepartments.departmentHead)
      formErrors.departmentHead = "Department Head is required.";
    setErrors(formErrors);
    return Object.keys(formErrors).length === 0;
  };

  const handleCreate = async () => {
    if (!validateForm()) return;

    try {
      console.log("handleCreate Called");
      await createDepartment(newDepartments);
      await fetchDepartments();
      setNewDepartment({ id: 0, name: "", departmentHead: "" });
    } catch (error) {
      console.error("Error while creating department:", error);
    }
  };

  const handleUpdate = async () => {
    if (!validateForm()) return;

    try {
      await updateDepartment(newDepartments.id, newDepartments);
      setDepartments(
        departments.map((dept) =>
          dept.id === newDepartments.id ? newDepartments : dept
        )
      );
      setIsEdit(false);
      setNewDepartment({ id: 0, name: "", departmentHead: "" });
    } catch (error) {
      console.error("Error while updating department:", error);
    }
  };

  const handleEdit = (department) => {
    setNewDepartment(department);
    setIsEdit(true);
  };

  const handleDelete = async (id) => {
    try {
      await deleteDepartment(id);
      setDepartments(departments.filter((dept) => dept.id !== id));
    } catch (error) {
      console.error("Error while deleting department:", error);
    }
  };

  return (
    <>
      <div>
        <h1>Departments</h1>
        <ul>
          {departments.map((department) => (
            <li key={department.id}>
              {department.name} - {department.departmentHead}
              <button onClick={() => handleEdit(department)}>Edit</button>
              <button onClick={() => handleDelete(department.id)}>Delete</button>
            </li>
          ))}
        </ul>
        <div>
          <h2>{isEdit ? "Edit Department" : "Add New Department"}</h2>
          <input
            type="text"
            placeholder="Name"
            value={newDepartments.name}
            onChange={(e) =>
              setNewDepartment({ ...newDepartments, name: e.target.value })
            }
          />
          {errors.name && <span style={{ color: "Red" }}>{errors.name}</span>}
          <input
            type="text"
            placeholder="Department Head"
            value={newDepartments.departmentHead}
            onChange={(e) =>
              setNewDepartment({
                ...newDepartments,
                departmentHead: e.target.value,
              })
            }
          />
          {errors.departmentHead && (
            <span style={{ color: "Red" }}>{errors.departmentHead}</span>
          )}
          <button onClick={isEdit ? handleUpdate : handleCreate}>
            {isEdit ? "Update" : "Add"}
          </button>
        </div>
      </div>
    </>
  );
};

export default Department;
