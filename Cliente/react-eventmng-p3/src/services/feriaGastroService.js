import axios from 'axios';

const API_URL = 'http://localhost:8090/feriagastro';

export const agregarFeriaGastro = async (feria) => {
  const response = await axios.post(`${API_URL}/add`, feria);
  return response.data;
};

export const buscarFeriaGastroPorId = async (id) => {
  const response = await axios.get(`${API_URL}/buscar/id/${id}`);
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

export const eliminarFeriaGastro = async (feria) => {
    await axios.delete(`${API_URL}/eliminar`, { data: feria });
  };

export const listarFeriaGastro = async () => {
  const response = await axios.get(`${API_URL}/listar`);
  return response.data;
};

export const listarFeriaGastroPorPrecio = async (precioMax) => {
  const response = await axios.get(`${API_URL}/listar/duracion/${precioMax}`);
  return response.data;
};