import axios from 'axios';

const API_URL = 'http://localhost:8090/feriagastro';

export const agregarFeriaGastro = async (feria) => {
  const response = await axios.post(`${API_URL}/crear`, feria);
  return response.data;
};

export const buscarFeriaGastroPorId = async (id) => {
  const response = await axios.get(`${API_URL}/buscar/${id}`);
  return response.data;
};

export const buscarFeriaGastroPorNombre = async (nombre) => {
  const response = await axios.get(`${API_URL}/buscar/nombre/${nombre}`);
  return response.data;
};

export const actualizarFeriaGastro = async (id, feria) => {
  const response = await axios.put(`${API_URL}/${id}`, feria);
  return response.data;
};

export const eliminarFeriaGastro = async (id) => {
  await axios.delete(`${API_URL}/eliminar/${id}`);
};  
export const listarFeriaGastro = async () => {
  const response = await axios.get(`${API_URL}/listar`);
  return response.data;
};

export const listarFeriaGastroPorPrecio = async (precioMaximo) => {
  const response = await axios.get(`${API_URL}/listar/precio/${precioMaximo}`);
  return response.data;
};