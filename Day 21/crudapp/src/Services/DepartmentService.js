import axios from "axios";

const BASE_URL = "https://localhost:7247/api/Departments";

export const getDepartments = async () => {
  try {
    const response = await axios.get(BASE_URL);
    return response.data;
  } catch (error) {
    console.error("Error fetching departments:", error);
    throw error;
  }
};

export const createDepartment = async (department) => {
  try {
    const response = await axios.post(BASE_URL, department);
    console.log("Response from API:", response.data);
    return response.data;
  } catch (error) {
    console.error("Error while creating new department:", error);
    throw error;
  }
};

export const updateDepartment = async (id, department) => {
  try {
    const response = await axios.put(`${BASE_URL}/${id}`, department); // Corrected URL
    return response.data;
  } catch (error) {
    console.error("Error while updating department:", error);
    throw error;
  }
};

export const deleteDepartment = async (id) => {
  try {
    await axios.delete(`${BASE_URL}/${id}`); // Updated to use a cleaner URL
  } catch (error) {
    console.error("Error while deleting department:", error);
    throw error;
  }
};
